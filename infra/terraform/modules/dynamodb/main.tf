resource "aws_dynamodb_table" "colors" {
  name           = "colors"
  billing_mode   = "PROVISIONED"
  read_capacity  = 1
  write_capacity = 1

  hash_key = "color"

  attribute {
    name = "color"
    type = "S"
  }

  tags = {
    Name = "My DynamoDB Table"
  }
}

