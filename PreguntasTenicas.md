# Respuestas – Prueba Técnica

## 1. ¿Cómo implementaría la autenticación y autorización en esta API?

La autenticación se implementó utilizando **JWT (JSON Web Token)**. Se desarrollaron dos controladores principales: uno para la gestión de empleados y otro para la autenticación de usuarios.

El controlador de autenticación cuenta con dos endpoints:

- **Register:** Permite registrar nuevos usuarios.
- **Login:** Valida las credenciales y genera un token JWT.

Las contraseñas no se almacenan en texto plano; se utiliza **BCrypt** para generar un hash seguro antes de guardarlas en la base de datos.

La autorización se implementó mediante **roles**. Se definieron dos roles:

- **Admin:** Tiene acceso completo a todos los endpoints de empleados (crear, consultar, actualizar y eliminar).
- **User:** Solo puede consultar la información de los empleados mediante los endpoints **GET**.

La protección de los endpoints se realiza utilizando el atributo **`[Authorize]`** y la propiedad **Roles**, permitiendo restringir el acceso según el rol incluido en el token JWT.

---

## 2. ¿Qué es un Middleware en ASP.NET Core?

Un **Middleware** es un componente que forma parte del pipeline de procesamiento de las peticiones HTTP en ASP.NET Core. Actúa como un intermediario entre la solicitud del cliente y el controlador, permitiendo ejecutar lógica antes y después de que la petición sea procesada.

Los middlewares permiten implementar funcionalidades transversales como:

- Autenticación.
- Autorización.
- Manejo de excepciones.
- Registro de solicitudes (Logging).
- Compresión.
- CORS.
- Monitoreo y auditoría.

En este proyecto se implementó un middleware para centralizar el manejo de excepciones, evitando duplicar código en los controladores y devolviendo respuestas HTTP consistentes.

---

## 3. Proporcione un ejemplo de cómo proteger los endpoints utilizando estos roles.

La protección de los endpoints se realiza utilizando autenticación JWT junto con autorización basada en roles mediante el atributo **`[Authorize]`** de ASP.NET Core.

Se definieron dos roles:

- **Admin**
- **User**

En los métodos del controlador se utilizan atributos como los siguientes:

```csharp
[Authorize(Roles = "Admin")]
```

o

```csharp
[Authorize(Roles = "Admin,User")]
```

Dependiendo del rol del usuario autenticado, ASP.NET Core permite o restringe automáticamente el acceso al endpoint.

---

## 4. ¿Cuáles son algunos problemas comunes de rendimiento en aplicaciones .NET y cómo pueden solucionarse?

Algunos problemas comunes son:

- Realizar consultas que recuperan más información de la necesaria (por ejemplo, utilizar `SELECT *` cuando solo se requieren algunos campos).
- No crear índices sobre las columnas utilizadas en filtros o relaciones entre tablas.
- Realizar consultas LINQ ineficientes o cargar información innecesaria desde la base de datos.
- Recuperar grandes cantidades de registros sin utilizar paginación.

Para mejorar el rendimiento se pueden aplicar las siguientes prácticas:

- Recuperar únicamente los campos necesarios mediante proyecciones (`Select`).
- Crear índices adecuados en la base de datos.
- Utilizar correctamente `Include()` para cargar únicamente las relaciones necesarias.
- Implementar consultas asíncronas (`async/await`).
- Utilizar paginación cuando se manejan grandes volúmenes de información.

---

## 5. Describa cómo perfilaría y optimizaría una consulta lenta en una aplicación ASP.NET Core.

Para optimizar una consulta lenta realizaría las siguientes actividades:

- Revisar el **plan de ejecución** de SQL Server para identificar operaciones costosas.
- Analizar si existen `Include()` (JOINs) innecesarios que incrementen el tiempo de ejecución.
- Ejecutar la consulta directamente en **SQL Server Management Studio (SSMS)** para medir su tiempo de respuesta. Revisando Tabla a tabla cual Join tiene mas costo de ejecucion.
- Verificar que existan índices sobre las columnas utilizadas en filtros, búsquedas y relaciones.
- Revisar la consulta LINQ para recuperar únicamente la información necesaria y evitar traer datos que no serán utilizados.