using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Julians skript koopiert
public class PlayerKirche : MonoBehaviour
{
    
    #region Variables
    public GameObject Rebell;
    public MessageBox messageBox;
    public static bool letztesBildWasEnabled = false;
    #endregion

    
    #region Coroutines
    private IEnumerator rebellenSequence()
    {
        Rebell.transform.position = new Vector3(Rebell.transform.position.x,7.9f,0);
        while (Rebell.transform.position.y < 11)
        {
            Rebell.transform.Translate(new Vector3(0,5,0)*Time.deltaTime);
            yield return new WaitForSeconds(0.003f);
        }

        yield return new WaitForSeconds(1);
        string[] speakers = {"Rebell", "Jordan"};
        string[] messages = {"jo lass mal die Regierung stürzen", "sPrICh DeUTsch dU HUso"};
        messageBox.ShowMessages(speakers, messages);
        yield return new WaitWhile(()=>messageBox.GetMessageActive());
        PlayerMovement.CanMove = false;
        yield return new WaitForSeconds(1);
        while (Rebell.transform.position.y > 7.9f)
        {
            Rebell.transform.Translate(new Vector3(0,-5,0)*Time.deltaTime);
            yield return new WaitForSeconds(0.003f);
        }
        Rebell.GetComponent<SpriteRenderer>().enabled = false;
        Rebell.transform.position = new Vector3(Rebell.transform.position.x,-6.34f, 0);
        PlayerMovement.CanMove = true;
    }
    #endregion

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("RebellenTrigger") && letztesBildWasEnabled && !GameData.Instance.RebelTriggered)
        {
            GameData.Instance.RebelTriggered = true;
            PlayerMovement.CanMove = false;
            Rebell.GetComponent<SpriteRenderer>().enabled = true;
            GameData.Instance.WasInChurch = true;
            StartCoroutine(rebellenSequence());
        }
    }
}
