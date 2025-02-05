# 📚 Projeto: API.External.Person -  Micro SaaS API - Cadastro de Pessoa

# API.External.Person

## 📖 Descrição
A **Micro SaaS API** é um serviço para o cadastro e gerenciamento de informações de **Pessoa Física** e **Pessoa Jurídica** dentro de um ambiente **Micro SaaS**. 

O serviço é projetado para ser escalável, seguro e flexível, permitindo integrações futuras e garantindo consistência nos dados.

## 🏗 Estrutura do Domínio
O domínio principal da API será o **Cadastro de Pessoas**, que incluirá as seguintes entidades principais:

### 1️⃣ **Pessoa (`Person`)**
- Pode ser **Pessoa Física** ou **Pessoa Jurídica**.
- Contém informações gerais aplicáveis a ambos os tipos.

### 2️⃣ **Pessoa Física (`IndividualPerson`)**
- CPF (Cadastro de Pessoa Física).
- Nome completo.
- Data de nascimento.
- Gênero (opcional).
- Nome da mãe (opcional).
- Nome do pai (opcional).

### 3️⃣ **Pessoa Jurídica (`LegalEntity`)**
- CNPJ (Cadastro Nacional de Pessoa Jurídica).
- Razão Social.
- Nome Fantasia.
- Data de abertura.
- Inscrição Estadual (opcional).
- Inscrição Municipal (opcional).
- Nome dos sócios.

### 4️⃣ **Documento (`Document`)**
- Tipo do documento (CPF, RG, CNPJ, Passaporte, CNH, etc.).
- Número do documento.
- Data de emissão.
- Órgão emissor.
- País de emissão.

### 5️⃣ **Endereço (`Address`)**
- Tipo de endereço (Residencial, Comercial, Cobrança, etc.).
- Logradouro.
- Número.
- Complemento.
- Bairro.
- Cidade.
- Estado.
- CEP.
- País.

### 6️⃣ **Telefone (`Phone`)**
- Tipo de telefone (Celular, Fixo, Comercial, WhatsApp).
- Código de área (DDD).
- Número do telefone.

### 7️⃣ **E-mail (`Email`)**
- Endereço de e-mail.
- Tipo (Pessoal, Comercial, Financeiro, Suporte).

### 🔗 **Relacionamentos**
- Uma **Pessoa** pode ter múltiplos **Endereços**, **Telefones** e **E-mails**.
- Uma **Pessoa Física** pode ter múltiplos **Documentos** (ex: CPF e RG).
- Uma **Pessoa Jurídica** pode ter múltiplos **sócios** cadastrados.

## 🚀 Tecnologias e Arquitetura
A API será desenvolvida utilizando **.NET Core 8**, seguindo as melhores práticas de desenvolvimento de software moderno.

📌 **Stack Tecnológico:**
- **.NET Core 8** para desenvolvimento da API.
- **Entity Framework Core** para mapeamento do banco de dados.
- **PostgreSQL / SQL Server** como banco de dados relacional (a definir).
- **Swagger/OpenAPI** para documentação e testes da API.
- **Autenticação JWT** para segurança e controle de acesso.
- **Clean Architecture** seguindo princípios **DDD (Domain-Driven Design)** e **SOLID**.

## 🎯 Próximos Passos
1. **Definir a estrutura inicial do projeto.**
2. **Implementar a camada de domínio**, criando as entidades e relacionamentos.
3. **Desenvolver a camada de repositório**, utilizando EF Core.
4. **Criar os endpoints REST para gerenciamento de pessoas.**


## Estrutura de Pastas

### Projeto Principal
```
API.External.Person
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
├── API.Exemple.Core.08.http
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
![Diagrama Exemple](https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/blob/main/Documento/04%20-%20API.Exemple.Core.08/04%20-%20API.Exemple.Core.08-Exemple.jpg)
![Diagrama Notification](https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/blob/main/Documento/04%20-%20API.Exemple.Core.08/04%20-%20API.Exemple.Core.08-Notification.jpg)
![Fluxo](https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/blob/main/Documento/04%20-%20API.Exemple.Core.08/04%20-%20API.Exemple.Core.08-Fluxo-API.jpg)



📌 **Contribuições**
Sinta-se à vontade para abrir um Pull Request ou sugerir melhorias por meio de Issues!

💡 **Queremos construir algo escalável e eficiente!** 🚀


---

## 🧑‍💻 **Autor**
- **Guilherme Figueiras Maurila**

---

## 📫 Como me encontrar
[![YouTube](https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white)](https://www.youtube.com/channel/UCjy19AugQHIhyE0Nv558jcQ)
[![Linkedin Badge](https://img.shields.io/badge/-Guilherme_Figueiras_Maurila-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/guilherme-maurila)](https://www.linkedin.com/in/guilherme-maurila)
[![Gmail Badge](https://img.shields.io/badge/-gfmaurila@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:gfmaurila@gmail.com)](mailto:gfmaurila@gmail.com)

