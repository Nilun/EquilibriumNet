FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 52961
EXPOSE 44310

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["EquilibriumCore/EquilibriumCore.csproj", "EquilibriumCore/"]
RUN dotnet restore "EquilibriumCore/EquilibriumCore.csproj"
COPY . .
WORKDIR "/src/EquilibriumCore"
RUN dotnet build "EquilibriumCore.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EquilibriumCore.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EquilibriumCore.dll"]