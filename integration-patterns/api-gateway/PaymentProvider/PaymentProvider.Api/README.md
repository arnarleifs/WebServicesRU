# Database / PostgreSQL

```bash
docker run -d \
  --name postgres \
  -e POSTGRES_USER=admin \
  -e POSTGRES_PASSWORD=admin \
  -e POSTGRES_DB=postgres \
  -p 5432:5432 \
  -v postgres_data:/var/lib/postgresql/data \
  postgres
```

## Population script

```sql
-- Insert customer and webhook in one transaction
WITH new_customer AS (
INSERT
INTO "Customer" ("Name", "ApiKey")
VALUES ('Stargate University', 'YRG1YalsmCjeScHcZXKsVK8ukPf4qE+xW/9lTokf0OY=')
    RETURNING "Id"
    )
INSERT
INTO "Webhooks" ("CustomerId", "Url")
SELECT "Id", 'https://localhost:7119/webhooks/payment-link'
FROM new_customer;
```

```bash
# Install postgresql locally
brew install postgresql

# Run initial population
psql -h localhost -U admin -d postgres -c "INSERT INTO \"public\".\"Customers\" (\"Name\", \"ApiKey\") VALUES ('Stargate University', 'YRG1YalsmCjeScHcZXKsVK8ukPf4qE+xW/9lTokf0OY=');"
psql -h localhost -U admin -d postgres -c "INSERT INTO \"Webhooks\" (\"CustomerId\", \"Url\") VALUES ((SELECT \"Id\" FROM \"Customers\" WHERE \"Name\" = 'Stargate University'), 'https://localhost:7119/webhooks/payment-link');"
```

## Test cards

Number: 4242-4242-4242-4242
CVC: Any digits
Date: Any future date