using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, dashForce, startDashTime;
    private float dashTime;
    public bool isDashing;
    public enum directions {
        up,
        down,
        left,
        right
    }
    public directions direction;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        direction = directions.up;
        isDashing = false;
    }

    void Update() {
        if (isDashing) dashTime -= 0.1f;
        if (dashTime <= 0f) { 
            rb.velocity = Vector2.zero; 
            isDashing = false; 
        }
        Movement();
        if (Input.GetKeyDown(KeyCode.Space)) {
            dashTime = startDashTime;
            Dash(); 
        }
    }

    void Movement() {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(moveX, moveY, 0) * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) direction = directions.right;
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) direction = directions.left;
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) direction = directions.up;
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) direction = directions.down;
    }

    void Dash() {
        isDashing = true;
        Debug.Log("dash");
        if (direction == directions.up) rb.velocity = Vector2.up * dashForce;
        if (direction == directions.down) rb.velocity = Vector2.down * dashForce;
        if (direction == directions.right) rb.velocity = Vector2.right * dashForce;
        if (direction == directions.left) rb.velocity = Vector2.left * dashForce;
    }
}
