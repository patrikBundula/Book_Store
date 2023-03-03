 #sets the base image to use for the Docker image. In this case, it is using the official .NET 6.0 runtime image.
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#set the working directory inside the Docker container to /app.
WORKDIR /app
#expose ports 80 and 443, which are the default ports used by the ASP.NET Web API for HTTP and HTTPS traffic.
EXPOSE 80
EXPOSE 443

 #set the second image to use for the Docker image. In this case, it is using the official .NET 6.0 SDK image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#set the working directory inside the Docker container to /src.
WORKDIR /src
#copies the project file Book_Store.csproj from local machine to the /src/Book_Store directory inside the Docker container.
COPY ["Book_Store/Book_Store.csproj", "Book_Store/"]
COPY ["Database/Database.csproj","Database/"]
COPY ["Logic/Logic.csproj","Logic/"]
COPY ["Model/Model.csproj","Model/"]
#restore the NuGet packages required by your project using the project file Book_Store.csproj.
RUN dotnet restore "Book_Store/Book_Store.csproj"
#copy all the files from local machine to the current directory inside the Docker container.
COPY . .
#set the working directory inside the Docker container to /src/Book_Store.
WORKDIR "/src/Book_Store"
#build project using the project file Book_Store.csproj, in the Release configuration, and outputs the build artifacts to the /app/build directory inside the Docker container.
RUN dotnet build "Book_Store.csproj" -c Release -o /app/build
#set the third image to use for the Docker image. It will be used to publish the project.
FROM build AS publish
#This line publishes project in the Release configuration and outputs the published artifacts to the /app/publish directory inside the Docker container. The /p:UseAppHost=false flag disables the creation of a web host in the published output.
RUN dotnet publish "Book_Store.csproj" -c Release -o /app/publish
#sets the final image to use for the Docker image. It will be used to run your ASP.NET Web API project.
FROM base AS final
#sets the working directory inside the Docker container to /app.
WORKDIR /app0
#copies the published output from the publish stage to the current directory inside the Docker container.
COPY --from=publish /app/publish .
#specifies the command to run when the Docker container starts. In this case, it will start your ASP.NET Web API project by running the Book_Store.dll file with the dotnet command.
ENTRYPOINT ["dotnet", "Book_Store.dll"]