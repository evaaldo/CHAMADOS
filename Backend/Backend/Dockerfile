#Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY Backend/Backend/Backend.csproj Backend/
RUN dotnet restore "Backend/Backend.csproj"

COPY ./Backend/Backend/ Backend/
WORKDIR /src/Backend
RUN dotnet build "Backend.csproj" -c Release -o /app/build

#Stage 2: Publish
FROM build AS publish
RUN dotnet publish Backend.csproj -c Release -o /app/publish

#Stage 3: Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "Backend.dll" ]