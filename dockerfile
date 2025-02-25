# Use the official ASP.NET Core runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Set the environment variable to point to the key inside the container
ENV GOOGLE=/app/we4u-blazor-8cb8f81f9498.json

# Copy the key file from your build context into the container
COPY we4u-blazor-8cb8f81f9498.json /app/we4u-blazor-8cb8f81f9498.json

# Enable HTTPS in Docker
# Enable HTTPS and specify certificate location inside Docker
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
ENV DOTNET_URLS=http://0.0.0.0:8080

# Expose ports as per launchSettings.json
EXPOSE 8080

# Use the .NET 8 SDK for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
#COPY ["ShoyerNetBlazor.csproj", "./"]
#COPY ["ShoyerNetBlazor.BL/ShoyerNetBlazor.BL.csproj", "ShoyerNetBlazor.BL/"]
COPY ["ShoyerNetBlazor/ShoyerNetBlazor.csproj", "ShoyerNetBlazor/"]
COPY ["ShoyerNetBlazor.BL/ShoyerNetBlazor.BL.csproj", "ShoyerNetBlazor.BL/"]
RUN dotnet restore "ShoyerNetBlazor/ShoyerNetBlazor.csproj"

# Copy everything and build the application
COPY . .
RUN dotnet publish "ShoyerNetBlazor/ShoyerNetBlazor.csproj" -c Release -o /app/publish

# Final stage: Create the runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Set environment variables for port bindings
#ENV ASPNETCORE_URLS="http://+:8080;https://+:7015"
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false


# Start the application
ENTRYPOINT ["dotnet", "ShoyerNetBlazor.dll"]
