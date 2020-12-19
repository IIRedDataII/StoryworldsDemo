using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public GameObject player;
    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = transform;
    }
    
    private void Update()
    {
        Vector2 playerPosition = player.transform.position;
        cameraTransform.position = new Vector3(playerPosition.x, playerPosition.y, cameraTransform.position.z);
    }
    
}
