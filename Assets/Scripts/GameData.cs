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
    
    #region WeaponValues
    
    public int Ammunition = 20;
    public int RoundsInMagazine = 7;
    public bool CanShoot = false;
    
    #endregion

    #region Laboratory

    public bool BerndDead = false;
    public bool CanTranslate = false;

    #endregion
    
    #region CityAliens
    
    public bool[] DeadAliens = new bool[20];
    
    #endregion
    
    #region Church
    
    public bool WasInChurch = false;
    public bool RebelTriggered = false;
    
    #endregion

}
