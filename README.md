# 📦 EstoqueAPI — Sistema de Gestão de Inventário

![.NET 9.0](https://img.shields.io/badge/.NET-9.0-512bd4?style=for-the-badge&logo=dotnet)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169e1?style=for-the-badge&logo=postgresql&logoColor=white)
![Entity Framework](https://img.shields.io/badge/EF%20Core-512bd4?style=for-the-badge&logo=dotnet)

API RESTful desenvolvida para gestão de estoque, com foco em boas práticas de **Programação Orientada a Objetos (POO)**, organização de código e persistência em banco de dados relacional.

---

## 🚀 Sobre o Projeto

O **EstoqueAPI** foi criado para gerenciar de forma estruturada produtos, fornecedores e movimentações de estoque, permitindo um controle preciso de entradas e saídas.

O projeto demonstra domínio em desenvolvimento de APIs com **ASP.NET Core**, mapeamento objeto-relacional com **Entity Framework Core** e integração com **PostgreSQL**.

---

## 🛠️ Funcionalidades

* **Gestão de Fornecedores**
    * Cadastro e listagem de fornecedores.
    * Tratamento de CNPJ como string para preservação de formatação.
* **Gestão de Produtos**
    * Vínculo obrigatório com fornecedores.
    * Controle dinâmico de quantidade em estoque.
    * Uso de tipo `decimal` para precisão em valores monetários.
* **Movimentação de Estoque**
    * Registro de entradas e saídas.
    * Histórico detalhado com `DateTime`.
    * Classificação por tipo de movimentação.

---

## 🏗️ Modelagem de Dados

A aplicação utiliza o relacionamento entre três entidades principais:

### 📦 Produto (`ProdutoModel`)
* `ProdutoId`, `Descricao`, `Quantidade`, `Preco`.
* Relacionamento N:1 com Fornecedor.

### 🏭 Fornecedor (`FornecedorModel`)
* `FornecedorId`, `CNPJ`, `Descricao`.
* Lista de produtos associados.

### 🔄 Movimentação (`MovimentacaoModel`)
* `MovimentacaoId`, `TipoMovimentacao`, `Quantidade`, `DataMovimentacao`.
* Relacionamento com Produto.

---

## 💻 Tecnologias Utilizadas

* **Linguagem:** C#
* **Framework:** ASP.NET Core (.NET 9.0)
* **ORM:** Entity Framework Core
* **Banco de Dados:** PostgreSQL (Neon DB)
* **Ferramentas de Teste:** Postman
* **IDE:** Visual Studio

---

## ⚙️ Como Executar o Projeto

### Pré-requisitos
* .NET SDK 9.0
* PostgreSQL (Local ou Cloud)
* Visual Studio ou VS Code

### Passos
1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/mayarabnCabral/Estoque.git](https://github.com/mayarabnCabral/Estoque.git)
    ```
2.  **Acesse a pasta do projeto:**
    ```bash
    cd Estoque
    ```
3.  **Configure a string de conexão** no arquivo `appsettings.json`:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Host=seu_host;Database=seu_db;Username=seu_user;Password=sua_senha"
    }
    ```
4.  **Execute as migrations** para criar as tabelas:
    ```bash
    dotnet ef database update
    ```
5.  **Inicie a aplicação:**
    ```bash
    dotnet run
    ```

---

## 🧪 Testes da API

Os endpoints podem ser testados via Postman ou Insomnia. 

**Exemplos de Rotas:**
* `GET /api/produtos` - Lista todos os produtos.
* `POST /api/fornecedores` - Cadastra um novo fornecedor.
* `POST /api/movimentacoes` - Registra entrada ou saída de itens.

> **Nota:** O projeto foca na estrutura da API e lógica de negócio, priorizando testes via cliente HTTP.

---

## 👩‍💻 Autora

**Mayara Cabral** [GitHub](https://github.com/mayarabnCabral) | [LinkedIn](SEU_LINK_DO_LINKEDIN_AQUI)
