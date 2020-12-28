
public class GameData
{
    private static GameData instance;
    private GameData()
    {
        if (instance != null)
            return;
        instance = this;
    }
    public static GameData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameData();
            }
            return instance;
        }
    }
    
    public enum LastRoom
    {
        Lab, City, Kirche, Spaceship,Start
    };
    
    private LastRoom lastRoom = LastRoom.Start;

    public LastRoom setGetlastRoom
    {
        get
        {
            return lastRoom;
        }
        set
        {
            lastRoom = value;
        }
    }
}
