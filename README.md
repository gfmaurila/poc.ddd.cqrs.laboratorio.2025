# 📘 Projeto: Micro SaaS

### **Tecnologias Utilizadas**

- **ASP.NET Core 9.0**: Framework utilizado para desenvolvimento da API.
- **YARP (Reverse Proxy)**: Gateway de entrada para gerenciar o roteamento de APIs.
- **SQL Server**: Banco de dados relacional para armazenar dados principais.
- **Redis**: Cache em memória para melhorar a performance.
- **MongoDB**: Banco de dados NoSQL para armazenamento de dados não relacionais.
- **RabbitMQ**: Broker de mensagens para comunicação assíncrona entre serviços.
- **Kafka**: Plataforma de streaming distribuída para manipulação de grandes volumes de dados em tempo real.
- **Kafka UI**: Interface web para monitoramento do Kafka.
- **Docker & Docker Compose**: Gerenciamento de containers para deploy simplificado.

---

## 📁 **Estrutura do Projeto**

```
📂 poc.micro-saas.netcore8
├── 📂 Documento
│   └── README.md
├── 📂 src
│   ├── 📂 API
│   │   ├── 📂 API.Exemple.Core.08
│   │   ├── 📂 API.Gateway
│   ├── 📂 Core
│   │   ├── 📂 Common.Core.08
│   │   ├── 📂 Common.External.Auth.Net8
│   ├── 📂 External
│   │   ├── 📂 API.External.Auth
│   │   │   ├── 📂 API.External.Auth
│   │   │   └── README.md
│   │   ├── 📂 API.External.Email
│   │   ├── 📂 API.External.MKT
│   ├── 📂 Test
├── 📄 docker-compose
```

### **API.Gateway**

- **API Gateway/**: Descrição: O API Gateway atua como a interface única para os usuários interagirem com os serviços internos. Ele roteia requisições para as APIs internas com base em regras definidas. [Documentação](https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/tree/main/src/API/API.Gateway)

- **API.Exemple.Core.08/**: API exemplo que serve como referência para a estrutura base e lógica de domínio. [Documentação](https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/tree/main/src/API/API.Exemple.Core.08)

- **API.Customer.Core.08/**: Responsável pela gestão de clientes, incluindo cadastro, atualização e consulta de informações. [Documentação](https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/tree/main/src/API/API.Customer.Core.08)

- **API.HR.Core.08/**: Focada em gerenciar os recursos humanos da organização, como funcionários e departamentos. [Documentação](https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/tree/main/src/API/API.HR.Core.08)

- **API.Freelancer.Core.08/**: Gerencia informações e contratos de freelancers. [Documentação](https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/tree/main/src/API/API.Freelancer.Core.08)

- **API.Clinic.Core.08/**: Centraliza a gestão de clínicas, incluindo agendamentos, pacientes e serviços oferecidos. [Documentação](https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/tree/main/src/API/API.Clinic.Core.08)

- **API.InventoryControl.Core.08/**:Voltada para o controle de estoque, gerenciamento de produtos e movimentações.  [Documentação](https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/tree/main/src/API/API.InventoryControl.Core.08)


### **External - Exemplos**

- **API.External.Auth/**:  [Documentação](https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/tree/main/src/External/API.External.Auth)
- **API.External.Email/**:  [Documentação](https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/tree/main/src/External/API.External.Email)
- **API.External.MKT/**:  [Documentação](https://github.com/gfmaurila/poc.ddd.cqrs.laboratorio.2025/tree/main/src/External/API.External.MKT)

---

## 🌐 **Configuração do Docker**

Para rodar o projeto completo com todos os serviços:

```bash
docker-compose down
docker-compose up -d --build
docker-compose up --build
Update-Database -Context MainContext 
```

### **Serviços Configurados no Docker Compose:**

- **SQL Server** (porta: `1433`)
- **Redis** (porta: `6379`)
- **MongoDB** (porta: `27017`)
- **RabbitMQ** (porta: `5672`)
- **Zookeeper** (porta: `2181`)
- **Kafka** (porta: `9092`)
- **Kafka UI** (porta: `8080`)

---

## 🔧 **Configurando o Projeto**

### Clone o repositório:

```bash
git clone https://github.com/gfmaurila/poc.ddd.cqrs.netcore9.git
```

---

## 📚 **Configurações de Banco de Dados**

### **SQL Server**

- **Host**: localhost
- **Porta**: 1433
- **Usuário**: sa
- **Senha**: Password!123

### **MongoDB**

- **Host**: localhost
- **Porta**: 27017
- **Database**: clinics\_db

### **Redis**

- **Host**: localhost
- **Porta**: 6379

---

## 📦 **Mensageria e Streaming**

### **RabbitMQ**

- **Host**: localhost
- **Porta**: 5672
- **Credenciais**:
  - **Usuário**: guest
  - **Senha**: guest
  - **Acesso**: [http://localhost:15672/#/](http://localhost:15672/#/)

### **Kafka**

- **Host**: localhost
- **Porta**: 9092

### **Kafka UI**

- **Host**: localhost
- **Porta**: 8080
- **Acesso**: [http://localhost:9100](http://localhost:9100)

---

## 📋 **Comandos SQL Importantes**

```bash
Add-Migration InitialCreate -Context AppDbContext
Update-Database -Context AppDbContext
```

---

## 🧑‍💻 **Autores**

- **Guilherme Figueiras Maurila**

---

## 📫 Como me encontrar
[![YouTube](https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white)](https://www.youtube.com/channel/UCjy19AugQHIhyE0Nv558jcQ)
[![Linkedin Badge](https://img.shields.io/badge/-Guilherme_Figueiras_Maurila-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/guilherme-maurila)](https://www.linkedin.com/in/guilherme-maurila)
[![Gmail Badge](https://img.shields.io/badge/-gfmaurila@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:gfmaurila@gmail.com)](mailto:gfmaurila@gmail.com)


