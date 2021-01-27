using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PlayerKirche : MonoBehaviour
{
    
    #region Constants

    private const float RebelHeight = 11.9f;
    
    #endregion
    
    #region Variables
    
    public MessageBox messageBox;
    public Font aurebeshFont;
    public Font translatedFont;
    public GameObject rebell;
    public GameObject projectile;
    public static bool LetztesBildWasEnabled = false;
    
    #endregion
    
    #region Coroutines
    
    private IEnumerator RebelSequenceTranslated()
    {
        GameData.Instance.RebelConversationHappened = true;
        rebell.transform.position = new Vector3(rebell.transform.position.x,7.9f,0);
        while (rebell.transform.position.y < RebelHeight)
        {
            rebell.transform.Translate(new Vector3(0,5,0) * Time.deltaTime);
            yield return new WaitForSeconds(0.003f);
        }

        yield return new WaitForSeconds(1);
        messageBox.ShowMessages(Texts.RebelDialogueTranslatedSpeakers, Texts.RebelDialogueTranslated);
        yield return new WaitWhile(()=>messageBox.GetMessageActive());
        Utils.SetPlayerControls(false);
        yield return new WaitForSeconds(1);
        while (rebell.transform.position.y > 7.9f)
        {
            rebell.transform.Translate(new Vector3(0,-5,0) * Time.deltaTime);
            yield return new WaitForSeconds(0.003f);
        }
        rebell.GetComponent<SpriteRenderer>().enabled = false;
        rebell.transform.position = new Vector3(rebell.transform.position.x,-6.34f, 0);
        Utils.SetPlayerControls(true);
    }
    
    private IEnumerator RebelSequence()
    {
        rebell.transform.position = new Vector3(rebell.transform.position.x,7.9f,0);
        while (rebell.transform.position.y < RebelHeight)
        {
            rebell.transform.Translate(new Vector3(0,5,0) * Time.deltaTime);
            yield return new WaitForSeconds(0.003f);
        }

        yield return new WaitForSeconds(1);
        messageBox.GetComponentInChildren<Text>().font = aurebeshFont;
        messageBox.ShowMonologue("Chia", Texts.RebelAurebeshMonologue);
        yield return new WaitWhile(() => messageBox.GetMessageActive());
        messageBox.GetComponentInChildren<Text>().font = translatedFont;
        Utils.SetPlayerControls(false);

        Vector3 playerPosition = transform.position;
        Vector2 playerToAlien = (rebell.transform.position - playerPosition).normalized;
        GameObject shotProjectile = Instantiate(projectile, playerPosition, Quaternion.Euler(0f, 0f, (float) Utils.VectorToAngle(playerToAlien) - 90));
        shotProjectile.GetComponent<Rigidbody2D>().AddForce(playerToAlien * 10, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1);
        messageBox.ShowMonologue("Jordan", Texts.ShotRebelMonologue);
        
        Utils.SetPlayerControls(true);
    }
    
    #endregion
    
    #region Event Functions
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("RebellenTrigger") && LetztesBildWasEnabled && !GameData.Instance.RebelTriggered)
        {
            GameData.Instance.RebelTriggered = true;
            Utils.SetPlayerControls(false);
            rebell.GetComponent<SpriteRenderer>().enabled = true;
            GameData.Instance.WasInChurch = true;
            StartCoroutine(GameData.Instance.CanTranslate ? RebelSequenceTranslated() : RebelSequence());
        }
        
    }
    
    #endregion
    
}
