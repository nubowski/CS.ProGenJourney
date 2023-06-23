// See https://aka.ms/new-console-template for more information

using CS.ProGenJourney.Controllers;
using CS.ProGenJourney.Models;

static void Main(string[] args)
{
    TerrainController terrainController = new TerrainController(16);
    List<TerrainPoint> terrain = terrainController.GenerateTerrain(80, 30);
    terrainController.ApplyPerlinNoise(terrain, 8.0);
    terrainController.PrintTerrain(terrain, 80, 30);
    Console.ReadLine();
}