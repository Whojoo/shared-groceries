# shared-groceries_grocery-service

## TODO

- Create databases of sql server in build script
- Fix for Visual Studio (for Mac)
- Allow remote debugging docker image

## Build&Run

```bash
docker-compose build
docker-compose up -d
```

To see and follow the logs of a service `docker-compose logs -t -f grocery-service`

## Run without Docker (for debugging)

Running docker-compose in Visual Studio for Mac does currently not work, therefore debugging should be done without docker.

Either host your own sql server (see below) or run `docker-compose start mssql-server`

Make sure an sql server is running with the following parameters:

| Parameter | Value     |
| --------- | --------- |
| Server    | localhost |
| Port      | 1433      |
| User Id   | sa        |
| Password  | Passw0rd  |

Make sure it is up to date.

```bash
cd SharedGrocery
dotnet ef database update
```

Then run like you normally would, keep in mind the port it listens to. Default is 5000 while through docker is 80 (forwarded to 8000)
