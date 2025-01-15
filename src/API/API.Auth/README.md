# 📘 Projeto: API.Auth - Sistema de Autenticação e Autorização

### **Tecnologias Utilizadas**

- **ASP.NET Core 9.0**: Framework utilizado para desenvolvimento da API.
- **Entity Framework Core**: ORM para comunicação com o banco de dados SQL Server.
- **SQL Server**: Banco de dados relacional.
- **Redis**: Utilizado para cache de tokens e gerenciamento de sessão.
- **JWT (JSON Web Token)**: Utilizado para autenticação baseada em tokens.
- **Docker & Docker Compose**: Gerenciamento de containers para deploy simplificado.

---

## 📁 **Estrutura do Projeto**

```
├── API.Auth
│   ├── Controllers
│   │   └── AuthController.cs
│   ├── Services
│   │   └── UserService.cs
│   ├── Repositories
│   │   └── UserRepository.cs
│   ├── Models
│   │   └── User.cs
│   ├── DTOs
│   │   └── LoginRequest.cs
│   ├── Configurations
│   │   └── JwtSettings.cs
├── Infrastructure
│   └── Database
│       └── AuthDbContext.cs
├── Extensions
│   └── ServiceExtensions.cs
├── Docker
│   └── docker-compose.yml
```

### **Descrição das Pastas**

- **API.Auth/**: Contém a lógica da API de autenticação e autorização.
  - **Controllers/**: Contém os controladores da API.
  - **Services/**: Contém os serviços responsáveis pelas regras de negócio.
  - **Repositories/**: Contém os repositórios para manipulação dos dados no banco.
  - **Models/**: Contém os modelos de domínio.
  - **DTOs/**: Contém os objetos de transferência de dados.
  - **Configurations/**: Contém as configurações de JWT e outras definições.

- **Infrastructure/**: Configurações do banco de dados e contexto do Entity Framework.
- **Extensions/**: Métodos de extensão para configuração de serviços.
- **Docker/**: Arquivos de configuração do Docker.

---

## 🌐 **Configuração do Docker**

Para rodar o projeto completo com todos os serviços:

```bash
docker-compose up --build
```

### **Serviços Configurados no Docker Compose:**
- **SQL Server** (porta: `1433`)
- **Redis** (porta: `6379`)

---

## 🔧 **Configurando o Projeto**

### Clone o repositório:
```bash
git clone https://github.com/gfmaurila/api-auth.git
```

### Acesse a pasta do projeto:
```bash
cd api-auth
```

### Rodando a aplicação com Docker:
```bash
docker-compose up --build
```

---

## 📌 **Endpoints Importantes**

### **Autenticação**
- **POST /api/auth/login**: Realiza login e retorna o token JWT.
  - **Body**:
    ```json
    {
      "username": "example",
      "password": "password123"
    }
    ```

- **POST /api/auth/register**: Registra um novo usuário.
  - **Body**:
    ```json
    {
      "username": "example",
      "email": "example@example.com",
      "password": "password123"
    }
    ```

- **GET /api/auth/me**: Retorna os dados do usuário autenticado.
  - **Header**:
    ```
    Authorization: Bearer {token}
    ```

---

## 📚 **Configurações de Banco de Dados**

### **SQL Server**
- **Host**: localhost
- **Porta**: 1433
- **Usuário**: sa
- **Senha**: Password!123

### **Redis**
- **Host**: localhost
- **Porta**: 6379

---

## 🔐 **Configurações de Autenticação JWT**

### **JwtSettings.cs**
```csharp
public class JwtSettings
{
    public string Secret { get; set; }
    public int ExpirationMinutes { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
}
```

### Configurar no **appsettings.json**:
```json
"JwtSettings": {
  "Secret": "minha-chave-secreta",
  "ExpirationMinutes": 60,
  "Issuer": "api-auth",
  "Audience": "api-users"
}
```

---

## 📦 **Comandos Importantes**

### Criar Migration e Atualizar Banco de Dados
```bash
dotnet ef migrations add InitialCreate -Context AuthDbContext
dotnet ef database update -Context AuthDbContext
```

### Gerar Secret Key para JWT
```bash
openssl rand -base64 32
```

---

## 🧑‍💻 **Autores**
- **Guilherme Figueiras Maurila**

---

## 📫 **Como me encontrar**
[![Linkedin Badge](https://img.shields.io/badge/-Guilherme_Figueiras_Maurila-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/guilherme-maurila)](https://www.linkedin.com/in/guilherme-maurila)
[![Gmail Badge](https://img.shields.io/badge/-gfmaurila@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:gfmaurila@gmail.com)](mailto:gfmaurila@gmail.com)

