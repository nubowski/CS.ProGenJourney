// See https://aka.ms/new-console-template for more information

using CS.ProGenJourney.Controllers;
using CS.ProGenJourney.Models;

// TODO: learn about scales and methodology, we are having low and high cuts (water and mountains aboard)

TerrainController terrainController = new TerrainController(16);
List<TerrainPoint> terrain = terrainController.GenerateTerrain(80, 30);
terrainController.ApplyPerlinNoise(terrain, 3.5);
terrainController.PrintTerrain(terrain, 80, 30);
