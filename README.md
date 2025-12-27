# NewsWeb 📰✨

Welcome to **NewsWeb** — a warm, polished, and easy-to-run ASP.NET Core MVC application for publishing news, managing categories/tags, and moderating comments. This repo includes a complete MVC front-end, an EF Core data layer, and a clean separation of entities and repositories.

If you’re looking for a delightful starting point for a news portal or editorial dashboard, you’re in the right place. Enjoy! 🌟

## Highlights

- **Modern ASP.NET Core MVC** web UI
- **Entity Framework Core** for data access
- **Admin features** for news, categories, tags, ads, and comments
- **Search, trending, and ads** baked into the public-facing pages
- **Safety hardening** with anti-forgery validation on all POST actions

## Project Structure

```
NewsWeb.sln
Endpoint/          # ASP.NET Core MVC UI
News.Data/         # Repository layer
News.EF/           # EF Core DbContext + migrations
News.Entittes/     # Domain entities
```

## Getting Started

### Prerequisites

- **.NET SDK 6+** (or a compatible version for the solution)
- **SQL Server** (LocalDB works great for local development)

### Configuration

Set the connection string in `Endpoint/appsettings.json` or via environment variables.

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=NewsWeb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

> 💡 You can also override this using environment variables, e.g.
> `ConnectionStrings__DefaultConnection`.

### Database Setup

Run EF Core migrations to create the database:

```bash
dotnet ef database update --project News.EF --startup-project Endpoint
```

### Run the App

```bash
dotnet run --project Endpoint
```

The site should now be available locally. 🚀

## Features at a Glance

- **Home page** with latest and trending news
- **Single news page** with comments
- **Admin panel** for managing content
- **Tags & categories** to keep articles discoverable
- **Ads** management in the admin dashboard

## Safety & Best Practices

- **Anti-forgery tokens** are applied to all POST forms and controller actions to protect against CSRF.
- **Connection strings** are pulled from configuration rather than hard-coded.

## Contributing

Contributions, bug reports, and suggestions are welcome. If you add features or fix issues, please include a clear description of the change and update documentation where appropriate.

## License

If this project needs a license file, feel free to add one that fits your use case.

---

Built with care, curiosity, and a dash of ✨. Enjoy shipping great news experiences!
