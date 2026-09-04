# Catteria ☕ - Sistema de Gestão de Cafeteria

## 📋 Visão Geral

**Catteria** é uma solução completa de gestão para cafeterias, desenvolvida em **.NET 10** com arquitetura em camadas (DDD - Domain-Driven Design). O sistema oferece uma plataforma web para gerenciamento de produtos, pedidos, categorias e cupons de desconto, com autenticação segura e envio de e-mails.

## 🎯 O que o Sistema Resolve

- ✅ **Gestão de Produtos**: Cadastro, edição e exclusão de itens do cardápio
- ✅ **Gestão de Categorias**: Organização de produtos por categoria
- ✅ **Gestão de Pedidos**: Criação, rastreamento e gerenciamento de pedidos
- ✅ **Sistema de Cupons**: Criação e aplicação de descontos
- ✅ **Carrinho de Compras**: Sessão temporária com expiração automática
- ✅ **Autenticação e Autorização**: Sistema seguro com ASP.NET Identity
- ✅ **Envio de E-mails**: Notificações automáticas via SMTP
- ✅ **API RESTful**: Endpoints para integração com terceiros

## 🏗️ Arquitetura da Solução

A solução segue uma arquitetura em **camadas** com 6 projetos principais:

Catteria (Solução) ├── Catteria.Domain              # Entidades e Interfaces (Núcleo) ├── Catteria.Application         # Serviços e Lógica de Negócio ├── Catteria.Infrastructure      # Repositórios, EF Core e Identidade ├── Catteria.UI                  # Aplicação Web (Razor Pages) ├── Catteria.API                 # API RESTful └── Catteria.Desktop (opcional)  # Aplicação Desktop

### 📦 Descrição das Camadas

| Projeto | Responsabilidade |
|---------|------------------|
| **Domain** | Define as entidades, interfaces de repositório e contratos de domínio |
| **Application** | Serviços de aplicação que orquestram a lógica de negócio |
| **Infrastructure** | Implementação de repositórios, contexto do banco de dados e serviços |
| **UI** | Interface web com Razor Pages para interação do usuário |
| **API** | Endpoints REST para consumo externo (Swagger/OpenAPI incluído) |

## 💻 Tecnologias Utilizadas

- **Framework**: .NET 10
- **Web Framework**: ASP.NET Core com Razor Pages
- **Banco de Dados**: SQL Server (LocalDB)
- **ORM**: Entity Framework Core 10.0.9
- **Autenticação**: ASP.NET Identity
- **E-mail**: SMTP (Gmail)
- **API Documentation**: Swagger/Swashbuckle
- **Segurança**: User Secrets para variáveis sensíveis

## 🚀 Instalação e Configuração

### ✅ Pré-requisitos

- Visual Studio 2026 (Community ou superior)
- .NET 10 SDK
- SQL Server Express ou LocalDB
- Git

### 📥 Passos de Instalação

#### 1. Clonar o Repositório
git clone https://github.com/devD4nielSouza/Catteria.git cd Catteria

#### 2. Abrir a Solução
Abrir no Visual Studio
start Catteria.slnx


#### 3. Configurar o Banco de Dados

Edite o arquivo `appsettings.json` em `Catteria.UI`:

{ "ConnectionStrings": { "DefaultConnection": "Server=(localdb)\MSSQLLocalDB;Database=CatteriaDb;Trusted_Connection=true;MultipleActiveResultSets=true" } }


#### 4. Aplicar Migrations (Criar Banco de Dados)

Abra o **Package Manager Console** no Visual Studio e execute:

Update-Database

Alternativamente, use a CLI do .NET:  dotnet ef database update --project Catteria.Infraestructure --startup-project Catteria.UI

#### 5. Configurar Envio de E-mails (Opcional)

Edite `appsettings.json`:

"Email": { "From": "seu-email@gmail.com", "Host": "smtp.gmail.com", "Port": "587", "User": "seu-email@gmail.com", "Password": "sua-senha-de-app" }

**Criar Pasta de Chaves de Proteção de Dados:**

New-Item -ItemType Directory -Path "C:\Catteria\dp-keys" -Force


#### 6. Executar a Aplicação

Via Visual Studio: pressione F5 ou Ctrl+F5
Ou via CLI:
dotnet run --project Catteria.UI


A aplicação estará disponível em: `https://localhost:7000` (ou a porta configurada)

## 📱 Utilizando a Solução

### Acessar a Aplicação Web (UI)
https://localhost:7000

- Criar conta → Fazer login → Gerenciar produtos/pedidos

### Acessar a API
https://localhost:5000

- Documentação: `https://localhost:5000/swagger`
- Endpoints disponíveis para integração

### Funcionalidades Principais

**1. Autenticação**
- Registro de novo usuário
- Login com segurança (cookies criptografados)
- Logout

**2. Produtos**
- Listar todos os produtos
- Filtrar por categoria
- Adicionar ao carrinho

**3. Pedidos**
- Criar pedido a partir do carrinho
- Rastrear pedidos
- Histórico de compras

**4. Cupons**
- Gerar códigos de desconto
- Aplicar cupons em pedidos

**5. Carrinho**
- Sessão temporária (expira em 30 minutos)
- Atualizar quantidades
- Remover itens

## 🔐 Seguranças Implementadas

- ✅ Autenticação ASP.NET Identity
- ✅ Criptografia de Cookies
- ✅ Data Protection (chaves armazenadas)
- ✅ Validações de Entrada
- ✅ Senha com requisitos: Letra maiúscula, minúscula, número e caractere especial (mínimo 6 caracteres)
- ✅ Sessão com timeout (30 minutos)

## 📊 Estrutura do Banco de Dados

Principais entidades:

- **Users**: Usuários do sistema
- **Products**: Produtos do cardápio
- **Categories**: Categorias de produtos
- **Orders**: Pedidos dos clientes
- **OrderItems**: Itens dentro de um pedido
- **Cupons**: Cupons de desconto

## 🛠️ Desenvolvimento e Contribuição

### Criar uma Nova Migration
Add-Migration NomedaMigration -Project Catteria.Infraestructure Update-Database


### Rodar Testes (se existentes)
dotnet test


### Push para o GitHub
git add . git commit -m "descrição das mudanças" git push origin main


## 🚨 Troubleshooting

### Erro: "Cannot open database 'CatteriaDb'"
**Solução**: Criar o banco com `Update-Database`

### Erro de Conexão com E-mail
**Solução**: Verificar `appsettings.json` e credenciais Gmail (usar App Password)

### Erro de Data Protection
**Solução**: Garantir que a pasta `C:\Catteria\dp-keys` existe e tem permissões

### Porta já em uso
**Solução**: Alterar em `launchSettings.json`

## 📝 Variáveis de Ambiente (User Secrets)

Para produção, use secrets seguros:
dotnet user-secrets init --project Catteria.API dotnet user-secrets set "Email:Password" "sua-senha-secreta" --project Catteria.API


## 📞 Suporte e Contato

- **GitHub**: https://github.com/devD4nielSouza/Catteria
- **Branch**: `main`
- **Versão .NET**: 10.0

## 📄 Licença

Este projeto é fornecido como está. Verifique o repositório para informações de licença.

---

**Última atualização**: Setembro de 2026  
**Versão**: 1.0.0