using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Physic {
    public float maxSpeed = 7f;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    //untuk mengetahui arah hadap pada player
    public bool isFacingRight = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        targetVelocity = Vector2.left * maxSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LeftBound"))
        {
            Flip();
            targetVelocity = Vector2.right * maxSpeed;
        }

        if (collision.gameObject.CompareTag("RightBound"))
        {
            Flip();
            targetVelocity = Vector2.left * maxSpeed;
        }
    }

    private void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        isFacingRight = !isFacingRight;
    }
}
