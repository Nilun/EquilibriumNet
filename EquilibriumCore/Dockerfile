FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
EXPOSE 80
WORKDIR /app
RUN apt-get update && \
    apt-get install -y gnupg  libgconf-2-4 wget && \
    wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add - && \
    sh -c 'echo "deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google.list' && \
    apt-get update && \
    apt-get install -y google-chrome-unstable --no-install-recommends
ENV chrome:launchOptions:args --no-sandbox

FROM mcr.microsoft.com/dotnet/core/sdk AS build
WORKDIR /src
COPY ["EquilibriumCore.csproj", "EquilibriumCore/"]
RUN dotnet restore "EquilibriumCore/EquilibriumCore.csproj"
WORKDIR "/src/EquilibriumCore"
COPY . .
RUN dotnet build "EquilibriumCore.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EquilibriumCore.csproj" -c Release -o /app

FROM base AS final

WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EquilibriumCore.dll"]
