# WebApiStore

API em .NET 6 desmonstrando produtos, compras e usuários.

## Aplicação consiste nas seguintes camadas ↓

- Application: Controllers e Autenticação JWT.
- Service: DTOs, Mappers, Serviços e validações de negócio.
- Domain: Entidades, contratos para os Repositórios e validações do domínio.
- Infra Data: Token, Context, Modelo das Entidades e os Repositório.
- Infra CrossCutting: IoC.