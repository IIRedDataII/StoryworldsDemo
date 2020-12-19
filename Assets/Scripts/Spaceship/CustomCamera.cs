using UnityEngine;

public class CustomCamera : MonoBehaviour
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