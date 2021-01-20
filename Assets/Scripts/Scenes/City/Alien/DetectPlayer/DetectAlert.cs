using System.Collections;
using UnityEngine;

public abstract class DetectAlert : DetectPlayer
{

    #region Variables
    
    // Unity variables
    [SerializeField] protected Sprite dot1;
    [SerializeField] protected Sprite dot2;
    [SerializeField] protected Sprite dot3;
    [SerializeField] protected Sprite exclamationMark3;
    
    // private variables
    private bool _trackPlayer;
    
    // protected variables
    protected float Delay;
    
    #endregion

    #region Override Functions
    
    protected override void SpecificUpdate()
    {
        if (_trackPlayer)
            transform.rotation = Quaternion.Euler(0, Player.transform.position.x < transform.position.x ? 180 : 0, 0);
    }

    protected override void SpecificDetectAction()
    {
        _trackPlayer = true;
        StartCoroutine(Alert());
    }
    
    #endregion

    #region Helper Functions
    
    private void SurroundPlayer()
    { 
        Utils.SetPlayerControls(false);
        Surround.Trigger = true;
    }
    
    #endregion
    
    #region Coroutines
    
    private IEnumerator Alert()
    {
        SpriteRenderer stateSpriteRenderer = GetComponentsInChildren<SpriteRenderer>()[1];
        yield return new WaitForSeconds(Delay / 4);
        stateSpriteRenderer.sprite = dot1;
        yield return new WaitForSeconds(Delay / 4);
        stateSpriteRenderer.sprite = dot2;
        yield return new WaitForSeconds(Delay / 4);
        stateSpriteRenderer.sprite = dot3;
        yield return new WaitForSeconds(Delay / 4);
        stateSpriteRenderer.sprite = exclamationMark3;
        SurroundPlayer();
    }
    
    #endregion

}
