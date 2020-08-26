using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    private float speed;
    private float jumpHeight;
    private KeyCode jump;
    private Rigidbody2D rb;
    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        speed = this.GetComponent<Player>().runSpeed;
        jump = this.GetComponent<Player>().jump;
        jumpHeight = this.GetComponent<Player>().jumpForce;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.transform.right * speed * Time.deltaTime;
        if (Input.GetKeyDown(jump))
        {
            if (grounded)
            {
                rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
                grounded = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
     {
        grounded = true;
        if(collision.gameObject.tag == "Obstacal")
        {
            this.GetComponent<Player>().OnPlayerDeath();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //if (!grounded) { return; }
        //grounded = false;
    }
}
