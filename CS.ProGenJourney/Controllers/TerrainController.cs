using System.Numerics;
using CS.ProGenJourney.Models;

namespace CS.ProGenJourney.Controllers;

public class TerrainController
{
    private Vector2[,] _gradients;
    private int _gridSize;
    private Random _rand;

    public TerrainController(int gridSize)
    {
        this._gridSize = gridSize;
        
        // rnd gen
        _rand = new Random();
        // grid
        _gradients = new Vector2[gridSize, gridSize];
        GenerateGradients();
    }

    private void GenerateGradients()
    {
        for (int i = 0; i < _gridSize; i++)
        {
            for (int j = 0; j < _gridSize; j++)
            {
                // rnd angle
                double randomAngle = _rand.NextDouble() * 2 * Math.PI;
                // vector from angle
                _gradients[i, j] = new Vector2((float) Math.Cos(randomAngle), (float) Math.Sin(randomAngle));

            }
        }
    }

    private double Perlin(double x, double y)
    {
        // Calculate the grid cell coordinates
        int x0 = (x > 0.0 ? (int)x : (int)x - 1);
        int x1 = x0 + 1;
        int y0 = (y > 0.0 ? (int)y : (int)y - 1);
        int y1 = y0 + 1;

        // Calculate the interpolation weights
        double sx = x - x0;
        double sy = y - y0;

        // Interpolate between grid point gradients
        double n0, n1, ix0, ix1, value;
        n0 = DotGridGradient(x0, y0, x, y);
        n1 = DotGridGradient(x1, y0, x, y);
        ix0 = Interpolate(n0, n1, sx);
        n0 = DotGridGradient(x0, y1, x, y);
        n1 = DotGridGradient(x1, y1, x, y);
        ix1 = Interpolate(n0, n1, sx);
        value = Interpolate(ix0, ix1, sy);

        return value;
    }

    private double DotGridGradient(int ix, int iy, double x, double y)
    {
        // wrap to prevent out of array exception
        ix = Math.Abs(ix) % _gridSize;
        iy = Math.Abs(iy) % _gridSize;
        
        // comp the dist vector
        double dx = x - ix;
        double dy = y - iy;
        
        // comp return a `dot-product`
        return (dx * _gradients[ix, iy].X + dy * _gradients[ix, iy].Y);
    }

    private double Interpolate(double a0, double a1, double w)
    {
        // improve interpolation by smooth
        w = Smooth(w);
        // interpolate between a0 - a1 based on should be a smooth curve that yiends 0.0 at a0 and 1.0 at a1
        return (1.0 - w) * a0 + w * a1;
    }

    private double ScaleHeight(double height)
    {
        // normalize values from -1 to 1 to 0 to 1
        height = (height + 1) * 0.5;
        // scale to range
        double min = 0;
        double max = 100;
        return min + (height * (max - min));
    }

    private double Smooth(double x)
    {
        // func that smooths
        // 6x^5 - 15x^4 + 10x^3
        return x * x * x *(x * (x * 6 - 15) + 10);
    }

    public void ApplyPerlinNoise(List<TerrainPoint> terrain, double scale)
    {
        foreach (var terrainPoint in terrain)
        {
            // extreme values will be more common (math.pow)
            double perlinValue = Perlin(terrainPoint.X / scale, terrainPoint.Y / scale);
            terrainPoint.Height = ScaleHeight(perlinValue);

            if (terrainPoint.Height < 35)
            {
                terrainPoint.Type = TerrainType.Water;
            }
            else if (terrainPoint.Height < 50)
            {
                terrainPoint.Type = TerrainType.Grass;
            }
            else if (terrainPoint.Height < 65)
            {
                terrainPoint.Type = TerrainType.Hill;
            }
            else if (terrainPoint.Height < 100)
            {
                terrainPoint.Type = TerrainType.Mountain;
            }
        }
    }

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

    public void PrintTerrain(List<TerrainPoint> terrain, int width, int height)
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                TerrainPoint point = terrain[y * width + x];
                char c;
                switch (point.Type)
                {
                    case TerrainType.Water:
                        c = '~';
                        break;
                    case TerrainType.Grass:
                        c = '.';
                        break;
                    case TerrainType.Hill:
                        c = 'o';
                        break;
                    case TerrainType.Mountain:
                        c = '^';
                        break;
                    default:
                        throw new AggregateException("Unknown terrain type");
                }
                Console.Write(c);
            }
            Console.WriteLine();
        }
    }
    
}