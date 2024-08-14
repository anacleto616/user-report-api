# Relatório de Usuários

## Pré-requisitos a instalar

1. **.NET SDK**  
2. **EF Core**
3. **Docker**  
4. **Docker Compose**  
5. **Git**
   
## Como executar

Abra o terminal na pasta de sua preferẽncia e execute:

- `git clone https://github.com/anacleto616/user-report-api.git`
- `cd user-report-api`
- `docker compose -f infra/compose.yaml up -d`
- `dotnet clean`
- `dotnet restore`
- `dotnet ef migrations add InitialCreate --output-dir Migrations --project UserReport.Persistence --startup-project UserReport.API`
- `cd UserReport.API`
- `dotnet run`
- Abra o arquivo `index.html` da pasta `user-report-web` no seu navegador após ter salvo os dados no banco de dados.


## Observações

- Tive problemas ao montar o mapeamento das classes com o corpo do json que vem da API Random User, pois o campo Id dava conflito com o Entity Framework Core, e isso por vezes ocorre problemas ao iniciar o app e não conseguir salvar muitos usuários.

