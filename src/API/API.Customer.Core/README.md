# 📚 Projeto: API.Customer.Core

## 📖 Descrição
A **API.Customer.Core** é responsável pelo gerenciamento de clientes e suas assinaturas dentro do ecossistema de produtos SaaS. Essa API permite a criação e administração de contas, usuários, planos e a gestão de cobrança de excedentes por envio de mensagens (**e-mail, SMS, WhatsApp**).

### 🌍 Produtos Integrados
Cada cliente poderá assinar um ou mais produtos, sendo eles:

- **API.Clinic.Core** → Sistema para clínicas e consultórios.
- **API.Freelancer.Core** → Plataforma de freelancers.
- **API.HR.Core** → Gestão de recursos humanos.
- **API.InventoryControl.Core** → Controle de estoque e inventário.

## 🏗 Estrutura do Domínio
A API é organizada da seguinte forma:

### 1️⃣ **Conta (`Account`)**
- Representa uma organização ou empresa.
- Possui **múltiplos usuários** vinculados.
- Está associada a um **plano de assinatura** que define o acesso aos produtos e os limites de uso.

### 2️⃣ **Usuário (`User`)**
- Cada conta pode ter **vários usuários**.
- O cadastro do usuário é realizado automaticamente na **API.External.Person**.
- A autenticação é gerenciada pela **API.External.Auth**.

### 3️⃣ **Plano de Assinatura (`SubscriptionPlan`)**
- Define os produtos contratados.
- Especifica limites de uso para envios de mensagens.
- Pode ser mensal ou anual.

### 4️⃣ **Mensagens (`MessageUsage`)**
- Controle de envios de mensagens.
- Tipos suportados: **E-mail, SMS, WhatsApp**.
- Cobrança de excedentes caso o limite do plano seja ultrapassado.

### 🔗 **Relacionamentos**
- Uma **Conta** pode ter **vários Usuários**.
- Cada **Usuário** está associado a uma única **Pessoa** na **API.External.Person**.
- Cada **Usuário** realiza autenticação via **API.External.Auth**.
- Uma **Conta** pode assinar múltiplos **Produtos**.
- Uma **Conta** possui um **Plano de Assinatura** e pode incorrer em **custos adicionais** por excedentes.

## 🚀 Tecnologias e Arquitetura
A API será desenvolvida utilizando **.NET Core 8**, seguindo boas práticas de desenvolvimento.

📌 **Stack Tecnológico:**
- **.NET Core 8** para desenvolvimento da API.
- **Entity Framework Core** para persistência de dados.
- **PostgreSQL / SQL Server** como banco de dados relacional.
- **Swagger/OpenAPI** para documentação interativa.
- **Autenticação JWT** para segurança e controle de acesso.
- **Integrações REST com APIs externas** para autenticação e cadastro de pessoas.

## 🎯 Próximos Passos
1. **Definir a estrutura inicial do projeto.**
2. **Implementar a camada de domínio**, criando as entidades e relacionamentos.
3. **Desenvolver a camada de persistência com EF Core.**
4. **Criar os endpoints REST para gerenciamento de contas e usuários.**

---

## Estrutura de Pastas

### Projeto Principal
```
API.Customer.Core
├── Connected Services
├── Dependências
├── Properties
├── Controllers
├── Extensions
├── Feature
│   ├── Domain
│   │   ├── Common
│   │   └── Exemple
│   ├── Exemple
│       ├── Commands
│       │   ├── Create
│       │   ├── Delete
│       │   └── Update
│       └── Queries
│           ├── Get
│           ├── GetById
│           └── GetPaginate
├── Infrastructure
│   ├── Auth
│   ├── Database
│   │   ├── Mappings
│   │   ├── Repositories
│   │   ├── ExempleAppDbContext.cs
│   │   └── UnitOfWork.cs
│   ├── Integration
│   ├── Messaging
│   └── Redis
├── Migrations
├── API.Customer.Core.http
├── appsettings.json
├── Dockerfile
└── Program.cs
└── README.md
```


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

### Ambientes
```sh
API: http://localhost:5002/swagger/index.html
Kafka: http://localhost:9100/
RabbitMQ: http://localhost:15672/#/
```

### Documentação
![Diagrama Exemple](https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/blob/main/Documento/04%20-%20API.Customer.Core/04%20-%20API.Customer.Core-Exemple.jpg)
![Diagrama Notification](https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/blob/main/Documento/04%20-%20API.Customer.Core/04%20-%20API.Customer.Core-Notification.jpg)
![Fluxo](https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/blob/main/Documento/04%20-%20API.Customer.Core/04%20-%20API.Customer.Core-Fluxo-API.jpg)



📌 **Contribuições**
Sinta-se à vontade para abrir um Pull Request ou sugerir melhorias por meio de Issues!



---

## 🧑‍💻 **Autor**
- **Guilherme Figueiras Maurila**

---

## 📫 Como me encontrar
[![YouTube](https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white)](https://www.youtube.com/channel/UCjy19AugQHIhyE0Nv558jcQ)
[![Linkedin Badge](https://img.shields.io/badge/-Guilherme_Figueiras_Maurila-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/guilherme-maurila)](https://www.linkedin.com/in/guilherme-maurila)
[![Gmail Badge](https://img.shields.io/badge/-gfmaurila@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:gfmaurila@gmail.com)](mailto:gfmaurila@gmail.com)

