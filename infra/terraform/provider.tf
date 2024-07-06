provider "aws" {
  access_key = var.aws_access_key
  secret_key = var.aws_secret_key

  region = var.aws_region

  s3_use_path_style           = var.aws_skip_key_validations
  skip_credentials_validation = var.aws_skip_key_validations
  skip_metadata_api_check     = var.aws_skip_key_validations
  skip_requesting_account_id  = var.aws_skip_key_validations

  endpoints {
    apigateway     = var.aws_base_url
    apigatewayv2   = var.aws_base_url
    cloudformation = var.aws_base_url
    cloudwatch     = var.aws_base_url
    dynamodb       = var.aws_base_url
    ec2            = var.aws_base_url
    elasticache    = var.aws_base_url
    firehose       = var.aws_base_url
    iam            = var.aws_base_url
    kinesis        = var.aws_base_url
    lambda         = var.aws_base_url
    rds            = var.aws_base_url
    redshift       = var.aws_base_url
    route53        = var.aws_base_url
    s3             = var.aws_base_url
    secretsmanager = var.aws_base_url
    ses            = var.aws_base_url
    sns            = var.aws_base_url
    sqs            = var.aws_base_url
    ssm            = var.aws_base_url
    stepfunctions  = var.aws_base_url
    sts            = var.aws_base_url
  }
}
