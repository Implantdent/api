FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ARG CONFIG=Release
USER app
WORKDIR /app
COPY ./bin/$CONFIG/net8.0/ .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "Api.dll"]