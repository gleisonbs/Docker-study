FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine
ARG WEBAPP_VERSION=0.0.1
LABEL maintainer=gleison@email.com \
    Name=webapp-${BUILD_COFING} \
    Version=0.0.1
ARG URL_PORT
WORKDIR /app
ENV NUGET_XMLDOC_MODE skip
ENV ASPNETCORE_URLS http://*:${URL_PORT}
ENTRYPOINT [ "dotnet", "SchoolRegister.dll" ]
