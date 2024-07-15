# API

Proyecto con el API de los métodos de la aplicación ImplantDent

| Sonarqube |
|---|
| [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Implantdent_api&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=Implantdent_api) |
| [![Bugs](https://sonarcloud.io/api/project_badges/measure?project=Implantdent_api&metric=bugs)](https://sonarcloud.io/summary/new_code?id=Implantdent_api) |
| [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=Implantdent_api&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=Implantdent_api) |
| [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=Implantdent_api&metric=coverage)](https://sonarcloud.io/summary/new_code?id=Implantdent_api) |

## CI/CD

Se ejecuta el pipeline https://github.com/Implantdent/api/actions/workflows/build.yml

| Rama | Estado |
|:-:|:-:|
| dev | [![Compilar](https://github.com/Implantdent/api/actions/workflows/build.yml/badge.svg?branch=dev)](https://github.com/Implantdent/api/actions/workflows/build.yml) |
| qa | [![Compilar](https://github.com/Implantdent/api/actions/workflows/build.yml/badge.svg?branch=qa)](https://github.com/Implantdent/api/actions/workflows/build.yml) |
| main | [![Compilar](https://github.com/Implantdent/api/actions/workflows/build.yml/badge.svg?branch=main)](https://github.com/Implantdent/api/actions/workflows/build.yml) |

El despliegue se ejecuta en

| Rama | Imagen de contenedor |
|:-:|:-:|
| dev | Api 1.0.X-dev |
| qa | Api 1.0.X-qa |
| main | Api 1.0.X |

## Lenguaje

C# .Net 8

## Librerías y paquetes

Proyecto Api

| Paquete | Versión |
|---|:-:|
| Business | 1.0.1 |

Proyecto Api.Test

| Paquete | Versión |
|---|:-:|
| xUnit | 2.5.3 |
| Dapper | 2.1.35 |
| Dal | 1.0.1 |

## Compilar y probar

Se ejecuta el proyecto de pruebas Business.Test