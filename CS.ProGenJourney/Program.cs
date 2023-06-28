// See https://aka.ms/new-console-template for more information

using CS.ProGenJourney.Controllers;
using CS.ProGenJourney.Models;

// TODO: learn about scales and methodology, we are having low and high cuts (water and mountains aboard)
// TODO: upd. it is normal with Perlin that edged values are extremely rare 

var biomeTerrainSymbols = new Dictionary<(TerrainType, BiomeType), (char, ConsoleColor)>
{
    {(TerrainType.Mountain, BiomeType.Snow), ('^', ConsoleColor.White)},
    {(TerrainType.Mountain, BiomeType.Plains), ('^', ConsoleColor.Gray)},
    {(TerrainType.Mountain, BiomeType.DarkForest), ('^', ConsoleColor.Gray)},
    {(TerrainType.Grass, BiomeType.Desert), ('.', ConsoleColor.Yellow)},
    {(TerrainType.Grass, BiomeType.Swamp), ('.', ConsoleColor.DarkGreen)},
    {(TerrainType.Grass, BiomeType.Plains), ('.', ConsoleColor.Green)},
    {(TerrainType.Grass, BiomeType.Snow), ('.', ConsoleColor.White)},
    {(TerrainType.Hill, BiomeType.Plains), ('o', ConsoleColor.Green)},
    {(TerrainType.Hill, BiomeType.DarkForest), ('o', ConsoleColor.DarkGreen)},
    {(TerrainType.Hill, BiomeType.Snow), ('o', ConsoleColor.Gray)},
    {(TerrainType.Water, BiomeType.Swamp), ('~', ConsoleColor.DarkCyan)},
    {(TerrainType.Water, BiomeType.Plains), ('~', ConsoleColor.Blue)},
    {(TerrainType.Water, BiomeType.Snow), ('~', ConsoleColor.Gray)},
    // and so on for other combinations
    // TODO all their to the separate logic surely
};

var biomeController = new BiomeController(biomeTerrainSymbols);

TerrainController terrainController = new TerrainController(16);
List<TerrainPoint> terrain = terrainController.GenerateTerrain(32, 16);
terrainController.ApplyPerlinNoise(terrain, 12, 4);
terrainController.PrintTerrain(terrain, 32, 16, biomeController);
