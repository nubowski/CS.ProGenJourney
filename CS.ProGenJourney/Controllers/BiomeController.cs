using CS.ProGenJourney.Models;

namespace CS.ProGenJourney.Controllers;

public class BiomeController
{
    // make a biome hash tab
    private Dictionary<(TerrainType, BiomeType), (char Symbol, ConsoleColor Color)> _biomeTerrainSymbols;


    public BiomeController(Dictionary<(TerrainType, BiomeType), (char Symbol, ConsoleColor Color)> biomeTerrainSymbols)
    {
        _biomeTerrainSymbols = biomeTerrainSymbols;
    }

    public (char Symbol, ConsoleColor Color) GetBiomeSymbol(TerrainType terrain, BiomeType biome)
    {
        return _biomeTerrainSymbols[(terrain, biome)];
    }
    
    
}