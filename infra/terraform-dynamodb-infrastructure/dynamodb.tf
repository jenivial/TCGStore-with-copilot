resource "aws_dynamodb_table" "tcgstore_table" {
  name             = var.table_name
  billing_mode     = var.billing_mode
  hash_key         = var.partition_key
  read_capacity    = var.billing_mode == "PROVISIONED" ? var.read_capacity : null
  write_capacity   = var.billing_mode == "PROVISIONED" ? var.write_capacity : null

  attribute {
    name = var.partition_key
    type = "S"
  }

  tags = var.tags
}