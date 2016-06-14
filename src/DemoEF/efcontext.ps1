param([String]$Database, [String]$Server="192.168.1.57", [String]$Username="userdeploydev", [String]$Password="D3pl0yD3v")

remove-item ".\Models\DataModel"
dotnet ef dbcontext scaffold "Data Source=$Server;Initial Catalog=$Database;user id=$Username;password=$Password;" -f -o "Models\DataModel" Microsoft.EntityFrameworkCore.SqlServer 