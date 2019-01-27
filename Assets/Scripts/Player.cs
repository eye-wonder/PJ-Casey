using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public bool canMove = true;
    public bool movingRight = true;
    public float movementSpeed = 1;
    public float jumpHeight = 1;

    [Header("Level Constraints")]
    [Tooltip("How far below the level makes you respawn")]
    public float bottomOfLevel;
    [Tooltip("Where do you respawn at?")]
    public Vector3 respawnPoint;

    [Header("Pillow")]
    public GameObject casey;
    [Tooltip("multiplier value to affect how strong the throw is in X and Y direction")]
    public Vector2 throwStrength = Vector2.one;
    
    [Header("Cartesian")]
    [Tooltip("Percent of throwStrength to throw in X and Y distances. EX 1,0.9 = uses 100% of throwStrength.x and 90% of throwStrength.y")]
    public Vector2 throwVectorXY;


    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (this.transform.position.y < bottomOfLevel)
        {
            print("Respawn!");
            this.transform.position = respawnPoint;
            rb.velocity = Vector2.zero;
        }
        
        if (Input.GetMouseButton(0))
        {
            throwVectorXY.x = (4 * Camera.main.ScreenToViewportPoint(Input.mousePosition).x) - 2;
            throwVectorXY.y = (4 * Camera.main.ScreenToViewportPoint(Input.mousePosition).y) - 2;
        }
    }


    private void FixedUpdate()
    {
        if (canMove)
        {
            if (Mathf.Abs(rb.velocity.x) < 5)
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    movingRight = false;
                    rb.AddForce(Vector2.left * 10 * movementSpeed);
                }
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    movingRight = true;
                    rb.AddForce(Vector2.right * 10 * movementSpeed);
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && this.GetComponent<Rigidbody2D>().velocity.y <= 0.01f)
            {
                rb.AddForce(Vector2.up * 250 * jumpHeight);
            }
        }
    }
}