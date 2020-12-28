using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class PlayerBehaviour : MonoBehaviour
{
    
    #region Variables
    // Constants
    private const float Speed = 10f;
    // variables
    private Rigidbody2D _rigidbody;
    private bool canMove;
    private bool blockEForThisFrame;
    #endregion

    private void Start()
    {
        #region Initialization
        canMove = true;
        _rigidbody = GetComponent<Rigidbody2D>();
        #endregion

        switch (GameData.Instance.setGetlastRoom)
        {
           case GameData.LastRoom.Lab:gameObject.transform.position = new Vector3(-18.5f,-6,0);
               break;
           case GameData.LastRoom.Kirche:gameObject.transform.position = new Vector3(16.6f,-9,0);
               break;
           case GameData.LastRoom.Spaceship:gameObject.transform.position = new Vector3(17.5f,14,0);
               break;
           default: gameObject.transform.position = new Vector3(9,-9,0);
               break;
        }

        GameData.Instance.setGetlastRoom = GameData.LastRoom.City;
    }

    private void Update()
    {
        #region Movement
        if (canMove)
        {
            _rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * Speed;
        }
        #endregion
    }
    
}
