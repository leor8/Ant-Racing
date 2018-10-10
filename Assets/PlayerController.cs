using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    public KeyCode left, right, jump, powerup1, powerup2, powerup3, powerup4, powerup5;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public LayerMask thisLayer;
    private Inventory inventory;

    public  bool isGrounded;

    private bool printed = false;

    private Rigidbody2D rb;
    private PlayerController enemy;

    // powerup variables
    private bool speeded = false;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        inventory = GetComponent<Inventory>();
        if(this.tag == "Player"){
            enemy = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerController>();
        } else {
            enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
    }

    void Update () {


        // Checking if the player is on ground otherwise the player should not be able to jump mid-air
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        // Getting key inputs to move the player
        if(Input.GetKey(left)) {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        } else if (Input.GetKey(right)) {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        } else {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // For jumping
        if(Input.GetKeyDown(jump) && isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if(Input.GetKey(powerup1)){


            ///////////// This section is for code to Speed up //////
            // if(inventory.isFull[0]) {
            //     Destroy(inventory.slots[0]);
            //     inventory.isFull[0] = false;
            //     if(!speeded) { // Set a timer here and make sure it only runs for 1 frame per cast
            //         speed += 10;
            //         speeded = true;
            //     }
            // }

            ///////////// This section is for code to Jump higher //////
            //     if(inventory.isFull[0]) {
            //         Destroy(inventory.slots[1]);
            //         inventory.isFull[0] = false;
            //         if(!speeded) {
            //             jumpForce += 10;
            //             speeded = true;
            //         }
            //     }

            ///////////// This section is for code to slow down enemy /////////
                if(inventory.isFull[0]) {
                    Destroy(inventory.slots[0]);
                    inventory.isFull[0] = false;
                    if(!speeded) {
                        enemy.speed -= 5;
                        speeded = true;
                    }
                }
            //
        }

        // if(Input.GetKey(powerup2)) {
        //     // Jump Higher
        //     if(inventory.isFull[1]) {
        //         Destroy(inventory.slots[1]);
        //         inventory.isFull[1] = false;
        //         if(!speeded) {
        //             jumpForce += 10;
        //             speeded = true;
        //         }
        //     }
        // }


    }

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.CompareTag("Collectables")){
            Destroy(coll.gameObject);
            // int curr_powerup = Random.Range(0, powerup_pool.Length);
            // inventory.Add(powerup_pool[curr_powerup]);
        }

    }

    void using_powerup() {

    }
}
