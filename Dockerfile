FROM mcr.microsoft.com/dotnet/core/sdk:3.1

RUN apt-get update
RUN apt-get install ldap-utils -y

WORKDIR /App

COPY LdapTest.csproj /App
RUN dotnet restore

COPY . /App

RUN dotnet build

CMD dotnet run --no-build