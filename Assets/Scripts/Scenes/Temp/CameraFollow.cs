using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Room room;

    private Vector3 _cameraPosition;
    private Vector2 _camHalfDim;
    private float _orthographicSize;
    private Vector3 _playerPosition;
    private bool _atLeftBorder, _atRightBorder, _atTopBorder, _atBottomBorder;
    // Start is called before the first frame update
    void Start()
    {
        _cameraPosition = transform.position;
        _camHalfDim = new Vector2(1.75f, 1f);
        _orthographicSize = GetComponent<Camera>().orthographicSize;
        _playerPosition = player.position;
        _cameraPosition = new Vector3(_playerPosition.x, _playerPosition.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (room)
        {
            _playerPosition = player.position;
            
            _atLeftBorder = (_playerPosition.x - (_camHalfDim.x * _orthographicSize)) < room.center.x - (room.width / 2);
            _atRightBorder = (_playerPosition.x + (_camHalfDim.x * _orthographicSize)) > room.center.x + (room.width / 2);
            _atTopBorder = (_playerPosition.y + (_camHalfDim.y * _orthographicSize)) > room.center.y + (room.height / 2);
            _atBottomBorder = (_playerPosition.y - (_camHalfDim.y * _orthographicSize)) < room.center.y - (room.height / 2);
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
