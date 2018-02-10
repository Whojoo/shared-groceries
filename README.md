# shared-groceries_grocery-service

## TODO
- Allow remote debugging docker image

## Build
```
cd SharedGrocery
docker build -t shared-groceries/grocery-service .
```

## Run without Docker
Make sure an sql server is running with the following parameters:

| Parameter | Value     |
| --------- | --------- |
| Server    | localhost |
| Port      | 1433      |
| User Id   | sa        |
| Password  | Passw0rd  |

Make sure it is up to date.
```
cd SharedGrocery
dotnet ef database update
```
Then run like you normally would, keep in mind the port it listens to. Default is 5000 while through docker is 80 (forwarded to 8080)
