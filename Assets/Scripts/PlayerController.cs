using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //animator dari player
    Animator anim;
    //rigidbody dari player
    Rigidbody2D rigidbody2D;
    //untuk mengetahui arah hadap pada player
    public bool isFacingRight = true;
    //besar gaya untuk mengangkat keatas
    public float jumpForce = 200f;
    //besar gaya untuk mendorong karakter kesamping
    public float walkForce = 15f;
    // kecepatan maksimum dari karakter utama
    public float maxSpeed = 1.5f;


    //untuk menyimpan state apakah karakter berada di ground
    public bool isGrounded = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        InputHandler();
        Debug.Log("velocity x : " + rigidbody2D.velocity.x);
        anim.SetInteger("SpeedPlayer", (int) rigidbody2D.velocity.x);
	}

    private void InputHandler()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * jumpForce);
    }

    private void MoveRight()
    {
        if (rigidbody2D.velocity.x * 1 < maxSpeed)
        {
            rigidbody2D.AddForce(Vector2.right * walkForce);

        }
        // membalik arah karakter apabila tidak menghadap ke kiri
        if (!isFacingRight)
        {
            Flip();
        }
    }

    private void MoveLeft()
    {
        if (rigidbody2D.velocity.x * -1 < maxSpeed)
        {
            rigidbody2D.AddForce(Vector2.left * walkForce);

        }

        // membalik arah karakter apabila tidak menghadap ke kanan
        if (isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        isFacingRight = !isFacingRight;
    }

    /*
     * Fungsi OnCollisionEnter2D digunakan untuk mengecek objek 
     * apakah yang baru saja bertabrakan atau menyentuh Player. 
     * 
     * Dalam hal ini, fungsi tersebut dapat melihat apakah Player baru saja menyentuh tanah. 
     * Jika objek yang menyentuh Player adalah "Ground" maka parameter "IsGrounded" 
     * pada animator diatur menjadi true.
     * 
     */
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("IsGrounded", true);
            isGrounded = true;
;        }     
    }

    /*
     * fungsi OnCollisionStay2D digunakan untuk mengecek objek 
     * apakah yang sedang menyentuh Player. Jika objek yang sedang menyentuh Player adalah "Ground" 
     * maka maka parameter "IsGrounded" pada animator diatur menjadi true.
     */
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("IsGrounded", true);
            isGrounded = true;
        }     
    }

    /*
     * OnCollisionExit2D digunakan untuk mengecek objek 
     * apakah yang sedang meninggalkan Player. 
     * Jika objek yang sedang meninggalkan Player adalah "Ground" maka maka parameter "IsGrounded" 
     * pada animator diatur menjadi false.
     */
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("IsGrounded", false);
            isGrounded = false;
        }

    }
}
