# 📦 EstoqueAPI - Sistema de Gestão de Inventário

![.NET 9.0](https://img.shields.io/badge/.NET-9.0-512bd4?style=for-the-badge&logo=dotnet)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169e1?style=for-the-badge&logo=postgresql&logoColor=white)
![Entity Framework](https://img.shields.io/badge/EF%20Core-512bd4?style=for-the-badge&logo=dotnet)

Uma API robusta para controle de estoque, desenvolvida com foco em **Programação Orientada a Objetos (POO)** e persistência de dados em banco relacional.

---

## 🚀 Sobre o Projeto

O **EstoqueAPI** foi criado para gerenciar não apenas produtos, mas toda a cadeia de suprimentos, desde o cadastro de fornecedores até o histórico detalhado de movimentações (entradas e saídas).

### 🛠️ Funcionalidades Principais

* **Gestão de Fornecedores:** Cadastro com validação de CNPJ (armazenado como `string` para manter a integridade de zeros à esquerda).
* **Controle de Produtos:** Gerenciamento de itens com preços em `decimal` para precisão monetária.
* **Histórico de Movimentações:** Registro automático de data e tipo de operação (Entrada/Saída) para cada alteração de estoque.
* **Persistência em Nuvem:** Integração com banco de dados **PostgreSQL** (via Neon DB).

---

## 🏗️ Arquitetura de Dados (Models)

O coração da aplicação é composto por três entidades principais interconectadas:

1. **Produto (`ProdutoModel`):** Possui `ProdutoId`, `Descricao`, `Quantidade` e `Preco`. Relaciona-se com um fornecedor.
2. **Fornecedor (`FornecedorModel`):** Identificado por `CNPJ` e `Descricao`. Possui uma lista de produtos vinculados.
3. **Movimentação (`MovimentacaoModel`):** Registra o `Tipo` da movimentação, a `Quantidade` alterada e o `DateTime` exato da transação.


---

## 💻 Tecnologias Utilizadas

* **Linguagem:** C#
* **Framework:** ASP.NET Core / .NET 9.0
* **ORM:** Entity Framework Core (EF Core)
* **Banco de Dados:** PostgreSQL
* **Ambiente de Desenvolvimento:** Visual Studio

---

## ⚙️ Como Executar

1. Clone o repositório:
   ```bash
   git clone [https://github.com/mayarabnCabral/Estoque.git](https://github.com/mayarabnCabral/Estoque.git)
