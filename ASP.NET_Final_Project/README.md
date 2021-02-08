**mssql docker configurations:**

run docker command to run the container:
`docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=125125125Ic" \ -p 1433:1433 --name employes -h employes \ -d mcr.microsoft.com/mssql/server:2019-latest`

To view your Docker containers, use the docker ps command. `docker ps -a`

Connect to SQL Server `docker exec -it employes bash`

Once you are inside the container, connect locally with sqlcmd. Sqlcmd is not in the path by default, so you have to specify the full path. `/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "125125125Ic"`

Create a new database `CREATE DATABASE employes`

Execute query: `GO`

**Project hosting:**

To run the project execute the command:
`cd ASP.NET_Final_Project/`
`dotnet watch run`