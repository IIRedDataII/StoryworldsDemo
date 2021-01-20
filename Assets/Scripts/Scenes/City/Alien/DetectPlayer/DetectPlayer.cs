using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public abstract class DetectPlayer : MonoBehaviour
{

    #region Constants
    
    private const float ViewDistance = 7f;
    private const int ViewRange = 45;   // something between 0 and 180
    
    #endregion
    
    #region Variables
    
    protected GameObject Player;
    
    protected bool DetectedPlayer;
    private bool _check;
    
    #endregion
    
    private void Start()
    {
        
        #region Initialization
        
        GetComponent<CapsuleCollider2D>().size = new Vector2(ViewDistance / 2, 1f);
        Light2D coneLight = GetComponentsInChildren<Light2D>()[0];
        coneLight.pointLightOuterRadius = ViewDistance;
        coneLight.pointLightInnerAngle = 2 * ViewRange;
        coneLight.pointLightOuterAngle = 2 * ViewRange;
        
        #endregion

        SpecificStart();
        
    }

    private void Update()
    {
        
        #region Field of View
        
        if (_check && !DetectedPlayer)
        {
            
            Transform thisTransform = transform;
            Vector3 position = thisTransform.position;
            Quaternion rotation = thisTransform.rotation;
            
            Debug.DrawLine(position, (Vector2) position + AngleToVector(rotation.y == 0 ? -ViewRange : 180 + ViewRange) * ViewDistance, Color.yellow);
            Debug.DrawLine(position, (Vector2) position + AngleToVector(rotation.y == 0 ? 0 : 180) * ViewDistance, Color.yellow);
            Debug.DrawLine(position, (Vector2) position + AngleToVector(rotation.y == 0 ? ViewRange : 180 - ViewRange) * ViewDistance, Color.yellow);
        
            Vector2 alienToPlayerVector = ((Vector2) Player.transform.position - (Vector2) position).normalized;
            double alienToPlayerAngle = VectorToAngle(alienToPlayerVector);
            bool looksRight = rotation.y == 0;
        
            if (looksRight ? (alienToPlayerAngle >= -ViewRange && alienToPlayerAngle <= ViewRange) : (alienToPlayerAngle >= 180 - ViewRange || alienToPlayerAngle <= - 180 + ViewRange))
            {
                Debug.DrawLine(position, position + (Vector3) alienToPlayerVector * ViewDistance, Color.red);
            
                RaycastHit2D hit = Physics2D.Raycast(position, alienToPlayerVector, ViewDistance);
                if (hit && hit.collider.CompareTag("Player"))
                {
                    DetectAction();
                    DetectedPlayer = true;
                }
            }
            
        }
        
        #endregion
        
        SpecificUpdate();
        
    }
    
    #region Abstract Functions
    
    protected abstract void SpecificStart();
    
    protected abstract void SpecificUpdate();
    
    protected abstract void SpecificDetectAction();

    #endregion

    #region Helper Functions

    private void DetectAction()
    {
        
        GetComponentsInChildren<SpriteRenderer>()[1].enabled = true;
        Pathing pathing = GetComponent<Pathing>();
        if (pathing)
            pathing.enabled = false;
        Idle idle = GetComponent<Idle>();
        if (idle)
        {
            idle.StopAllCoroutines();
            idle.enabled = false;
        }
            
        SpecificDetectAction();
        
    }
   
    private double VectorToAngle(Vector2 vector)
    {
        double angleDeg = 180 / Math.PI * Math.Asin(Math.Abs(vector.y) / vector.magnitude);
        
        if (vector.x < 0)
            angleDeg = 180 - angleDeg;
        if (vector.y < 0)
            angleDeg *= -1;

        return angleDeg;
    }
    
    private Vector2 AngleToVector(double angleDeg)
    {
        double angleRad = angleDeg * Math.PI / 180;
        return new Vector2((float) Math.Cos(angleRad), (float) Math.Sin(angleRad)).normalized;
    }
    
    #endregion
    
    #region Event Functions
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player = other.gameObject;
            _check = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!DetectedPlayer)
                Player = null;
            _check = false;
        }
    }
    
    #endregion
    
}
