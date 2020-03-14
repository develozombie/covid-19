# COVID-19

COVID-19 es un proyecto que busca ayudar a los Ministerios de Salud a registrar los casos de COVID-19 de forma ordenada y centralizada. Tambien busca brindar información oportuna a los ciudadanos sobre el progreso y medidas de control.

## Instación

Descargar Azure Functions Core tools

```bash
brew tap azure/functions
brew install azure-functions-core-tools@3
brew link --overwrite azure-functions-core-tools@3
```

Instala la extensión para CosmosDB en el proyecto
```bash
dotnet add package Microsoft.Azure.WebJobs.Extensions.CosmosDB
```

## Usage

Este servicio ha sido creado para ejecutarse en los Tiers gratuitos de Azure Functions v3 y Cosmos DB

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)