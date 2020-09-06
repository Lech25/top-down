using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private PlayerMovement movementScript;

    void Start() {
        movementScript = GetComponent<PlayerMovement>();
    }

    void Update() {
        
    }
}
