using UnityEngine;

public class DetectBlack : DetectRun
{
    
    private const float SpeedBlack = 0.1f;

    [SerializeField] private Sprite runningSprite;
    
    protected override void SpecificStart()
    {
        Speed = SpeedBlack;
        SpecificUpdate();
    }
    
    protected override void SpecificUpdate()
    {
        if (Run)
            Direction = Player.transform.position.y >= transform.position.y ? Vector3.down : Vector3.up;
    }

    protected override void MoreSpecificDetectAction()
    {
        GetComponent<SpriteRenderer>().sprite = runningSprite;
    }

}
