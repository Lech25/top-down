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
        if (isDashing) dashTime -= Time.time;
        if (dashTime <= 0f) { rb.velocity = Vector2.zero; isDashing = false; }
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
        if (moveX > 0f) direction = directions.right;
        else if (moveX < 0f) direction = directions.left;
        if (moveY > 0f) direction = directions.up;
        else if (moveY < 0f) direction = directions.down;
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
