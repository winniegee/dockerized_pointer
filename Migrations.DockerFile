FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /src
COPY ["WebApplication1/WebApplication1.csproj", "WebApplication1/"]
COPY ["DB/DB.csproj", "DB/"]
COPY ["Model/Model.csproj", "Model/"]
COPY entrypoint.sh entrypoint.sh

RUN dotnet tool install --global dotnet-ef

RUN dotnet restore "DB/DB.csproj"
COPY . .
#WORKDIR "/src/WebApplication1"
WORKDIR "/src/DB"

RUN /root/.dotnet/tools/dotnet-ef migrations add InitialMigrations

RUN chmod +x entrypoint.sh
CMD /bin/bash entrypoint.sh