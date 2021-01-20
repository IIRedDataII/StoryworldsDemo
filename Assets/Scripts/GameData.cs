/*
 * Suffixes:
 * DF: don't forget
 * NTH: nice to have
 * MH: must have
 */

using UnityEngine.SceneManagement;

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
    
    #region Scene
    
    public enum LastRoom
    {
        Start, Lab, Church, Spaceship, City
    };

    public LastRoom SetGetlastRoom { get; set; } = LastRoom.Start;
    
    #endregion
    
    #region Weapon

    public int Ammunition = 30;
    public int RoundsInMagazine = 7;
    public bool CanShoot = false;
    
    #endregion

    #region Laboratory

    public bool BerndDead = false;
    public bool CanTranslate = false;

    #endregion
    
    #region City
    
    public bool[] DeadAliens = new bool[21];
    
    #endregion
    
    #region Church

    public bool WasInChurch = false;
    public bool RebelTriggered = false;
    
    #endregion
    
    #region Spaceship

    public bool ReadFamilyLog = false;
    public bool ReadEarthLog = false;
    
    #endregion

    #region Laboratory

    public static bool[] WardenAlive =  {true,true,true};

    #region Helperfunctions

    public bool GetWardenAliveByIndex(int index)
    {
        return WardenAlive[index];
    }

    public void SetWardenAliveByIndex(int index, bool state)
    {
        WardenAlive[index] = state;
    }

    #endregion

    #endregion

    public void ResetGame()
    {
    
        SetGetlastRoom = LastRoom.Start;

        Ammunition = 30;
        RoundsInMagazine = 7;
        CanShoot = false;
        BerndDead = false;
        CanTranslate = false;

        for (int i = 0; i < 21; i++)
        {
            DeadAliens[i] = false;
        }
        WasInChurch = false;
        RebelTriggered = false;

        ReadFamilyLog = false;
        ReadEarthLog = false;
        
        WardenAlive[0] = true;
        WardenAlive[1] = true;
        WardenAlive[2] = true;
    
        SceneManager.LoadScene("Laboratory");
        
    }
    
}
