using CS.ProGenJourney.Models;

namespace CS.ProGenJourney.Controllers;

public class DungeonController
{
    public List<Room> GenerateDungeon(int numberOfRooms)
    {
        List<Room> dungeon = new List<Room>();
        Random rand = new Random();

        for (int i = 0; i < numberOfRooms; i++)
        {
            dungeon.Add(new Room { Width = rand.Next(5, 15), Height = rand.Next(5, 15)});
        }

        return dungeon;
    }
}