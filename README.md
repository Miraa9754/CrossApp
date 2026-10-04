# CrossApp

Наскрізний проєкт з крос-платформного програмування.

## Предметна область

Предметна область: Склад.

Сутності:

- Product — товар
- StockBatch — партія товару
- Warehouse — склад
- Movement — переміщення

Призначення: облік залишків товарів по партіях.

## Запуск

Для збірки проєкту:

```bash
dotnet build
```

## Структура рішення

```text
CrossApp/
├── CrossApp.sln
├── README.md
├── .gitignore
└── src/
    ├── Core/
    │   ├── Core.csproj
    │   └── EnvironmentInfo.cs
    └── Cli/
        ├── Cli.csproj
        └── Program.cs
```
