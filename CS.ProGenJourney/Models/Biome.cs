namespace CS.ProGenJourney.Models;

public class Biome
{
    public string Name { get; set; }
    public ConsoleColor Color { get; set; } // later for another coloring
}

public enum BiomeType
{
    Swamp,
    Plains,
    DarkForest,
    Desert,
    Snow
}