/*
 * T0d0 Suffixes:
 * DF: "don't forget"
 * NTH: "nice to have"
 * MH: "must have"
 *
 * Alreay in use One-Time-Message IDs:
 * {0}
 * 
 * Alreay in use Message-Node-IDs IDs:
 * {0}
 * 
 */

using System.Collections;
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
    
    #region Global
    
    public enum LastRoom
    {
        Start, Lab, Church, Spaceship, City
    };

    public LastRoom SetGetlastRoom { get; set; } = LastRoom.Start;
    public ArrayList TriggeredMonologueNodes = new ArrayList();
    public ArrayList TriggeredMessages = new ArrayList();
    
    #endregion
    
    #region Weapon

    public int Ammunition = 30;
    public int RoundsInMagazine = 7;
    public bool CanShoot;
    
    #endregion

    #region Laboratory

    public bool Respawned = false;
    public bool BerndDead;
    public bool CanTranslate;
    public bool[] DeadWardens = new bool[3];
    public bool[] WardenAlive =  {true, true, true};    // obsolete

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
    
        #region Global
        
        SetGetlastRoom = LastRoom.Start;
        TriggeredMonologueNodes.Clear();
        TriggeredMessages.Clear();
        
        #endregion

        #region Weapon
        
        Ammunition = 30;
        RoundsInMagazine = 7;
        CanShoot = false;
        
        #endregion
        
        #region Laboratory
        
        Respawned = true;   // default value: false
        BerndDead = false;
        CanTranslate = false;
        for (int i = 0; i < DeadWardens.Length; i++)
        {
            WardenAlive[i] = false;
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

        // no clue why, but this one doesn't reset upon reloading the city
        Surround.Trigger = false;
        
        #endregion
    
        SceneManager.LoadScene("Laboratory");
        
    }

}
