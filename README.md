## **Resumo do Projeto**

### **Objetivo**

O projeto tem como objetivo criar um sistema de gerenciamento de compradores para uma loja, permitindo listar, adicionar e editar compradores através de uma interface web. O backend é implementado em C# .NET e o frontend utiliza React.

### **Backend (C# .NET)**

#### **1. Modelos e Data Context**

- **Modelos**: Representam a estrutura dos dados. O modelo `Buyer` inclui campos como nome, e-mail, telefone, tipo de pessoa, CPF/CNPJ, etc.
- **Data Context**: `BuyerDbContext` configura a conexão com o banco de dados e mapeia o modelo `Buyer`.

#### **2. Repositório**

- **Interface**: `IBuyerRepository` define métodos para operações CRUD.
- **Implementação**: `BuyerRepository` implementa os métodos para acessar e manipular dados no banco.

#### **3. DTOs (Data Transfer Objects)**

- **`BuyerDto`**: Utilizado para transferir dados entre a API e o frontend, separando a lógica de dados da representação na UI.

#### **4. AutoMapper**

- **`AutoMapperProfile`**: Configura o mapeamento entre o modelo `Buyer` e o `BuyerDto`, facilitando a conversão entre as camadas.

#### **5. Serviço**

- **Interface**: `IBuyerService` define a lógica de negócios para operações relacionadas a compradores.
- **Implementação**: `BuyerService` realiza a lógica de negócios e validações.

#### **6. Controlador**

- **`BuyersController`**: Expõe as APIs RESTful para listar, criar, atualizar e buscar compradores. Utiliza os serviços e DTOs para processar requisições e respostas.

#### **7. Configuração do `Program.cs`**

- Configura os serviços necessários, incluindo o AutoMapper e o contexto do banco de dados.

### **Frontend (React)**

#### **1. Configuração do Projeto**

- **Criação**: Utiliza o Create React App para iniciar o projeto.
- **Dependências**: `axios` para requisições HTTP e `react-router-dom` para gerenciamento de rotas.

#### **2. Estrutura de Pastas**

- **`components/`**: Contém componentes React, como `BuyerList` para exibir a lista de compradores e `BuyerForm` para adicionar/editar compradores.
- **`services/`**: Contém funções para interagir com a API, como buscar, criar e atualizar compradores.

#### **3. Roteamento**

- **`App.js`**: Configura as rotas usando `react-router-dom` para navegar entre a lista de compradores e o formulário de cadastro/edição.

#### **4. Componente `BuyerList`**

- **Funcionalidade**: Exibe a lista de compradores com a opção de pesquisa, filtragem, paginação e navegação para o formulário de edição.

#### **5. Componente `BuyerForm`**

- **Funcionalidade**: Permite adicionar um novo comprador ou editar um existente. Inclui campos obrigatórios e validações, além de lógica para lidar com diferentes tipos de compradores (pessoa física e jurídica).

#### **6. Configuração do `index.js`**

- **Renderização**: Configura o ponto de entrada da aplicação React, envolvido pelo `BrowserRouter` para habilitar o roteamento.

### **Conclusão**

Este projeto oferece uma solução completa para o gerenciamento de compradores em uma loja, abrangendo:

- **Backend robusto** com C# .NET, incluindo modelos, repositórios, serviços e APIs RESTful.
- **Frontend interativo** com React, que permite a visualização, criação e edição de compradores.
- **Integração** entre frontend e backend usando AutoMapper para mapeamento de dados e Axios para comunicação HTTP.

Esse sistema proporciona uma maneira eficiente e escalável de gerenciar os dados dos compradores, com uma interface amigável e uma arquitetura sólida.