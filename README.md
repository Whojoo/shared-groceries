# shared-groceries_grocery-service

## Build&Run

You need a `config-server.env` file in order to use the config server.

Build the `whojoo/grocery-service` image of the grocery-service.

```bash
docker-compose up -d
```

To see and follow the logs of a service `docker-compose logs -t -f grocery-service`

## Config server

The current build uses a Spring Cloud Config server. The files are on a private repository. In order to use the config server you first need access to the `config-server.env` file.

You can fake the file by setting it up like this.

```env
SPRING_PROFILES_ACTIVE=native
```

That way all you are missing is the setup for encryption/decryption.

The config server is setup to use config files in ./config-server. Either checkout the config file repository in that folder or recreate the configuration in a `shared-groceries-{env}.yml` file. The file should have the same structure as the `appsettings.json` file. You can also check the `Common.Config.Config.cs` file.

## Debug with docker

Debugging with docker is done through Visual Studio Code and has the following requirements:

- [Visual Studio Code](https://code.visualstudio.com/)
- launch.json file in .vscode folder
- `config-server.env` file mentioned above

You need a .vscode folder in the root of the project containing the following launch.json file.

```json
{
    "version": "0.2.0",
    "configurations": [
        {
            "name": "SharedGrocery",
            "type": "coreclr",
            "request": "launch",
            "cwd": "/app",
            "program": "/app/out/SharedGrocery.dll",
            "sourceFileMap": {
                "/app": "${workspaceRoot}/SharedGrocery/"
            },
            "pipeTransport": {
                "debuggerPath": "/vsdbg/vsdbg",
                "pipeProgram": "/bin/bash",
                "pipeCwd": "${workspaceRoot}/SharedGrocery/",
                "pipeArgs": [
                    "-c",
                    "docker exec -i sharedgroceries_grocery-service_1 /vsdbg/vsdbg --interpreter=vscode"
                ]
            }
        }
    ]
}
```

`docker-compose up -d` will start all the required services. The application won't be started until the debugger is started. And all the logging is done through the debugger so `docker-compose logs grocery-service` won't show anything.

## Debug without Docker

Either host your own postgres servers (see below) or run `docker-compose up -d --build grocery-data uaa-data`

Besides that you still need the config server for the correct configuration, check that above.

Make sure postgres servers are running with the following parameters:

| Parameter | Value     |
| --------- | --------- |
| Server    | localhost |
| Port      | 5432      |
| User Id   | dbuser    |
| Password  | Passw0rd  |
| Database  | groceries |

| Parameter | Value     |
| --------- | --------- |
| Server    | localhost |
| Port      | 5433      |
| User Id   | dbuser    |
| Password  | Passw0rd  |
| Database  | uaa       |
