using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public MessageBox messageBox;
    public GameObject Weapon;
    public GameObject bernd;
    public GameObject translator;
    public GameObject door;
    public GameObject terminal;

    public void kill()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        string[] messages = {
            "Bernd hat die Waffe vor dir erreicht und dich erschossen du startest das Spiel jetzt von Beginn ",
        };
        messageBox.ShowMonologue("",messages);
        StartCoroutine(waitForMessageBox());
    }

    IEnumerator waitForMessageBox()
    {
        yield return new WaitWhile(()=>messageBox.GetMessageActive());
        resetGame();
    }
    
    public void resetGame()
    {
        //Default Warden Alive state;
       // GameData.Instance.SetWardenAliveByIndex(0, true);
       // GameData.Instance.SetWardenAliveByIndex(1, true);
        PlayerMovement.CanMove = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Weapon.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.transform.position = new Vector3(-3, 2, 0);
        bernd.transform.position = new Vector3(-3.78164f,-7.73f,0);
        bernd.gameObject.GetComponent<SpriteRenderer>().sprite = bernd.GetComponent<Bernd>().alive;
        GameData.Instance.BerndDead = false;
        if (GameData.Instance.CanTranslate)
        {
            GameData.Instance.CanTranslate = false;
            translator.SetActive(true);
        }
        door.GetComponent<Door>().Close();
        door.transform.position = new Vector3(11,-13,0);
        terminal.GetComponent<DoorTerminal>().reset();
        Weapon.tag = "Untagged";
    }
    
    
}
