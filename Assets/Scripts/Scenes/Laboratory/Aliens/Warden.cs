using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

//Warden Objects require a SpriteRenderer
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Warden : DetectPlayer
{
    
    #region Constants
    
    private const float DelayShoot = 3f;
    
    #endregion

    #region Variables

    [SerializeField] private int index;
    [SerializeField] private Sprite dead;
    [SerializeField] private Sprite alive;
    [SerializeField] private float projectileVelocity;
    [SerializeField] private MessageBox box;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Light2D viewLight;
    [SerializeField] private SpriteRenderer stateRenderer;
    
    
    private SpriteRenderer _spriteRenderer;
    
    public Collider2D innerCollider;
    
    #endregion

    #region Methods

    protected override void SpecificStart()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if(!_spriteRenderer) throw new MissingMemberException();
        if (!GameData.Instance.GetWardenAliveByIndex(index))
        {
            //Show dead sprite
            _spriteRenderer.sprite = dead;
            stateRenderer.enabled = false;
            viewLight.enabled = false;
            //Disable Script to avoid further actions
            this.enabled = false;
        }
        else
        {
            viewLight.enabled = true;
            _spriteRenderer.sprite = alive;
        }
    }

    protected override void SpecificUpdate()
    {
        //Dont need that
    }

    protected override void SpecificDetectAction()
    {
        if (GameData.Instance.CanShoot)
        {
            //Player has Weapon -> Attack
            //Player gets a chance to defend himself
            ShootPlayer();
        }
        else
        {
            //Player has no Weapon -> Arrest
            ArrestPlayer();
        }
    }
    

    
    private void ShootPlayer()
    {
        StartCoroutine(Shoot());
    }

    private void ArrestPlayer()
    {
        //Disable PlayerMovement
        PlayerMovement.CanMove = false;
        //Tell the player what happend
        box.ShowMessage("Jordan","Verdammt ich wurde entdeckt!");
        StartCoroutine(Reset());
    }

    public void Kill()
    {
        //Log Death in GameData
        GameData.Instance.SetWardenAliveByIndex(index, false);
        //Change Sprite to dead state;
        _spriteRenderer.sprite = dead;
        stateRenderer.enabled = false;
        viewLight.enabled = false;
        //Disable Script to avoid further actions
        enabled = false;
        
    }

    #endregion
    
    #region Helper Functions
    
    private double VectorToAngle(Vector2 vector)
    {
        double angleDeg = 180 / Math.PI * Math.Asin(Math.Abs(vector.y) / vector.magnitude);
        
        if (vector.x < 0)
            angleDeg = 180 - angleDeg;
        if (vector.y < 0)
            angleDeg *= -1;

        return angleDeg;
    }
    
    public bool CompareInnerCollider(Collider2D otherCollider)
    {
        return otherCollider.Equals(innerCollider);
    }
    
    #endregion

    #region Coroutines
    
    IEnumerator Reset()
    {
        //Wait for player to read that hes been detected
        yield return new WaitWhile(box.GetMessageActive);
        DetectedPlayer = false;
        stateRenderer.enabled = false;
        viewLight.enabled = true;
        //restart idle action
        Idle idle = GetComponent<Idle>();
        if (idle)
        {
            idle.StartCoroutine(idle.LookAround());
        }
        //Initiate Player Reset
        Player.GetComponent<PlayerDeath>()?.resetGame();

    }
    
    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(DelayShoot / 3, DelayShoot));
        while (true)
        {
            Transform thisTransform = transform;
            Vector3 position = thisTransform.position;
            Vector3 projectileOffset = new Vector3(thisTransform.rotation.y == 0 ? 0.75f : -0.75f, 0.215f, 0f);
            Vector3 shootDirection = Player.transform.position - (position + projectileOffset);
            GameObject temp = Instantiate(projectile, position + projectileOffset, Quaternion.Euler(0, 0,(float) VectorToAngle(shootDirection)));
            temp.GetComponent<Rigidbody2D>().AddForce(shootDirection * projectileVelocity,ForceMode2D.Impulse);
            yield return new WaitForSeconds(DelayShoot);
        }
    }
    
    #endregion
}
