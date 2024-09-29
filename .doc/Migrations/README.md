### Migration: add

`dotnet ef --project ./Chat.Persistence/ --startup-project ./Chat.WebApi/ migrations add <MIGRATION_NAME>`

### Migration: apply

`dotnet ef database update --project ./Chat.Persistence/ --startup-project ./Chat.WebApi --verbose`

### Migration: list

`dotnet ef migrations list --project ./Chat.Persistence/ --startup-project ./Chat.WebApi`

### Migration: behavior rules 

```
Database.EnsureDeleted();
Database.EnsureCreated();
Database.Migrate();
```
