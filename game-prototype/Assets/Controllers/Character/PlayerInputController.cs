using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{

    public MovementController2D controller;

    public float runSpeed = 40f;

    float horizontalMovement = 0f;
    bool jump = false;

    // Update is called once per frame
    void Update() {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump")) {
            jump = true;
        };
    }

    void FixedUpdate() {
        // Move the character
        controller.Move(horizontalMovement * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
