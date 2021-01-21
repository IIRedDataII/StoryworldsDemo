using System.Collections;
using UnityEngine;

public class DetectWorker : DetectRun
{
    
    #region Constants
    
    private const float SpeedBlack = 0.2f;
    private const float RecognizeDelayBlack = 1f;
    
    #endregion

    #region Variables
    
    // Unity variables
    [SerializeField] private Sprite runningSprite;
    
    #endregion
    
    #region Override Functions
    
    protected override void SpecificStart()
    {
        Speed = SpeedBlack;
        RecognizeDelay = RecognizeDelayBlack;
        SpecificUpdate();
    }
    
    protected override void SpecificUpdate()
    {
        if (Run)
            Direction = Player.transform.position.y >= transform.position.y ? Vector3.down : Vector3.up;
    }

    protected override void SpecificDetectAction()
    {
        
        StartCoroutine(RecognizeBlack());
    }
    
    #endregion
 
    #region Coroutines
    
    private IEnumerator RecognizeBlack()
    {
        yield return new WaitForSeconds(RecognizeDelay);
        Run = true;
        GetComponent<SpriteRenderer>().sprite = runningSprite;
    }
    
    #endregion
    
}
