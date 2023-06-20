using System.Reflection.Metadata.Ecma335;
using CS.ProGenJourney.Models;

namespace CS.ProGenJourney.Controllers;

public class TerrainController
{
    public List<TerrainPoint> GenerateTerrain(int width, int height)
    {
        List<TerrainPoint> terrain = new List<TerrainPoint>();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                terrain.Add(new TerrainPoint {X = x, Y = y});
            }
        }

        return terrain;
    }
    
}