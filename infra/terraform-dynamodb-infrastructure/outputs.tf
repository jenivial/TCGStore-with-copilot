output "dynamodb_table_name" {
  value       = aws_dynamodb_table.tcgstore_table.name
  description = "The name of the DynamoDB table"
}

output "dynamodb_table_arn" {
  value       = aws_dynamodb_table.tcgstore_table.arn
  description = "The ARN of the DynamoDB table"
}

output "aws_region" {
  value       = var.aws_region
  description = "The AWS region where DynamoDB table is created"
}