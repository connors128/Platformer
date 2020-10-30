using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FPSMovement : MonoBehaviour
{
    public float walkSpeed = 6.0f,
                 jumpSpeed = 8.0f,
                 runSpeed = 8.0f,
                 gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = Camera.main.transform.TransformDirection(moveDirection);
            moveDirection.y = 0.0f; //important for not 'jumping' when looking up
            moveDirection *= walkSpeed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
            if(Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection /= walkSpeed;
                moveDirection *= runSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
    
}