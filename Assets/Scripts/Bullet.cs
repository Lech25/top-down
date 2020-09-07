using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();

        
    }

    void Update() {
        rb.AddForce(transform.up * speed * Time.deltaTime);
    }
}
