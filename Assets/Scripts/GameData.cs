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
    public bool CanShoot;
    
    #endregion

    #region Laboratory

    public bool Respawned = true;
    public bool BerndDead;
    public bool CanTranslate;
    public bool[] DeadWardens = new bool[3];
    public bool[] WardenAlive =  {true, true, true};

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
    
    #region City
    
    public bool[] DeadAliens = new bool[21];
    
    #endregion
    
    #region Church

    public bool WasInChurch;
    public bool RebelTriggered;
    
    #endregion
    
    #region Spaceship

    public bool ReadFamilyLog;
    public bool ReadEarthLog;
    
    #endregion
    
    public void ResetGame()
    {
    
        #region Scene
        
        SetGetlastRoom = LastRoom.Start;
        
        #endregion

        #region Weapon
        
        Ammunition = 30;
        RoundsInMagazine = 7;
        CanShoot = false;
        
        #endregion
        
        #region Laboratory
        
        // do NOT reset SeenIntro
        BerndDead = false;
        CanTranslate = false;
        for (int i = 0; i < DeadWardens.Length; i++)
        {
            WardenAlive[i] = false;
        }
        for (int i = 0; i < WardenAlive.Length; i++)
        {
            WardenAlive[i] = true;
        }
        
        #endregion 

        #region City
        
        for (int i = 0; i < DeadAliens.Length; i++)
        {
            DeadAliens[i] = false;
        }
        
        #endregion
        
        #region Church
        
        WasInChurch = false;
        RebelTriggered = false;
        
        #endregion

        #region Spaceship
        
        ReadFamilyLog = false;
        ReadEarthLog = false;
        
        #endregion
        
        #region WTF

        // no clue why, but this guy doesn't reset upon reloading the city
        Surround.Trigger = false;
        
        #endregion
    
        SceneManager.LoadScene("Laboratory");
        
    }

}
