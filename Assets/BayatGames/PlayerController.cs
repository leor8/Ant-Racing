using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    public KeyCode left, right, jump, powerup;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public LayerMask thisLayer;

    bool isGrounded;

    private Rigidbody2D rb;

    void Start() {
    rb = GetComponent<Rigidbody2D>();
    }

    void Update () {

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        if(Input.GetKey(left)) {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        } else if (Input.GetKey(right)) {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        } else {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if(Input.GetKeyDown(jump) && isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.CompareTag("Collectables")){
            // coll.gameObject.SetActive(false);
            Destroy(coll.gameObject);
        }

    }
}
