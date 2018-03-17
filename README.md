# shared-groceries_grocery-service

## TODO

- Allow remote debugging docker image
- Google authentication check for all requests
- Actually creating the planned application

## Build&Run

```bash
docker-compose up -d --build
```

To see and follow the logs of a service `docker-compose logs -t -f grocery-service`

## Run without Docker (for debugging)

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

## Environment variables for local debugging

The application and the android app expect the following values:

| Parameter              | Default value         |
| ---------------------- | --------------------- |
| ASPNETCORE_ENVIRONMENT | Development           |
| ASPNETCORE_URLS        | http://localhost:8000 |
| GOOGLE_CLIENT_ID       | Yea nice try          |
