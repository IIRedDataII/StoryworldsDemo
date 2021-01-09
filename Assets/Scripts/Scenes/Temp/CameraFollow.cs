using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Room room;
    
    private Vector2 camHalfDim;
    private Camera cam;

    private bool _atLeftBorder, _atRightBorder, _atTopBorder, _atBottomBorder;
    // Start is called before the first frame update
    void Start()
    {
        camHalfDim = new Vector2(1.75f, 1f);
        cam = GetComponent<Camera>();
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(room)
        {
            _atLeftBorder = (player.position.x - (camHalfDim.x * cam.orthographicSize)) < room.center.x - (room.width / 2);
            _atRightBorder = (player.position.x + (camHalfDim.x * cam.orthographicSize)) > room.center.x + (room.width / 2);
            _atTopBorder = (player.position.y + (camHalfDim.y * cam.orthographicSize)) > room.center.y + (room.height / 2);
            _atBottomBorder = (player.position.y - (camHalfDim.y * cam.orthographicSize)) < room.center.y - (room.height / 2);
            if ((_atLeftBorder || _atRightBorder) && (_atTopBorder || _atBottomBorder))
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            else if (_atLeftBorder || _atRightBorder)
                transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
            else if (_atTopBorder || _atBottomBorder)
                transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
            else
                transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
    }
}
