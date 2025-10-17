markdown
# DND API - Docker Makefile Commands

Этот проект использует Makefile для упрощения работы с Docker контейнерами.

## 🚀 Основные команды

### Инициализация и запуск
```bash
make init      # Сборка и запуск в фоне + просмотр логов
make build     # Сборка образов
make up        # Запуск контейнеров в фоне
make dev       # Запуск development окружения
```
Остановка и логи
```bash
make down      # Остановка всех контейнеров
make logs      # Просмотр логов основного API
make dev-logs  # Просмотр логов development API
```
🔄 Команды для разработки
Быстрый перезапуск
```bash
make restart-api    # Быстрый перезапуск только API
make rebuild-api    # Пересборка и перезапуск API
```
Полная пересборка
```bash
make rebuild        # Полная пересборка development окружения
```
Управление зависимостями .NET
```bash
make clean-cache    # Очистка кэша сборки .NET
make restore        # Восстановление NuGet пакетов
```
📊 Мониторинг
```bash
make status    # Показать статус контейнеров
```
🛠️ Использование
Начало работы
make init - для первоначального запуска

make dev-logs - для просмотра логов во время разработки

Во время разработки
Используйте make restart-api для быстрого применения изменений

Используйте make rebuild-api если нужна пересборка

Для полного сброса используйте make rebuild

Структура файлов
docker-compose.yml - основное production окружение

docker-compose.dev.yml - development окружение

Контейнер API: dnd_dotnet_api

💡 Советы
После изменения Dockerfile используйте make rebuild

Для очистки кэша .NET используйте make clean-cache

Логи development версии: make dev-logs

🔧 Troubleshooting
Если возникают ошибки Hot Reload

make rebuild-api    # Пересобрать API
# или
make rebuild        # Полная пересборка
Если проблемы с зависимостями .NET
```bash
make clean-cache && make restore
```
Проверка статуса контейнеров
```bash
make status    # Убедитесь что все контейнеры работают
```