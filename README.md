HPSchedule Modernized – Phase 0

Lokale Entwicklung

- docker compose -f infra/docker-compose.yml up -d --build
- API: http://localhost:5080/health
- Web: http://localhost:5081
- MailHog: http://localhost:8025

CI: GitHub Actions baut und testet die API bei jedem Push/PR.
