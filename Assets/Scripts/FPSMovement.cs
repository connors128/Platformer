using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public float walkSpeed = 6.0f,
                 jumpSpeed = 8.0f,
                 runSpeed = 8.0f,
                 gravity = 20.0f;
        
    public Vector3 moveDirection = Vector3.zero,
        jumpDirection;

    static CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = Camera.main.transform.TransformDirection(moveDirection);
            moveDirection.y = 0.0f; //important for not 'jumping' when looking up
            moveDirection *= walkSpeed;
            if (this.GetComponentInParent<PlaneMovement>())
                jumpDirection = this.GetComponentInParent<PlaneMovement>().FrameVelocity * Time.deltaTime;
            else
                jumpDirection = Vector3.zero;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection /= walkSpeed;
                moveDirection *= runSpeed;
            }
        }
        if(jumpDirection != Vector3.zero)
        {
            moveDirection += jumpDirection;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}