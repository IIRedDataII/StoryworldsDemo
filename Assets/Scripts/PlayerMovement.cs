using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 direction;
    [SerializeField]
    private float speed = 10;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = GameData.Instance.setGetlastRoom == GameData.LastRoom.Start ? new Vector3(-6.14f,1.77f,0) : new Vector3(46.74f,-13,0);
        rb = this.GetComponent<Rigidbody2D>();
        direction = Vector2.zero;
        GameData.Instance.setGetlastRoom = GameData.LastRoom.Lab;
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        rb.velocity = (direction * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("ScenenWechsel"))
        {
            SceneManager.LoadScene("City");
        }
    }
}
