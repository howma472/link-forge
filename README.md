# LinkForge Service

Простой сервис для сокращения ссылок, разработанный на **ASP.NET Core**.
Позволяет создавать короткие ссылки и выполнять редирект на оригинальный URL.

---

## Стек технологий

* ASP.NET Core
* Entity Framework Core
* MariaDB / MySQL
* Docker Compose
* Razor / MVC

---

## Функциональность

* создание коротких ссылок
* редирект по короткой ссылке
* хранение ссылок в базе данных
* простая веб-страница для работы со ссылками

---

## Настройка строки подключения

Откройте файл **appsettings.json** и измените строку подключения в разделе `ConnectionStrings`.

Пример:

```json
{
  "ConnectionStrings": {
    "mariadb": "server=localhost;port=3306;database=linkforge;user=YOUR_USERNAME;password=YOUR_PASSWORD;"
  }
}
```

Укажите свои значения:

* `YOUR_USERNAME` — пользователь
* `YOUR_PASSWORD` — пароль

---

## Запуск базы данных

Перед запуском приложения необходимо запустить контейнер базы данных:

```bash
docker compose up -d
```

---

## Запуск приложения

В папке проекта выполните:

```bash
dotnet run
```

---

## Открыть приложение

После запуска сервис будет доступен по адресу:

```
https://localhost:7261/Link/Index
```

---
