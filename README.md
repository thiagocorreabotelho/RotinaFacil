# RotinaFacil 📎

A RotinaFácil é uma API projetada para simplificar a organização das tarefas diárias. Nosso propósito é oferecer uma solução completa para facilitar o controle das rotinas de cuidados com animais de estimação, gerenciamento de medicamentos e o registro das últimas consultas veterinárias.

Além disso, a RotinaFácil inclui uma funcionalidade abrangente para o controle de despesas pessoais. Nosso objetivo é fornecer uma plataforma que atenda a todas as suas necessidades cotidianas de maneira eficiente. Se você achar útil, sinta-se à vontade para contribuir e fazer parte dessa comunidade.

 ## 🧑🏻‍💻Tecnologias
### API .NET 7
- Entity Framework Core: Para mapeamento objeto-relacional e gerenciamento de conexão ao banco de dados.
- ASP.NET Identity: Para autenticação e gerenciamento de usuários.
- AutoMapper: Para mapeamento entre os objetos de domínio e os objetos DTO.
- Injeção de Dependência Nativa: Para melhor gerenciamento e controle das dependências do projeto.

 ### BANCO DE DADOS SQL SERVER

 ## 🧪 Teste unitários
 No âmbito deste projeto, é importante destacar que implementamos uma abordagem sólida em relação à qualidade do código. Para o back-end, que é desenvolvido em .NET, estabelecemos a prática de realizar testes unitários abrangentes. Esses testes desempenham um papel fundamental na garantia da robustez e confiabilidade do nosso sistema, contribuindo para uma experiência de usuário aprimorada e um software de alta qualidade.

 ## 📝 Funcionalidades 
 - Cadastro de sexo.
 - Gerenciamento de pessoas.

## 🗂️ Estrutura
### 01 - Domain
- Entities: Entidades do domínio.
- Interfaces: Contratos para os repositórios.

### 02 - Infrastructure
* RotinaFacil.Infra.Data
    * Configurations: Configurações de infraestrutura, como mapeamento objeto-relacional.
    * Contexts: Contextos do Entity Framework Core.
    * Migrations: Migrações do banco de dados geradas pelo Entity Framework Core.
    * Migrations: Migrações do banco de dados geradas pelo Entity Framework Core.
 
* RotinaFacil.Infra.CrossCutting
   * DependencyInjection: Configuração de DI da estrutura na API.
 
### 03 - Application
* RotinaFacil.Application
   *  DTOs: Data Transfer Objects usados para passar dados entre camadas.
   *  Interfaces: Contratos para os serviços.
   *  Services: Contém a lógica de negócios de alto nível e chama métodos do repositório.
   *  Helpers: Contém validações do DTO e processos.
   *  Mapping: Configuração do mapeamento entre os objetos.
 
### 04 - Apresentation
* RotinaFacil.Presentation.WebAPI
   * Controllers: Controladores da API, responsáveis por receber requisições e enviar respostas.
   * Properties: Configurações de propriedade da API.  

## ⚖️ Licença
Este projeto é disponibilizado sob a licença MIT License. Essa licença permite o uso, a cópia, a modificação e a distribuição do código-fonte para fins não comerciais, desde que a atribuição seja feita ao autor original.
