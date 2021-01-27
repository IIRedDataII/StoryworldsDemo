﻿/*
 * T0d0 Suffixes:
 * DF: "don't forget"
 * NTH: "nice to have"
 * MH: "must have"
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

    
    public enum MonologueNodeID
    {
        AtWindowBernd,
        AtHallwayCapsule,
        AtExperimentTable,
        EnterWardenRoom,
        EnterCity,
        AtSoldierArea,
        AtSpaceship,
        EnterChurch,
        AtAltar,
        EnterSpaceship,
        EnterMainRoom
    }
    
    public enum OneTimeMessageID
    {
        PreStoneplate,
        TriggerLogistician,
    }

    public ArrayList TriggeredMessages = new ArrayList();
    public ArrayList TriggeredMonologueNodes = new ArrayList();
    
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
    public bool SeenBernd;
    public bool[] DeadWardens = new bool[3];

    #endregion
    
    #region City
    
    public bool[] DeadAliens = new bool[21];
    
    #endregion
    
    #region Church

    public bool WasInChurch;
    public bool RebelTriggered;
    public bool RebelConversationHappened;
    
    #endregion
    
    #region Spaceship

    public bool ReadFamilyLog;
    public bool ReadEarthLog;
    
    #endregion
    
    public void ResetGame()
    {
    
        #region Global
        
        SetGetlastRoom = LastRoom.Start;
        TriggeredMessages.Clear();
        TriggeredMonologueNodes.Clear();
        
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
        SeenBernd = false;
        for (int i = 0; i < DeadWardens.Length; i++)
        {
            DeadWardens[i] = false;
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
        RebelConversationHappened = false;
        
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
