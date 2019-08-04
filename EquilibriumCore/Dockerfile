FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
EXPOSE 80
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
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
