#!/bin/bash
# Local setup script for TCGStore development environment
# Initializes Terraform infrastructure and configures dotnet secrets for local DynamoDB connection

set -e  # Exit on error

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PROJECT_ROOT="$(dirname "$SCRIPT_DIR")"
TERRAFORM_DIR="$PROJECT_ROOT/infra/terraform-dynamodb-infrastructure"
API_PROJECT_DIR="$PROJECT_ROOT/TCGStore.Api"

echo "========================================="
echo "TCGStore Local Development Setup"
echo "========================================="
echo ""

# Check if terraform is installed
if ! command -v terraform &> /dev/null; then
    echo "❌ Terraform is not installed. Please install Terraform first."
    exit 1
fi

# Check if dotnet is installed
if ! command -v dotnet &> /dev/null; then
    echo "❌ .NET CLI is not installed. Please install .NET first."
    exit 1
fi

# Check if AWS credentials are configured
if ! aws sts get-caller-identity &>/dev/null 2>&1; then
    echo "⚠️  WARNING: AWS credentials are not configured."
    echo "   Please configure AWS credentials using one of the following methods:"
    echo "   1. Set AWS_ACCESS_KEY_ID and AWS_SECRET_ACCESS_KEY environment variables"
    echo "   2. Run 'aws configure' to set up your credentials"
    echo "   3. Ensure your AWS profile is set up in ~/.aws/credentials"
    echo ""
    read -p "Continue anyway? (yes/no): " continue_without_creds
    if [ "$continue_without_creds" != "yes" ]; then
        echo "❌ Setup cancelled. Please configure AWS credentials first."
        exit 1
    fi
fi

# Navigate to terraform directory
echo "📁 Navigating to Terraform directory: $TERRAFORM_DIR"
cd "$TERRAFORM_DIR"

# Initialize Terraform (safe to run multiple times)
echo "🔧 Initializing Terraform..."
terraform init

# Apply Terraform configuration with dev variables
echo "🚀 Applying Terraform configuration with terraform.dev.tfvars..."
terraform apply -var-file="terraform.dev.tfvars" -auto-approve

# Extract Terraform outputs
DYNAMODB_TABLE_NAME=$(terraform output -raw dynamodb_table_name 2>/dev/null || echo "")
DYNAMODB_REGION=$(terraform output -raw aws_region 2>/dev/null || echo "us-west-2")

if [ -z "$DYNAMODB_TABLE_NAME" ]; then
    echo "⚠️  Warning: Could not retrieve DynamoDB table name from Terraform outputs"
    exit 1
fi

echo "💾 Configuring .NET user secrets..."
cd "$API_PROJECT_DIR"

# Initialize user secrets if not already initialized
if ! dotnet user-secrets list &>/dev/null 2>&1; then
    echo "   Initializing user secrets project..."
    dotnet user-secrets init
fi

# Store DynamoDB configuration in user secrets
echo "   Setting DynamoDB configuration..."
dotnet user-secrets set "AWS:DynamoDB:TableName" "$DYNAMODB_TABLE_NAME"
dotnet user-secrets set "AWS:DynamoDB:Region" "$DYNAMODB_REGION"

echo ""
echo "========================================="
echo "✅ Setup Complete!"
echo "========================================="
echo ""
echo "Next steps:"
echo "1. Run the API: dotnet run --project TCGStore.Api"
echo ""
echo "Amazon DynamoDB configuration:"
echo "  Table Name: $DYNAMODB_TABLE_NAME"
echo "  Region: $DYNAMODB_REGION"
echo "  Status: Connected to AWS (Terraform managed)"
