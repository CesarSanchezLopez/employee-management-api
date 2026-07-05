# Employee Management API

## Descripción

Employee Management API es una aplicación desarrollada en **ASP.NET Core 8** siguiendo los principios de **Clean Architecture** y **SOLID**. El proyecto permite administrar empleados, departamentos, proyectos e historial de cargos, además de implementar autenticación mediante **JWT** y autorización basada en roles.

Esta solución fue desarrollada como parte de una prueba técnica, aplicando buenas prácticas de desarrollo, Entity Framework Core y patrones de diseño.

---

# Tecnologías utilizadas

* ASP.NET Core 8
* C#
* Entity Framework Core
* SQL Server
* JWT Authentication
* BCrypt.Net
* Swagger / OpenAPI
* LINQ
* Dependency Injection

---

# Arquitectura

El proyecto implementa **Clean Architecture**, separando las responsabilidades en diferentes capas:

```text
EmployeeManagement.API
│
├── EmployeeManagement.Application
│
├── EmployeeManagement.Domain
│
├── EmployeeManagement.Infrastructure
│
└── EmployeeManagement.Persistence
```

Cada capa tiene una responsabilidad específica:

* **Domain:** Entidades, enumeraciones y reglas del dominio.
* **Application:** Servicios, DTOs, interfaces y lógica de negocio.
* **Infrastructure:** Repositorios, Entity Framework Core y acceso a datos.
* **API:** Controladores, autenticación, middleware y configuración de la aplicación.

---

# Principios SOLID aplicados

Durante el desarrollo se aplicaron varios principios SOLID, entre ellos:

* **SRP (Single Responsibility Principle):** Cada clase tiene una única responsabilidad.
* **OCP (Open/Closed Principle):** El cálculo del bono se implementó utilizando Strategy, permitiendo agregar nuevas estrategias sin modificar el código existente.
* **DIP (Dependency Inversion Principle):** Los servicios dependen de interfaces y utilizan Inyección de Dependencias.

---

# Patrones implementados

## Repository Pattern

Se utilizó para encapsular el acceso a la base de datos mediante Entity Framework Core, desacoplando la lógica de negocio de la capa de persistencia.

## Strategy Pattern

Se implementó para calcular el bono anual de los empleados según su cargo, permitiendo extender fácilmente nuevas reglas de negocio.

## Factory Pattern

Se utilizó para seleccionar dinámicamente la estrategia de cálculo del bono según el tipo de empleado.

---

# Base de datos

La base de datos fue desarrollada utilizando **Entity Framework Core Code First**.

Entidades principales:

* Employees
* Departments
* Projects
* EmployeeProjects
* PositionHistories
* AppUsers

---

# Autenticación y autorización

La autenticación se implementó mediante **JWT (JSON Web Token)**.

Se definieron dos roles:

* **Admin**

  * Crear empleados.
  * Actualizar empleados.
  * Eliminar empleados.
  * Consultar empleados.

* **User**

  * Consultar empleados únicamente.

Las contraseñas se almacenan utilizando **BCrypt** para garantizar su seguridad.

---

# Funcionalidades

* CRUD de empleados.
* Gestión de departamentos.
* Relación de empleados con proyectos.
* Historial de cargos.
* Consulta de empleados por departamento con al menos un proyecto.
* Cálculo de bono anual utilizando Strategy y Factory.
* Autenticación JWT.
* Autorización basada en roles.
* Middleware para manejo global de excepciones.

---

# Configuración del proyecto

## 1. Clonar el repositorio

```bash
git clone <URL_DEL_REPOSITORIO>
```

---

## 2. Configurar la cadena de conexión

Modificar el archivo **appsettings.json**:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=EmployeeManagementDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

## 3. Ejecutar las migraciones

```bash
dotnet ef database update
```

---

## 4. Ejecutar el proyecto

```bash
dotnet run
```

---

# Usuario administrador por defecto

El proyecto crea automáticamente un usuario administrador mediante el proceso de Seed.

**Usuario**

```text
admin
```

**Contraseña**

```text
Admin123*
```


---

# Autor

Desarrollado por **César Sánchez** como solución para la prueba técnica.
