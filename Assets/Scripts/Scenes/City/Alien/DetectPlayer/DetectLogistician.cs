using System.Collections;
using UnityEngine;

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

        if (GameData.Instance.RebelTriggered)
        {
            string[] messages =
            {
                "Bis auf diese Rebellengruppierung scheinen mich wirklich alle zu fürchten oder umbringen zu wollen.",
                "Vielleicht kann ich mit meinem Status in ihrer Religion tatsächlich etwas bewirken?"
            };
            messageBox.ShowMonologueOnce("Jordan", messages, 0);
        }
        else
        {
            string[] messages =
            {
                "Warum wollen mich alle entweder umbringen, oder haben Angst vor mir?",
                "Ich bin ein Alien für sie, genau so wie sie für mich, aber man könnte meinen, es gäbe hier IRGENDWEN, der mir nicht sofort feindlich begegnet.",
                "Ich muss hier weg! Der Planet ist bewohnbar aber diese Wesen hassen Fremdlinge! Sie werden mich früher oder später umbringen!"
            };
            messageBox.ShowMonologueOnce("Jordan", messages, 0);
        }
        
    }
    
    #endregion
    
}
