Aquí tienes una versión mejorada del README:


# API Gestora de Productos

## Descripción

Esta API es un servicio de gestión de productos desarrollado en .NET con SQL Server como base de datos. Se ha implementado utilizando la arquitectura **Onion**, **CORQ**, el patrón de diseño **Repository**, y una arquitectura genérica con una única clase de servicios que maneja todas las operaciones de la API. Además, la API utiliza **JSON Web Tokens (JWT)** para la autenticación.

## Características

- **Arquitectura Onion y CORQ:** La API sigue los principios de estas arquitecturas para garantizar una separación clara de responsabilidades y una alta mantenibilidad del código.
- **Patrón Repository:** Utilizado para encapsular la lógica de acceso a datos y promover una abstracción limpia entre la lógica de negocio y la capa de persistencia.
- **Clase de Servicios Genérica:** Una única clase de servicios se encarga de gestionar todas las operaciones CRUD, lo que simplifica el código y mejora su reusabilidad.
- **Seed Data:** La API incluye un sistema de datos de prueba predefinido que facilita la evaluación del sistema sin necesidad de ingresar datos manualmente. Solo es necesario modificar el connection string y ejecutar la API para comenzar.

## Requisitos

- **.NET:** Asegúrate de tener instalada la versión requerida de .NET para ejecutar esta API.
- **SQL Server:** Configura el connection string para conectarte a tu instancia de SQL Server.

## Instalación y Ejecución

1. Clona este repositorio.
2. Configura el connection string en el archivo de configuración de la aplicación.
3. Ejecuta la API desde tu entorno de desarrollo o mediante la línea de comandos.

## Estado del Proyecto

> **⚠️ Importante:** La aplicación aún está en fase de reconstrucción y puede estar sujeta a cambios significativos.

