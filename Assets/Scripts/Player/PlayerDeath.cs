using System.Collections;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    
    /* old code
    public MessageBox messageBox;
    public GameObject weapon;
    public GameObject bernd;
    public GameObject translator;
    public GameObject door;
    public GameObject terminal;

    public void Kill()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        string[] messages = {
            "Bernd hat die Waffe vor dir erreicht und dich erschossen du startest das Spiel jetzt von Beginn ",
        };
        messageBox.ShowMonologue("",messages);
        StartCoroutine(WaitForMessageBox());
    }

    private IEnumerator WaitForMessageBox()
    {
        yield return new WaitWhile(()=>messageBox.GetMessageActive());
        //ResetGame();
        GameData.Instance.ResetGame();
    }
    
    public void ResetGame()
    {
        //Default Warden Alive state;
        GameData.Instance.SetWardenAliveByIndex(0, true);
        GameData.Instance.SetWardenAliveByIndex(1, true);
        GameData.Instance.SetWardenAliveByIndex(2, true);
        PlayerMovement.CanMove = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        weapon.GetComponent<SpriteRenderer>().enabled = true;
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
        weapon.tag = "Untagged";
    }
    */

    [SerializeField] private MessageBox messageBox;
    [SerializeField] private Sprite playerDead;

    public void Die(string[] deathMessages)
    {
        GetComponent<SpriteRenderer>().sprite = playerDead;
        messageBox.ShowDeathMessages(deathMessages);
        StartCoroutine(DelayedResetGame());
    }
    
    private IEnumerator DelayedResetGame()
    {
        yield return new WaitWhile(() => messageBox.GetMessageActive());
        GameData.Instance.ResetGame();
    }
    
}
