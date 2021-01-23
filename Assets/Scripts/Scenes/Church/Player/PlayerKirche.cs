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
    public GameObject rebell;
    public MessageBox messageBox;
    public static bool LetztesBildWasEnabled = false;
    #endregion

    
    #region Coroutines
    private IEnumerator RebellenSequence()
    {
        rebell.transform.position = new Vector3(rebell.transform.position.x,7.9f,0);
        while (rebell.transform.position.y < 11)
        {
            rebell.transform.Translate(new Vector3(0,5,0)*Time.deltaTime);
            yield return new WaitForSeconds(0.003f);
        }

        yield return new WaitForSeconds(1);
        messageBox.ShowMessages(Texts.RebelDialogueSpeakers, Texts.RebelDialogue);
        yield return new WaitWhile(()=>messageBox.GetMessageActive());
        PlayerMovement.CanMove = false;
        yield return new WaitForSeconds(1);
        while (rebell.transform.position.y > 7.9f)
        {
            rebell.transform.Translate(new Vector3(0,-5,0)*Time.deltaTime);
            yield return new WaitForSeconds(0.003f);
        }
        rebell.GetComponent<SpriteRenderer>().enabled = false;
        rebell.transform.position = new Vector3(rebell.transform.position.x,-6.34f, 0);
        Utils.SetPlayerControls(true);
    }
    #endregion

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("RebellenTrigger") && LetztesBildWasEnabled && !GameData.Instance.RebelTriggered)
        {
            GameData.Instance.RebelTriggered = true;
            Utils.SetPlayerControls(false);
            rebell.GetComponent<SpriteRenderer>().enabled = true;
            GameData.Instance.WasInChurch = true;
            StartCoroutine(RebellenSequence());
        }
    }
}
