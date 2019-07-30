# Keycloak /  ASP.NET Core / Swagger Nswag
Esta aplicación es un ejemplo de como proteger ASP.NET core 2.2 con un servidor de autentificacion oauth2 Keycloak.
Tambien se implementa el consumo de la api con Nswag con OpenApi 3.

![](./images/2019-07-29_8-07-45.gif)

## Resumen
- Server
  - ASP.NET Core 2.2
  - Docker: keycloack server con base de datos mysql
- Client
  - Nswag. interfaz de usuario y el generador de Swagger


## Setup

1. Instalación:
   - [.NET Core 2.2](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/install)
   - [Docker](https://docs.docker.com/docker-for-windows/install/)

2. Clonar el proyecto:
    `git clone https://github.com/juandepalo/Keycloak-aspnetcore.git`


3. Situarse en el directorio:

   cd ./Keycloak-aspnetcore
4. ejecutar:

   `docker-compose -f "docker-compose.yml"  up -d --build --remove-orphans`

5. Abrir el navegador [http://localhost:8080](http://localhost:8080) [http://localhost:10001](http://localhost:10001).


![http://localhost:8080](./images/2019-07-29_8-40-30.png)

![http://localhost:10001](./images/2019-07-29_8-40-39.png)

## Configuración

1. Modificacion de host.
   1.  Para ejecutar localmente modificaremos el fichero 'C:\Windows\System32\drivers\etc\hosts' añadiendo el nombre del servicio de Keycloark que se puede modificar en el [docker-compose](./docker-compose.yml).

    ![nombreserviciokeycloak](./images/nombreServicioKeycloak.png)





    modificación fichero hosts:

    `127.0.0.1       localhost  keycloalocalhost`

2. Configuracion de Keycloak.
   1. He dejado la exportación de configuración de un cliente para el ejemplo en [keycloak-Import/realm-export.json](./keycloak-Import/realm-export.json)

Pulsamos sobre Administrador console. Nos solicitara las credenciales.
Por defecto con docker-compose hemos creado el usuario **admin**, con contraseña **Pa55w0rd**
![login Consola](./images/loginconsola.png)

Para nuestro entorno de pruebas crearemos nuestro Realm "Demo", para ello pulsamos sobre la add Realm
![creacion Realm](./images/creacionRealm.png)

Vamos a la pestaña "Security Defenses" y permitimos todos los origenes
`X-Frame-Options : ALLOW-FROM *`
![Seguridad Realm](./images/SeguiridadRealm.png)

Importamos el cliente [keycloak-Import/realm-export.json](./keycloak-Import/realm-export.json)
![Importar Cliente](./images/importacioncliente.png)

Validamos configuración
![Configuración Cliente](./images/configuracionCliente.png)

Generamos Secret key que debemos copiar para configurar el proyecto de Aspnet.core
![Creación de Secret](./images/RegeneracionSecret.png)

Para consumir la api necestiamos añadir un usuario al cliente samplewebapi
![Creación Usuario](./images/CreacionUsuario.png)

Le asignamos una contraseña
![Cambio contraseña](./images/contrasenaUsuario.png)
![Creacion contraseña Usuario](./images/creacionContrasenaUsuario.png)
![confirmacion cambio contrasñea](./images/confirmacioncambiocontrasena.png)

Validamos los Roles
![Roles Usuario](./images/rolesUsuario.png)

Para ver el esquema de autenficación de Keycloak nos situamos en Realm Setting
![Configuracion Realm](./images/obtenerconfiguracion.png)

y pulsamos sonbre el Endpoints "OpenID Endpoint Configuration"
![Datos Configuración](./images/datosconfiguracion.png)

3. Configuracion Aspnet.
   Con los datos obtenidos del esquema de keycloak configuramos nuestro cliente.

![Configuración Aspnet](./images/configuracionAspnet.png)


4. Probar:

Accerder a la url http://localhost:10001/swagger/
![swagger](./images/swagger.png)

![Autorización](./images/autentificacionSwagger.png)

![Validar datos cliente](./images/datosautorizacion.png)


![Pantalla login](./images/loginkeycloak.png)

![Usuario SampleWebApi](./images/loginusuarioSampleWebapi.png)

![Autentificación correcta](./images/AutorizacionCorrecta.png)

![Prueba consumo api](./images/ejecutarApi.png)

![Resultado](./images/Resultado.png)


## Enlaces
[Visual studio Nswag](https://docs.microsoft.com/es-es/aspnet/core/tutorials/getting-started-with-nswag?view=aspnetcore-2.2&tabs=visual-studio)

[Nswag](https://github.com/RicoSuter/NSwag)

[Add OAuth2 authorization (OpenAPI 3)](https://github.com/RicoSuter/NSwag/wiki/AspNetCore-Middleware)

[KeyCloak Documentacion](https://www.keycloak.org/archive/documentation-6.0.html)

