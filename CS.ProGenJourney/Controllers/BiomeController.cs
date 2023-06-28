using CS.ProGenJourney.Models;

namespace CS.ProGenJourney.Controllers;

public class BiomeController
{
    // make a biome hash tab
    private Dictionary<TerrainType, (char Symbol, ConsoleColor Color)> BiomeSymbols;


    public BiomeController(Dictionary<TerrainType, (char Symbol, ConsoleColor Color)> biomeSymbols)
    {
        BiomeSymbols = new Dictionary<TerrainType, (char, ConsoleColor)>
        {
            {TerrainType.Water, ('~', ConsoleColor.Blue)},
            {TerrainType.Grass, ('.', ConsoleColor.Green)},
            {TerrainType.Hill, ('o', ConsoleColor.DarkYellow)},
            {TerrainType.Mountain, ('^', ConsoleColor.Gray)},
        };
    }

    public (char Symbol, ConsoleColor Color) GetBiomeSymbol(TerrainType type)
    {
        return BiomeSymbols[type];
    }
    
    
}