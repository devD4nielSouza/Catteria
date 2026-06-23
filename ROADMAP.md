```md
# ROADMAP — CATTERIA

> Guia passo a passo para desenvolver a solução Catteria, uma cafeteria temática com gatos, sistema próprio de delivery e painel administrativo.  
> Voltado para alunos iniciantes em ASP.NET Core MVC, Entity Framework Core e Arquitetura em Camadas.

---

## Índice

1. [Entendendo a Arquitetura](#1-entendendo-a-arquitetura)
2. [Criação da Solution](#2-criação-da-solution)
3. [Criação das Camadas](#3-criação-das-camadas)
4. [Referências entre Projetos](#4-referências-entre-projetos)
5. [Instalação dos Pacotes NuGet](#5-instalação-dos-pacotes-nuget)
6. [Camada Domain](#6-camada-domain)
7. [Camada Application](#7-camada-application)
8. [Camada Infrastructure](#8-camada-infrastructure)
9. [Entity Framework — Migrations](#9-entity-framework--migrations)
10. [Identity — Autenticação](#10-identity--autenticação)
11. [Projeto API](#11-projeto-api)
12. [Sistema de Pedidos e Carrinho](#12-sistema-de-pedidos-e-carrinho)
13. [Projeto UI (MVC)](#13-projeto-ui-mvc)
14. [Painel Administrativo](#14-painel-administrativo)
15. [Front-End e Design](#15-front-end-e-design)
16. [Executando a Aplicação](#16-executando-a-aplicação)
17. [Resumo Final](#17-resumo-final)

---

## 1. Entendendo a Arquitetura

### Por que usar camadas?

A arquitetura em camadas separa o código em projetos com responsabilidades específicas.

### Benefícios

- Organização
- Manutenção
- Escalabilidade
- Reutilização
- Testabilidade

### Estrutura da Solução
```

┌──────────────┐ ┌──────────────┐
│ Catteria.API │ │ Catteria.UI │
│ (API REST) │ │ (MVC) │
└───────┬──────┘ └───────┬──────┘
│ │
└─────────┬────────┘
│
┌──────────▼──────────┐
│ Catteria.Application │
│ Services / DTOs │
└──────────┬──────────┘
│
┌──────────▼──────────┐
│ Catteria.Domain │
│ Entidades │
└──────────▲──────────┘
│
┌──────────┴──────────┐
│ Catteria.Infrastructure │
│ EF Core / Banco │
└─────────────────────┘

````

---

## 2. Criação da Solution

### O que é uma Solution?

Uma Solution (.sln) agrupa todos os projetos da aplicação.

### Via terminal

```bash
mkdir Catteria
cd Catteria
dotnet new sln -n Catteria
````

---

## 3. Criação das Camadas

### Domain

```bash
dotnet new classlib -n Catteria.Domain
dotnet sln add Catteria.Domain
```

### Application

```bash
dotnet new classlib -n Catteria.Application
dotnet sln add Catteria.Application
```

### Infrastructure

```bash
dotnet new classlib -n Catteria.Infrastructure
dotnet sln add Catteria.Infrastructure
```

### API

```bash
dotnet new webapi -n Catteria.API
dotnet sln add Catteria.API
```

### MVC UI

```bash
dotnet new mvc -n Catteria.UI
dotnet sln add Catteria.UI
```

---

## 4. Referências entre Projetos

```
Application → Domain
Infrastructure → Domain + Application
API → Application + Infrastructure
UI → Application + Infrastructure
```

```bash
dotnet add Catteria.Application reference Catteria.Domain

dotnet add Catteria.Infrastructure reference Catteria.Domain
dotnet add Catteria.Infrastructure reference Catteria.Application

dotnet add Catteria.API reference Catteria.Application
dotnet add Catteria.API reference Catteria.Infrastructure

