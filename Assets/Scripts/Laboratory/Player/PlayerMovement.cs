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

    public bool canMove
    {
        set;
        private get;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        direction = Vector2.zero;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        else
        {
            direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = (direction * speed);
    }

    
}