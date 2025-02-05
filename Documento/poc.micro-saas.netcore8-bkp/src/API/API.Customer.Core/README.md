# 📌 API.Customer.Core

## 📖 Descrição
A **API.Customer.Core** gerencia clientes, contas e assinaturas dentro do ecossistema de produtos SaaS. Essa API permite a administração de contas, usuários, múltiplos planos de assinatura e controle de mensagens enviadas (**e-mail, SMS, WhatsApp**), cobrando por excedentes quando necessário.

### 🌍 Produtos Integrados
Cada cliente pode assinar um ou mais produtos:

- **API.Clinic.Core** → Sistema para clínicas e consultórios.
- **API.Freelancer.Core** → Plataforma de freelancers.
- **API.HR.Core** → Gestão de recursos humanos.
- **API.InventoryControl.Core** → Controle de estoque e inventário.

## 🏗 Estrutura do Domínio
A API gerencia entidades inter-relacionadas para manter o controle das assinaturas e cobranças:

### 1️⃣ **Conta (`Account`)**
- Representa uma organização ou empresa.
- Pode ter **múltiplos planos de assinatura**.
- Cada plano está associado a um ou mais produtos.

### 2️⃣ **Assinatura (`AccountSubscription`)**
- Representa um plano específico que a conta assinou.
- Define os produtos contratados e seus limites de mensagens.
- Conectada diretamente a um plano de assinatura (`SubscriptionPlan`).

### 3️⃣ **Plano de Assinatura (`SubscriptionPlan`)**
- Define os produtos incluídos.
- Especifica limites de envio de mensagens.
- Estabelece valores para cobranças extras caso os limites sejam ultrapassados.

### 4️⃣ **Uso de Mensagens (`MessageUsage`)**
- Controla os envios de mensagens para cada assinatura.
- Registra a quantidade de mensagens enviadas no mês.
- Acumula cobranças extras quando os limites são ultrapassados.

### 5️⃣ **Itens de Uso de Mensagens (`MessageUsageItem`)**
- Cada item representa um tipo de mensagem enviada (e-mail, SMS, WhatsApp).
- Contabiliza a quantidade de mensagens enviadas e o custo adicional por excedente.

### 6️⃣ **Produto Associado (`AccountProduct`)**
- Representa os produtos ativos para cada assinatura.
- Um plano pode incluir um ou mais produtos.

## 🔗 **Fluxo de Funcionamento**
1. **Criação da Conta:**
   - Um cliente cria uma **conta** (`Account`).
   - Os usuários são gerenciados externamente pela **API.External.Person** e **API.External.Auth**.

2. **Assinatura de Planos:**
   - A conta pode assinar um ou mais **planos de assinatura** (`AccountSubscription`).
   - Cada plano contém produtos específicos (`AccountProduct`).

3. **Envio de Mensagens:**
   - Quando um usuário utiliza um serviço (exemplo: API.Clinic.Core), ele pode enviar **mensagens**.
   - Cada mensagem enviada é registrada como um **MessageUsageItem**.

4. **Cobrança por Excedentes:**
   - Se os limites de envio do plano forem ultrapassados, o sistema registra **cobranças extras**.
   - No final do mês, o total de cobranças (`ExtraCharges`) é calculado e gerado para faturamento.

## 🚀 Tecnologias e Arquitetura
📌 **Stack Tecnológico:**
- **.NET Core 8** para desenvolvimento da API.
- **Entity Framework Core** para persistência de dados.
- **PostgreSQL / SQL Server** como banco de dados relacional.
- **Swagger/OpenAPI** para documentação interativa.
- **Autenticação JWT** para segurança e controle de acesso.
- **Integrações REST com APIs externas** para autenticação e cadastro de pessoas.

## 🎯 Próximos Passos
1. **Implementar a lógica de faturamento no fechamento do mês.**
2. **Criar endpoints para consulta de consumo e relatórios financeiros.**
3. **Desenvolver notificações automáticas para avisar sobre limites de mensagens.**


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

