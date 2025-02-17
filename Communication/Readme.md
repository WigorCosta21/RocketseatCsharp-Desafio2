# 📚 Bookstore API

## 📖 Descrição

Esta API foi desenvolvida para gerenciar uma livraria online, permitindo operações CRUD (Create, Read, Update e Delete) sobre livros.

## 🚀 Funcionalidades

- Criar um novo livro.
- Visualizar todos os livros cadastrados.
- Visualizar um livro específico pelo ID.
- Atualizar informações de um livro.
- Excluir um livro.

## 📌 Requisitos

Cada livro deve conter os seguintes atributos:
- **ID**: Identificador único.
- **Título**: Nome do livro.
- **Autor**: Nome do autor.
- **Gênero**: Lista de gêneros (ex: ficção, romance, mistério).
- **Preço**: Valor do livro.
- **Quantidade em estoque**: Número de exemplares disponíveis.

## 📡 Rotas da API

### Criar um novo livro
`POST /api/book`

**Exemplo de Request:**
```json
{
  "id": 1,
  "title": "Dom Casmurro",
  "author": "Machado de Assis",
  "gender": ["Romance", "Ficção"],
  "price": 39.90,
  "quantity": 10
}
```

**Respostas:**
- `201 Created` - Livro criado com sucesso.
- `400 Bad Request` - ID ou título já existente, quantidade negativa ou preço inválido.

---

### Obter todos os livros
`GET /api/book`

**Respostas:**
- `200 OK` - Retorna a lista de livros cadastrados.
- `204 No Content` - Nenhum livro encontrado.

---

### Obter um livro pelo ID
`GET /api/book/{id}`

**Respostas:**
- `200 OK` - Retorna o livro correspondente ao ID.
- `404 Not Found` - Livro não encontrado.

---

### Atualizar um livro
`PUT /api/book/{id}`

**Exemplo de Request:**
```json
{
  "title": "Memórias Póstumas de Brás Cubas",
  "author": "Machado de Assis",
  "gender": ["Romance", "Clássico"],
  "price": 45.00,
  "quantity": 5
}
```

**Respostas:**
- `200 OK` - Livro atualizado com sucesso.
- `404 Not Found` - Livro não encontrado.

---

### Excluir um livro
`DELETE /api/book/{id}`

**Respostas:**
- `200 OK` - Livro excluído com sucesso.
- `404 Not Found` - Livro não encontrado.

## 🛠 Tecnologias Utilizadas
- .NET Core
- C#
- ASP.NET Core Web API

## 🏗 Como Executar o Projeto

1. Clone este repositório:
```sh
git clone https://github.com/seu-usuario/bookstore-api.git
```

2. Navegue até o diretório do projeto:
```sh
cd bookstore-api
```

3. Execute o projeto:
```sh
dotnet run
```


