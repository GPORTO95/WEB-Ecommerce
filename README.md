## Projeto E-Commerce - Nerd Store

Projeto Open-Source feito em .NET Core

Foi baseado em um e-commerce de vendas, inicialmente feito apenas para camisetas e canecas.

## Tecnologias implementadas:
- ASP.NET 3.1
- ASP.NET MVC Core
- ASP.NET Identity Core
- Entity Framework Core 3.1
- Fluent Api
- FluentValidator
- AutoMapper
- MediatR

## Arquitetura:
- Arquitetura completa com questões de separação de responsabilidades, SOLID e Clean Code
- Domain Driven Design (Camadas e padrão de modelo de domínio)
- Domain Events
- Domain Notification
- Domain Validations
- CQRS (Consistência Imediata)
- Event Sourcing
- Unit of Work
- Repository
- XUnit para cobertura de testes

## Start
- Ter instalado o .net core 3.1 ou superior
- SQL Server - Rodar as migrations
- Instalar Envent Store
- Comando para executar o event store: Posicionar o cmd na pasta instalada e rodar o comando EventStore.ClusterNode.exe --config D:\ESDB\eventstore.conf
