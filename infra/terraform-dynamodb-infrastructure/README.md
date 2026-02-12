# Terraform DynamoDB Infrastructure

This project sets up a DynamoDB table using Terraform for local and cloud development. The infrastructure is deployed to AWS and accessible from local development environments through the AWS SDK.

## Project Structure

- **main.tf**: The main configuration file that defines the resources to be created.
- **variables.tf**: Contains input variables for the Terraform configuration.
- **outputs.tf**: Defines the output values returned after applying the configuration (table name, ARN, region).
- **providers.tf**: Specifies the required providers and authentication details.
- **dynamodb.tf**: Contains the configuration specific to the DynamoDB table.
- **terraform.dev.tfvars**: Development environment variables.
- **terraform.tfvars.example**: An example file for setting variable values.

## Prerequisites

- Terraform installed on your machine.
- AWS account with appropriate permissions to create DynamoDB resources.
- AWS CLI configured with your credentials (see setup below).
- .NET SDK 10 or higher (for local development).

## AWS Credentials Setup

Before running the setup script, ensure your AWS credentials are configured:

```bash
# Option 1: Using AWS CLI
aws configure

# Option 2: Using environment variables
export AWS_ACCESS_KEY_ID="your-access-key"
export AWS_SECRET_ACCESS_KEY="your-secret-key"

# Option 3: Using ~/.aws/credentials file
[default]
aws_access_key_id = your-access-key
aws_secret_access_key = your-secret-key
```

## Local Development Setup

For local development, use the provided setup script from the project root:

```bash
./scripts/localsetup.sh
```

This script will:
1. Initialize Terraform
2. Create the DynamoDB table in AWS using `terraform.dev.tfvars`
3. Extract the table name and region from Terraform outputs
4. Store these values in .NET user secrets for local development

### What the Setup Script Does

The setup script configures your local development environment to connect to a remote DynamoDB instance in AWS:

1. **Terraform** creates the DynamoDB table in AWS (region: us-west-2)
2. **User Secrets** stores the table name and region locally
3. **AWS SDK** uses your AWS credentials to connect to the remote table

## After Setup

Once the setup script completes successfully:

```bash
cd ../../
dotnet run --project TCGStore.Api
```

The .NET application will:
- Read DynamoDB configuration from user secrets
- Use your AWS credentials from environment/profile
- Connect to the DynamoDB table created in AWS

## Output Values

After Terraform apply, you can view the created resources:

```bash
cd infra/terraform-dynamodb-infrastructure
terraform output
```

Outputs include:
- `dynamodb_table_name`: The name of the created DynamoDB table
- `dynamodb_table_arn`: The ARN of the created table
- `aws_region`: The AWS region where the table is deployed

## Manual Deployment

If you prefer to deploy manually without the setup script:

1. Initialize Terraform:
   ```
   terraform init
   ```

2. Validate the configuration:
   ```
   terraform validate
   ```

3. Plan the deployment:
   ```
   terraform plan -var-file="terraform.dev.tfvars"
   ```

4. Apply the configuration:
   ```
   terraform apply -var-file="terraform.dev.tfvars"
   ```

## Configuration

### Variables (terraform.dev.tfvars)

- `aws_region`: AWS region for DynamoDB (default: us-west-2)
- `table_name`: Name of the DynamoDB table (default: tcgstore-dev)
- `billing_mode`: DynamoDB billing mode - PROVISIONED or PAY_PER_REQUEST
- `read_capacity`: RCU for provisioned billing
- `write_capacity`: WCU for provisioned billing
- `tags`: Resource tags for organization

### Environment Variables

The .NET application uses these secrets:
- `AWS:DynamoDB:TableName`: Set by localsetup.sh
- `AWS:DynamoDB:Region`: Set by localsetup.sh

## Cleanup

To destroy the infrastructure and remove all AWS resources:

```bash
terraform destroy -var-file="terraform.dev.tfvars"
```


## Cleanup

To remove the created resources, run:
```
terraform destroy
```

## License

This project is licensed under the MIT License.