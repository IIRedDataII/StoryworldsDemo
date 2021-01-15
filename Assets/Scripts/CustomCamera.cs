using UnityEngine;

public class CustomCamera : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private Transform _cameraTransform;

    private void Start()
    {
        _cameraTransform = transform;
    }
    
    private void Update()
    {
        Vector2 playerPosition = player.transform.position;
        _cameraTransform.position = new Vector3(playerPosition.x, playerPosition.y, _cameraTransform.position.z);
    }
    
}
