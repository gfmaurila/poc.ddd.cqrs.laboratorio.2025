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
├── API.Gateway
│   └── Program.cs
├── API.Auth
│   └── Endpoints
│       └── ClinicsController.cs
├── Docker
│   └── docker-compose.yml
```

### **Descrição das Pastas**

- **API.Gateway/**: Contém o projeto de API Gateway usando YARP para gerenciar as rotas.
- **API.Auth/**: Contém os endpoints da API Auth.
- **Docker/**: Arquivos de configuração do Docker.

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

## 📌 **Endpoints Importantes**

### **API Gateway**

- **Swagger UI**: [http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html)

### **API.Auth**

- **GET /api/clinics**: Lista todas as clínicas.
- **POST /api/clinics**: Adiciona uma nova clínica.
- **PUT /api/clinics/{id}**: Atualiza os dados de uma clínica.
- **DELETE /api/clinics/{id}**: Remove uma clínica.

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
- **Acesso**: [http://localhost:9100/ui/clusters/local/all-topics](http://localhost:9100/ui/clusters/local/all-topics)

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


