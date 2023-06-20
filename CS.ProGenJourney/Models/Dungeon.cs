using System.Drawing;

namespace CS.ProGenJourney.Models;

public class Dungeon
{ 
    public int NumberOfRooms { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public Dictionary<TerrainPoint, Room> Map { get; set; }
}