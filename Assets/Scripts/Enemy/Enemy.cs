using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.5f;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private SpriteRenderer sr;

    private Rigidbody2D rb;
   


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (player == true)
        {
            LookAtPlayer();

            Vector2 target = new Vector2(player.position.x, player.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
           
    }
    private void LookAtPlayer()
    {
        
        sr.flipX = player.transform.position.x < transform.position.x;
    }
}
