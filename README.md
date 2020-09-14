playing with azure functions and cosmos db.

BTW, you need a file in the root called `local.settings.json` with the following:

```json
{
  "IsEncrypted": false, // can be true if you know what you're doing
  "Values": {
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "CosmosDBConnection": "AccountEndpoint=https://<your-cosmos-account>.documents.azure.com:443/;AccountKey=<your-huge-cosmos-account-key-or-token>"
  }
}
```
