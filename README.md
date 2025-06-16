# ToDo API - .NET 8

## Como executar

1. Requisitos:
   - .NET 8 SDK
   - Docker (opcional para deploy)

2. Comandos:
```
dotnet restore
dotnet run
```

3. Acessar Swagger:
https://localhost:5001/swagger

## Endpoints

- GET /api/tarefas
- GET /api/tarefas/{id}
- POST /api/tarefas
- PUT /api/tarefas/{id}
- DELETE /api/tarefas/{id}

## Docker
```
docker build -t todoapi .
docker run -d -p 5000:80 todoapi
```
*/
