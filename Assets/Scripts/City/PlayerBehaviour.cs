using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    
    private void Start()
    {

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
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("ScenenWechsel"))
        {
            if (other.gameObject.name.Equals("ScenenWechsel (C->Ship)"))
            {
                SceneManager.LoadScene("Spaceship");
            }
            
            if (other.gameObject.name.Equals("ScenenWechsel (C->Kirche)"))
            {
                SceneManager.LoadScene("Church");
            }
            
            if (other.gameObject.name.Equals("ScenenWechsel (C->Lab)"))
            {
                SceneManager.LoadScene("Laboaratory");
            }
        }
    }
}
