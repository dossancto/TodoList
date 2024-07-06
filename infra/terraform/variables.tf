variable "aws_secret_key" {
  description = "Your aws secret key"
  type        = string
  default     = "dummy"
}

variable "aws_access_key" {
  description = "Your aws access key"
  type        = string
  default     = "dummy"
}

variable "aws_region" {
  description = "Your main AWS Region"
  type        = string
  default     = "us-east-1"
}

variable "aws_skip_key_validations" {
  description = "Skip key validations"
  type        = bool
  default     = true
}

variable "aws_base_url" {
  description = "Base URL"
  type        = string
  default     = "http://localhost:4566"
}
