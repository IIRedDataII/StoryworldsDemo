using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public MessageBox messageBox;
    public GameObject Weapon;
    public GameObject bernd;

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
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Weapon.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.transform.position = new Vector3(-3, 2, 0);
        bernd.transform.position = new Vector3(-19.75f,-2.84f,0);
        bernd.gameObject.GetComponent<SpriteRenderer>().sprite = bernd.GetComponent<Bernd>().alive;
        GameData.Instance.BerndDead = false;
    }
    
    
}
