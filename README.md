# shared-groceries_grocery-service

## Build&Run

```bash
docker-compose up -d --build
```

To see and follow the logs of a service `docker-compose logs -t -f grocery-service`

You need a secrets.env file or you need to replace the following variables:

- GOOGLE_CLIENT_ID (Used for google authentication)

## Debug with docker

Debugging with docker is done through Visual Studio Code and has the following requirements:

- [Visual Studio Code](https://code.visualstudio.com/)
- launch.json file in .vscode folder
- secrets.env file mentioned above, or at least the variables mentioned replaced

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

To allow remote debugging you then need to execute the following command.

```bash
docker-compose -f docker-compose.yml -f docker-compose.override.yml -f docker-compose.debug.yml up -d --build
```

This will start all the required services. The application won't be started until the debugger is started. And all the logging is done through the debugger so `docker-compose logs grocery-service` won't show anything.

## Debug without Docker

Debugging a docker contrainer currently doesn't work, so debugging is done without running the application in docker.

Either host your own postgres servers (see below) or run `docker-compose up -d --build grocery-data uaa-data`

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

## Required environment variables

The application and the android app expect the following values:

| Parameter              | Default value            |
| ---------------------- | ------------------------ |
| ASPNETCORE_ENVIRONMENT | Development              |
| ASPNETCORE_URLS        | `http://localhost:8000)` |
| GOOGLE_CLIENT_ID       | Yea nice try             |
