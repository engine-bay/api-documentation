# EngineBay.ApiDocumentation

[![NuGet version](https://badge.fury.io/nu/EngineBay.ApiDocumentation.svg)](https://badge.fury.io/nu/EngineBay.ApiDocumentation)
[![Maintainability](https://api.codeclimate.com/v1/badges/dccbdbe67bcc4a640ba8/maintainability)](https://codeclimate.com/github/engine-bay/api-documentation/maintainability)
[![Test Coverage](https://api.codeclimate.com/v1/badges/dccbdbe67bcc4a640ba8/test_coverage)](https://codeclimate.com/github/engine-bay/api-documentation/test_coverage)

ApiDocumentation module for EngineBay published to [EngineBay.ApiDocumentation](https://www.nuget.org/packages/EngineBay.ApiDocumentation/) on NuGet.

## About

This module will add middleware to generate and expose [Swagger UI](https://swagger.io/) documentation for all the endpoints in your project. Swagger uses the [OpenAPI 3 specification](https://swagger.io/specification/).

## Usage

The Swagger documentation is generated entirely automatically if this module is enabled. 

If you wish to browse the documentation generated for your project, you can start the application and visit `/swagger/index.html`.

### Registration

This module cannot run on its own. You will need to register it in your application to use its functionality. See the [Demo API registration guide](https://github.com/engine-bay/demo-api).

### Environment Variables

See the [Documentation Portal](https://github.com/engine-bay/documentation-portal/blob/main/EngineBay.DocumentationPortal/DocumentationPortal/docs/documentation/configuration/environment-variables.md#api-documentation).

## Dependencies

* [EngineBay.Core](https://github.com/engine-bay/core)
* [EngineBay.Authentication](https://github.com/engine-bay/authentication)