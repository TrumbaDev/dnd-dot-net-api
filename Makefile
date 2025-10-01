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