### Migration: add

`dotnet ef --project ./ChatService.Persistence/ --startup-project ./ChatService.WebApi/ migrations add <MIGRATION_NAME>`

### Migration: apply

`dotnet ef database update --project ./ChatService.Persistence/ --startup-project ./ChatService.WebApi --verbose`

### Migration: list

`dotnet ef migrations list --project ./ChatService.Persistence/ --startup-project ./ChatService.WebApi`

### Migration: behavior rules 

```
Database.EnsureDeleted();
Database.EnsureCreated();
Database.Migrate();
```
