module "dynamodb" {
  source = "./modules/dynamodb"
}

module "sqs" {
  source = "./modules/sqs"
}
