FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["JobYub/JobYub.csproj", "JobYub/"]
RUN dotnet restore "JobYub/JobYub.csproj"
COPY . .
WORKDIR "/src/JobYub"
RUN dotnet build "JobYub.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "JobYub.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JobYub.dll"]