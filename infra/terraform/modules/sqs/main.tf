resource "aws_sqs_queue" "complete_todo" {
  name                      = "${var.complete_todo_queue}.fifo"
  delay_seconds             = 1
  fifo_queue                = true
  max_message_size          = 2048
  message_retention_seconds = 86400
  receive_wait_time_seconds = 10

  content_based_deduplication = true

  redrive_policy = jsonencode({
    deadLetterTargetArn = aws_sqs_queue.complete_todo_deadletter.arn
    maxReceiveCount     = 2
  })

  tags = {
    Environment = "production"
  }
}

resource "aws_sqs_queue" "complete_todo_deadletter" {
  name                      = "${var.complete_todo_queue}-deadletter.fifo"
  fifo_queue                = true
  max_message_size          = 2048
  message_retention_seconds = 86400
  receive_wait_time_seconds = 10
}
