﻿using MayTheFourth.Application.Planets.Interfaces.Services;

namespace MayTheFourth.Web.Endpoints;

public static class Planets
{
    public static void PlanetEndpoints(this WebApplication app)
    {
        app.MapGet("/api/v1/planets", async (IPlanetServices services) => await services.GetPlanetsAsync())
            .WithName("GetAllPlanets")
            .WithTags("Planets")
            .WithSummary("Returns all planets from Star Wars universe.")
            .WithOpenApi();
        
        app.MapGet("/api/v1/planets/get-by-code/{code}", async (IPlanetServices services, int code) => await services.GetPlanetByCodeAsync(code))
            .WithName("GetPlanetByCode")
            .WithTags("Planets")
            .WithSummary("Returns a planet by code.")
            .WithOpenApi();

        app.MapGet("/api/v1/planets/get-by-name", async (IPlanetServices services, string name) => await services.GetPlanetByNameAsync(name))
            .WithName("GetPlanetByName")
            .WithTags("Planets")
            .WithSummary("Returns a planet list by name.")
            .WithOpenApi();
    }
}