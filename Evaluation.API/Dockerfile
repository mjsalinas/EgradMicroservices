FROM mcr.microsoft.com/dotnet/aspnet:8.0 as build 
WORKDIR /src
COPY *.csproj ./
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime 
WORKDIR /app
EXPOSE 8080 
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=build /app/out
ENTRYPOINT ["dotnet", "Evaluation.API.dll"]