namespace CS.ProGenJourney.Models;

public class TerrainPoint
{
    public int X { get; set; }
    public int Y { get; set; }
    public double Height { get; set; }
    public TerrainType TerrainType { get; set; }
    public BiomeType BiomeType { get; set; }
}

