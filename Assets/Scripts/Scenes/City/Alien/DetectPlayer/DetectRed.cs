using UnityEngine;

public class DetectRed : DetectRun
{

    private const float SpeedRed = 0.1f;
    
    [SerializeField] private Sprite runningSprite;

    protected override void SpecificStart()
    {
        Speed = SpeedRed;
        Direction = Vector3.right;
    }
    
    protected override void SpecificUpdate()
    {
        
    }

    protected override void MoreSpecificDetectAction()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        GetComponent<SpriteRenderer>().sprite = runningSprite;
    }
    
}
