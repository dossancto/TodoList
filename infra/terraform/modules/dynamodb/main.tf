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


resource "aws_dynamodb_table" "processing_todos" {
  name           = "processing_todos"
  billing_mode   = "PROVISIONED"
  read_capacity  = 1
  write_capacity = 1

  hash_key = "todo_id"

  attribute {
    name = "todo_id"
    type = "S"
  }

  tags = {
    Name = "Todo"
  }
}

