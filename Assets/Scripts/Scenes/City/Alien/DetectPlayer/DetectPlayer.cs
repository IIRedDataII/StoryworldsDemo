using System;
using UnityEngine;

public abstract class DetectPlayer : MonoBehaviour
{

    #region Constants
    
    private const float ViewDistance = 8f;
    private const int ViewRange = 45;   // something between 0 and 180
    
    #endregion
    
    #region Variables
    
    private bool _check;
    private GameObject _player;
    
    #endregion
    
    private void Start()
    {
        
        #region Initialization
        
        GetComponent<CapsuleCollider2D>().size = new Vector2(ViewDistance / 2, 1f);
        
        #endregion
        
    }

    private void Update()
    {
        
        #region Field of View
        
        if (_check)
        {
            
            Transform thisTransform = transform;
            Vector3 position = thisTransform.position;
            Quaternion rotation = thisTransform.rotation;
            
            Debug.DrawLine(position, (Vector2) position + AngleToVector(rotation.y == 0 ? -ViewRange : 180 + ViewRange) * ViewDistance, Color.yellow);
            Debug.DrawLine(position, (Vector2) position + AngleToVector(rotation.y == 0 ? 0 : 180) * ViewDistance, Color.yellow);
            Debug.DrawLine(position, (Vector2) position + AngleToVector(rotation.y == 0 ? ViewRange : 180 - ViewRange) * ViewDistance, Color.yellow);
        
            Vector2 alienToPlayerVector = ((Vector2) _player.transform.position - (Vector2) position).normalized;
            double alienToPlayerAngle = VectorToAngle(alienToPlayerVector);
            bool looksRight = rotation.y == 0;
        
            if (looksRight ? (alienToPlayerAngle >= -ViewRange && alienToPlayerAngle <= ViewRange) : (alienToPlayerAngle >= 180 - ViewRange || alienToPlayerAngle <= - 180 + ViewRange))
            {
                Debug.DrawLine(position, position + (Vector3) alienToPlayerVector * ViewDistance, Color.red);
            
                RaycastHit2D hit = Physics2D.Raycast(position, alienToPlayerVector, ViewDistance);
                if (hit && hit.collider.gameObject.tag.Equals("Player"))
                {
                    DetectAction();
                }
            }
            
        }
        
        #endregion
        
    }
    
    #region Abstract Functions
    
    protected abstract void DetectAction();
    
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
    
    private Vector2 AngleToVector(double angleDeg)
    {
        double angleRad = angleDeg * Math.PI / 180;
        return new Vector2((float) Math.Cos(angleRad), (float) Math.Sin(angleRad)).normalized;
    }
    
    #endregion
    
    #region Event Functions
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            _player = other.gameObject;
            _check = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            _player = null;
            _check = false;
        }
    }
    
    #endregion
    
}
