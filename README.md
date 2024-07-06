# Todo List

## Dependencies

- Dotnet 8
- Docker and Docker Compose

## Running

- Prepare Environment. Setup `.env` file, see `.env.example` for instructions

```sh
cp .env.example .env
```

- Start services on `docker-compose`. 

```sh
docker-compose up -d
```

- Start your localstack service

```sh
localstack start -d
```

- Create terraform services with `terraform apply` (`infra/terraform/` directory)

```sh
terraform apply
```

- Finally, Run the backend

```sh
make api/run
```

