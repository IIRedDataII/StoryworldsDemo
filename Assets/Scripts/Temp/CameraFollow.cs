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
        AdjustPosition();
        _cameraPosition = new Vector3(_playerPosition.x, _playerPosition.y, -10);
    }

    // Update is called once per frame
    void Update()
    {
        if (room)
        {
            AdjustPosition();
        }
    }

    private void AdjustPosition()
    {
        _playerPosition = player.position;
        _cameraPosition = transform.position;
            
        _atLeftBorder = (_playerPosition.x - (_camHalfDim.x * _orthographicSize)) <= room.center.x - (room.width / 2);
        _atRightBorder = (_playerPosition.x + (_camHalfDim.x * _orthographicSize)) >= room.center.x + (room.width / 2);
        _atTopBorder = (_playerPosition.y + (_camHalfDim.y * _orthographicSize)) >= room.center.y + (room.height / 2);
        _atBottomBorder = (_playerPosition.y - (_camHalfDim.y * _orthographicSize)) <= room.center.y - (room.height / 2);
        
        Vector3 pos = new Vector3(_playerPosition.x,_playerPosition.y,-10);
        if (_atLeftBorder)
        {
            pos.x = room.center.x - (room.width / 2) + (_camHalfDim.x * _orthographicSize);
        }
        else if (_atRightBorder)
        {
            pos.x = room.center.x + (room.width / 2) - (_camHalfDim.x * _orthographicSize);
        }

        if (_atBottomBorder)
        {
            pos.y = room.center.y - (room.height / 2) + (_camHalfDim.y * _orthographicSize);
        }
        else if (_atTopBorder)
        {
            pos.y = room.center.y + (room.height / 2) - (_camHalfDim.y * _orthographicSize);
        }
        _cameraPosition = pos;
        transform.position = _cameraPosition;
    }
}
