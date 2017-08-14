# BackEnd

Este repositorio contiene el código fuente del servidor; utiliza el C# como lenguage de programación y .Net Framework 4.6.1 sobre VS 2017.
El programa solo contiene el site ApiRest y no posee ninguna interfaz ya que esta orientado a servicios.

### Carpetas de Trabajo

* __App_Start__ contiene las clases de configuración de la aplicación.
* __Commands__ contiene las definiciones de los comandos para cada operación del WebApi ya que nos permite aislar el entorno de ejecución de cada request (CQRS)
* __Contracts__ contiene las interfaces necesarias para aistalar las dependencias.
* __Controllers__ contiene los controllers del WebApi.
* __Dependency__ contiene las implementaciones para integrar el contenedor de injeccion de dependencia con las operaciones.
* __Handlers__ contiene las clases que implementan la logica de punto de inicio de los procesos (request).
* __Maps__ contiene el _mapping_ para la comunicación del modelo con la base de datos.
* __Models__ contiene el modelo del dominio.
* __Persist__ contiene las implementaciones que trabajan directamente con NHibernate.
* __Validators__ contiene los _decorators_ que validan que los commands tengan la data correcta.

### Paquetes Usados

Para instalar los paquetes usados solo se requiere usar la opción de __Restaurar Paquetes de NuGet__

* Microsoft.AspNet.WebApi (5.2.3)
* Castle.Windsor (4.0.0)
* NHibernate (4.1.1)
* xUnit (2.2.0)
* Moq (4.7.99)
