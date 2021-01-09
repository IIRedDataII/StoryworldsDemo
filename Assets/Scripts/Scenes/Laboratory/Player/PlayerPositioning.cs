using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositioning : MonoBehaviour
{
    
    private void Start()
    {
        gameObject.transform.position = GameData.Instance.setGetlastRoom == GameData.LastRoom.Start ? new Vector3(-6.14f,1.77f,0) : new Vector3(46.74f,-13,0);
        GameData.Instance.setGetlastRoom = GameData.LastRoom.Lab;
    }

}
