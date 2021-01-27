using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class DetectLogistician : DetectRun
{

    #region Constants
    
    private const float SpeedRed = 0.3f;
    private const float RecognizeDelayRed = 0.5f;
    
    #endregion
    
    #region Variables
    
    // Unity variables
    [SerializeField] private Sprite runningSprite;
    [SerializeField] private MessageBox messageBox;
    
    #endregion

    #region Override Functions
    
    protected override void SpecificStart()
    {
        Speed = SpeedRed;
        RecognizeDelay = RecognizeDelayRed;
        Direction = Vector3.right;
    }
    
    protected override void SpecificUpdate()
    {
        
    }

    protected override void SpecificDetectAction()
    {
        StartCoroutine(RecognizeRed());
    }
    
    #endregion
    
    #region Coroutines
    
    private IEnumerator RecognizeRed()
    {
        yield return new WaitForSeconds(RecognizeDelay);
        Run = true;
        GetComponent<SpriteRenderer>().sprite = runningSprite;
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (GameData.Instance.RebelConversationHappened)
        {
            messageBox.ShowMonologueOnce("Jordan", Texts.TriggerLogisticianFullMonologue, GameData.OneTimeMessageID.TriggerLogistician);
        }
        else
        {
            messageBox.ShowMonologueOnce("Jordan", Texts.TriggerLogisticianHalfMonologue, GameData.OneTimeMessageID.TriggerLogistician);
        }
        
    }
    
    #endregion
    
}