dotnet add Catteria.UI reference Catteria.Application
dotnet add Catteria.UI reference Catteria.Infrastructure
```

---

## 5. Instalação dos Pacotes NuGet

### Infrastructure

```bash
dotnet add Catteria.Infrastructure package Microsoft.EntityFrameworkCore
dotnet add Catteria.Infrastructure package Microsoft.EntityFrameworkCore.SqlServer
dotnet add Catteria.Infrastructure package Microsoft.EntityFrameworkCore.Tools
dotnet add Catteria.Infrastructure package Microsoft.AspNetCore.Identity.EntityFrameworkCore
```

### API

```bash
dotnet add Catteria.API package Swashbuckle.AspNetCore
dotnet add Catteria.API package Microsoft.EntityFrameworkCore.Design
```

### UI

```bash
dotnet add Catteria.UI package Microsoft.EntityFrameworkCore.Design
```

---

## 6. Camada Domain

### Estrutura

```
Catteria.Domain
├── Entities
└── Interfaces
```

### Entidades principais

- Product
- Category
- Order
- OrderItem
- Cart
- CartItem
- User (a implementar)

### Interfaces

- IProductRepository
- ICategoryRepository
- IOrderRepository
- ICartRepository
- IUserRepository (a implementar)

---

## 7. Camada Application

### Estrutura

```
DTOs
Interfaces
Services
ViewModels
```

### Status

- ProductService ✔
- CategoryService ✔
- OrderService ✔
- CartService (a implementar)
- UserService (a implementar)
- AuthService (a implementar)

---

## 8. Camada Infrastructure

### Status atual

- DbContext ✔
- ProductRepository ✔
- CategoryRepository ✔
- OrderRepository ✔
- CartRepository ✔

### Falta

- OrderConfiguration (a implementar)
- CartConfiguration (a implementar)
- UserConfiguration (a implementar)

---

## 9. Entity Framework — Migrations

```bash
dotnet ef migrations add InitialCreate -p Catteria.Infrastructure -s Catteria.API
dotnet ef database update -p Catteria.Infrastructure -s Catteria.API
```

---

## 10. Identity — Autenticação

### Implementar

- Registro (a implementar)
- Login (a implementar)
- Logout (a implementar)
- Roles (a implementar)

### Roles

- Admin
- Customer

---

## 11. Projeto API

### Controllers

- ProductController (a implementar)
- CategoryController (a implementar)
- OrderController (a implementar)
- CartController (a implementar)
- AuthController (a implementar)

---

## 12. Sistema de Pedidos e Carrinho

### Carrinho

- Adicionar item (a implementar)
- Remover item (a implementar)
- Atualizar quantidade (a implementar)

### Pedido

- Criar Order (a implementar)
- Criar OrderItems (a implementar)
- Checkout (a implementar)

---

## 13. Projeto UI (MVC)

### Controllers

- HomeController ✔
- ProductController (a implementar)
- CartController (a implementar)
- AccountController (a implementar)
- AdminController (a implementar)

---

## 14. Painel Administrativo

- Dashboard (a implementar)
- CRUD Produtos (a implementar)
- CRUD Categorias (a implementar)
- Gerenciar pedidos (a implementar)

---

## 15. Front-End e Design

### Home

- Banner (a implementar)
- Produtos destaque (a implementar)
- Espaço gatos (a implementar)

### Estilo

- Clean
- Moderno
- Aconchegante

---

## 16. Executando a Aplicação

```bash
dotnet run --project Catteria.API
dotnet run --project Catteria.UI
```

---

## 17. Resumo Final

### Backend

- Domain ✔
- Application (em progresso)
- Infrastructure (em progresso)

### Sistema

- Carrinho (pendente)
- Pedidos (pendente)
- Login (pendente)

### Frontend

- MVC (pendente)
- Admin (pendente)
- Design (pendente)

---

## Prioridade Máxima

1. Services
2. Migrations
3. Identity
4. API
5. Carrinho
6. Pedidos
7. MVC
8. Admin
9. Design

```

```
