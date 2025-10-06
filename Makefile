.PHONY: init build up down logs dev prod

init: build up logs

build:
	docker compose build

dev-build:
	docker compose -f docker-compose.dev.yml build

up:
	docker compose up -d

dev:
	docker-compose -f docker-compose.dev.yml up -d

down:
	docker compose down

logs:
	docker compose logs -f api

dev-logs:
	docker compose -f docker-compose.dev.yml logs -f api

	# Перезапуск только API (быстро)
restart-api:
	docker-compose -f docker-compose.dev.yml restart api

clean-cache:
	docker exec dnd_dotnet_api dotnet clean
	docker exec dnd_dotnet_api rm -rf bin obj

restore:
	docker exec dnd_dotnet_api dotnet restore

rebuild: down dev-build dev

status:
	docker-compose -f docker-compose.dev.yml ps