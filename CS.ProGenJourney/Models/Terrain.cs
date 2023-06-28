using System.Drawing;

namespace CS.ProGenJourney.Models;

public class Terrain
{
    public int Width { get; set; }
    public int Height { get; set; }
    public string Type { get; set; }
    public List<TerrainPoint> Shape { get; set; }
}

public enum TerrainType
{
    Water,
    Grass,
    Hill,
    Mountain
}