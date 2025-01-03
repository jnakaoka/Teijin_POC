FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY ./api_1/POC-Teijin.csproj ./api/
WORKDIR /app/api
RUN dotnet restore

COPY ./api_1 ./api
WORKDIR /app/api
RUN rm -rf bin obj && dotnet publish -c Release -o /out


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /out .

EXPOSE 5000
EXPOSE 5001

ENTRYPOINT ["dotnet", "POC-Teijin.dll"]
