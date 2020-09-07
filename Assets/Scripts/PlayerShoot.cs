using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private PlayerMovement movementScript;
    public GameObject BulletPrefab;

    void Start() {
        movementScript = GetComponent<PlayerMovement>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) Shoot();
    }

    void Shoot() {
        Vector2 bulletdirection;
        if (movementScript.direction == PlayerMovement.directions.up) bulletdirection = new Vector2(0, 1f);
        else if (movementScript.direction == PlayerMovement.directions.down) bulletdirection = new Vector2(0, -1f);
        else if (movementScript.direction == PlayerMovement.directions.right) bulletdirection = new Vector2(1f, 0);
        else bulletdirection = new Vector2(-1f, 0);
        
        Instantiate(BulletPrefab, transform.position, new Quaternion(bulletdirection.x, bulletdirection.y, 0, 0));
    }
}
