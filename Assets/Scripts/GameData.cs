public class GameData
{
    
    #region Singleton Pattern
    
    private static GameData _instance;
    
    private GameData()
    {
        if (_instance != null)
            return;
        _instance = this;
    }
    
    public static GameData Instance => _instance ?? (_instance = new GameData());

    #endregion
    
    #region LastRoom
    
    public enum LastRoom
    {
        Start, Lab, Church, Spaceship, City
    };

    public LastRoom SetGetlastRoom { get; set; } = LastRoom.Start;
    
    #endregion
    
    public bool WasInChurch = false;
    public bool RebelTriggered = false;
    public bool BerndDead = false;

    public int Ammunition =  15;
    public int RoundsInMagazine = 7;
}
