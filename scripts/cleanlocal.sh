#!/bin/bash
# Local cleanup script for TCGStore development environment
# Destroys Terraform infrastructure and removes dotnet user secrets

set -e  # Exit on error

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PROJECT_ROOT="$(dirname "$SCRIPT_DIR")"
TERRAFORM_DIR="$PROJECT_ROOT/infra/terraform-dynamodb-infrastructure"
API_PROJECT_DIR="$PROJECT_ROOT/TCGStore.Api"

echo "========================================="
echo "TCGStore Local Environment Cleanup"
echo "========================================="
echo ""
echo "⚠️  WARNING: This will:"
echo "   1. Destroy all Terraform-managed AWS resources"
echo "   2. Remove all .NET user secrets"
echo ""

read -p "Are you sure you want to continue? (yes/no): " confirmation

if [ "$confirmation" != "yes" ]; then
    echo "❌ Cleanup cancelled."
    exit 0
fi

echo ""

# Check if terraform is installed
if ! command -v terraform &> /dev/null; then
    echo "❌ Terraform is not installed."
    exit 1
fi

# Navigate to terraform directory
echo "📁 Navigating to Terraform directory: $TERRAFORM_DIR"
cd "$TERRAFORM_DIR"

# Destroy Terraform infrastructure
echo "🗑️  Destroying Terraform resources with terraform.dev.tfvars..."
terraform destroy -var-file="terraform.dev.tfvars" -auto-approve

if [ $? -eq 0 ]; then
    echo "✅ Terraform resources destroyed successfully"
else
    echo "⚠️  Warning: Terraform destroy encountered an error, but continuing with secret cleanup..."
fi

echo ""

# Clean up dotnet user secrets
echo "🔐 Cleaning up .NET user secrets..."
cd "$API_PROJECT_DIR"

# Check if user secrets are initialized
if dotnet user-secrets list &>/dev/null 2>&1; then
    echo "   Removing AWS:DynamoDB:ServiceURL secret..."
    dotnet user-secrets remove "AWS:DynamoDB:ServiceURL" 2>/dev/null || true
    
    echo "   Clearing all user secrets..."
    dotnet user-secrets clear
    
    echo "✅ User secrets cleared successfully"
else
    echo "⚠️  No user secrets found for this project"
fi

echo ""
echo "========================================="
echo "✅ Cleanup Complete!"
echo "========================================="
echo ""
echo "Cleaned up:"
echo "  ✓ Terraform infrastructure (AWS resources)"
echo "  ✓ .NET user secrets"
echo ""
echo "Your local development environment is now clean."
