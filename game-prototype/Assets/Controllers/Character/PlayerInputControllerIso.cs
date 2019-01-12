using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputControllerIso : MonoBehaviour
{

    public MovementControllerIso controller;
    public Animator animator;

    float horizontalMovement = 0f;
    float verticalMovement = 0f;


    // Update is called once per frame
    void Update() {
        // Handle movement
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        animator.SetFloat("speed", Mathf.Abs(horizontalMovement) + Mathf.Abs(verticalMovement));

        // Handle combat inputs
        if (Input.GetButtonDown("Jump")) {
            animator.SetTrigger("attack");
        }
    }

    void FixedUpdate() {
        // Move the character
        controller.Move(
            horizontalMovement * Time.fixedDeltaTime,
            verticalMovement * Time.fixedDeltaTime
        );
    }
}
