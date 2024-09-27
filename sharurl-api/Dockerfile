# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar el archivo .csproj y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Exponer el puerto que utiliza tu aplicación
EXPOSE 8080

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "sharurl-api.dll"]  # Reemplaza 'tu_proyecto.dll' con el nombre de tu archivo .dll
