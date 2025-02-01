# 📚 Projeto: API Exemple - Sistema de Mensageria e Autenticação

# API Exemple

## Visão Geral
A API Exemple é uma aplicação de exemplo que demonstra a implementação de uma API REST utilizando ASP.NET Core 8, com suporte a RabbitMQ, Kafka, autenticação JWT e banco de dados SQL Server. 

## Tecnologias Utilizadas
- **ASP.NET Core 8**
- **Entity Framework Core**
- **RabbitMQ e MassTransit**
- **Kafka e Confluent.Kafka**
- **Redis para cache**
- **MediatR para CQRS**
- **FluentValidation**
- **Swagger para documentação da API**
- **Serilog para logging**
- **Docker para conteinerização**

## Pacotes Utilizados
- **Bogus**: Geração de dados fictícios para testes.
- **Carter**: Extensão para rotas minimalistas em ASP.NET Core.
- **Confluent.Kafka**: Cliente Kafka para comunicação assíncrona.
- **Mapster** e **Mapster.Core**: Mapeamento de objetos sem reflexão.
- **Antlr4.Runtime**: Biblioteca para análise e processamento de linguagem.
- **Ardalis.Result**: Manipulação de retornos de operação.
- **Ardalis.SmartEnum**: Enumerações inteligentes em C#.
- **FluentValidation**: Validação de modelos de entrada.
- **AutoMapper**: Mapeamento de objetos automatizado.
- **RabbitMQ e MassTransit**: Comunicação assíncrona baseada em mensagens.
- **MediatR**: Implementação do padrão CQRS.
- **Microsoft.AspNetCore.Authentication.JwtBearer**: Suporte a autenticação JWT.
- **Microsoft.AspNetCore.Mvc.Versioning**: Controle de versão da API.
- **Microsoft.EntityFrameworkCore** e **SQL Server**: ORM para banco de dados relacional.
- **Newtonsoft.Json**: Manipulação avançada de JSON.
- **Refit**: Cliente HTTP baseado em interfaces.
- **Serilog**: Logging estruturado.
- **Swashbuckle.AspNetCore**: Suporte a OpenAPI/Swagger.

## Endpoints da API

### Autenticação
Gerar token de acesso:
```sh
curl --location 'http://localhost:5000/api-auth/api/v1/login' \
--header 'accept: application/json' \
--header 'Content-Type: application/json' \
--header 'X-API-Key: ••••••' \
--data-raw '{
  "email": "gfmaurila@gmail.com",
  "password": "@C23l10a1985"
}'
```

### Endpoints da API Exemple

#### Listar exemplos
```sh
curl --location 'https://localhost:44387/api/v1/Exemple' \
--header 'accept: text/plain' \
--header 'Authorization: ••••••'
```

#### Paginação e filtro por nome
```sh
curl --location 'https://localhost:44387/api/v1/Exemple/exemple?FiltroFirstName=t&PageNumber=1&PageSize=1' \
--header 'Authorization: ••••••'
```

#### Buscar exemplo por ID
```sh
curl --location 'https://localhost:44387/api/v1/Exemple/92836fd8-8d5c-40af-a144-464b3749501b' \
--header 'Authorization: Bearer ••••••'
```

#### Criar um novo exemplo
```sh
curl --location 'https://localhost:44387/api/v1/Exemple' \
--header 'accept: text/plain' \
--header 'Content-Type: application/json' \
--header 'Authorization: ••••••' \
--data-raw '{
  "firstName": "string",
  "lastName": "string",
  "status": true,
  "gender": 1,
  "notification": "SMS",
  "email": "strings1@teste.com",
  "phone": "string",
  "role": [
    "Admin"
  ]
}'
```

#### Atualizar um exemplo existente
```sh
curl --location --request PUT 'https://localhost:44387/api/v1/Exemple' \
--header 'accept: text/plain' \
--header 'Content-Type: application/json' \
--header 'Authorization: ••••••' \
--data-raw '{
  "id": "92836fd8-8d5c-40af-a144-464b3749501b",
  "firstName": "Teste 01",
  "lastName": "teste 01",
  "gender": 1,
  "notification": 1,
  "email": "user1s@example.com",
  "phone": "51985623312",
  "role": [
    "EMPLOYEE_AUTH", "ADMIN_AUTH"
  ]
}'
```

#### Excluir um exemplo
```sh
curl --location --request DELETE 'https://localhost:44387/api/v1/Exemple/92836fd8-8d5c-40af-a144-464b3749501b' \
--header 'accept: text/plain' \
--header 'Authorization: ••••••'
```

### Notificações
Enviar notificação:
```sh
curl --location 'https://localhost:44387/api/v1/Notification' \
--header 'accept: text/plain' \
--header 'Content-Type: application/json' \
--header 'Authorization: ••••••' \
--data '{
  "notification": 1,
  "from": "teste from - Teste ",
  "body": "teste body - Teste ",
  "to": "teste to - teste "
}'
```

## Rodando a API
### Subindo os serviços com Docker
```sh
docker network create shared-network
docker-compose down
docker-compose up -d --build
```

### Aplicando migrações do banco de dados
```sh
dotnet new webapi -n AuthSystem
Add-Migration Inicial -Context ExempleAppDbContext 
Update-Database -Context ExempleAppDbContext 
```

### Rodando testes
```sh
dotnet test
```

## Contribuição
Sinta-se à vontade para contribuir com melhorias na API Exemple. Pull requests são bem-vindos! 🚀



---

## 🧑‍💻 **Autor**
- **Guilherme Figueiras Maurila**

---

## 📫 Como me encontrar
[![YouTube](https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white)](https://www.youtube.com/channel/UCjy19AugQHIhyE0Nv558jcQ)
[![Linkedin Badge](https://img.shields.io/badge/-Guilherme_Figueiras_Maurila-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/guilherme-maurila)](https://www.linkedin.com/in/guilherme-maurila)
[![Gmail Badge](https://img.shields.io/badge/-gfmaurila@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:gfmaurila@gmail.com)](mailto:gfmaurila@gmail.com)

