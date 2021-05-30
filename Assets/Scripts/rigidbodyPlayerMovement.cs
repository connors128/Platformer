using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigidbodyPlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    public float walkSpeed = 6.0f,
        jumpSpeed = 18.0f,
        runSpeed = 8.0f,
        gravity = 20.0f;

    float distToGround = 0;
    void Start () 
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    void FixedUpdate () 
    {
        //Debug.Log(isOnGround());
        if(isOnGround())
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = Camera.main.transform.TransformDirection(moveDirection);
            moveDirection.y = 0f;
            moveDirection *= walkSpeed;
            
            if (Input.GetButton("Jump"))
            {
                //moveDirection.y = jumpSpeed;
                rb.AddForce(transform.up * jumpSpeed);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection /= walkSpeed;
                moveDirection *= runSpeed;
            }

            rb.AddForce(moveDirection);
        }
        else
        {
            Debug.Log("In Air");
        }          

        
        //moveDirection.y -= gravity * Time.deltaTime;

        //float mH = Input.GetAxis ("Horizontal");
        //float mV = Input.GetAxis ("Vertical");
        //rb.velocity = new Vector3 (mH * walkSpeed, rb.velocity.y, mV * walkSpeed);
        //rb.velocity = moveDirection;
        //rb.AddForce(new Vector3((mH*walkSpeed), 0f, (mV * walkSpeed)));
    }
    
    bool isOnGround()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
        //return Physics.CheckBox(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y-0.1f, col.bounds.center.z), 0.18f);
        //        return Physics.CheckCapsule(collider.bounds.center, new Vector3(collider.bounds.center.x, collider.bounds.min.y-0.1f, collider.bounds.center.z), 0.18f));
    }
}
