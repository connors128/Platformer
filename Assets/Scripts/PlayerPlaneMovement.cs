using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaneMovement : MonoBehaviour
{

    public GameObject Player;

    //public static Vector3 playerJumpVelocity;

    private void OnTriggerStay(Collider col)
    {
         
        //Debug.Log(this.GetComponent<PlaneMovement>().FrameVelocity);
        Player.GetComponent<FPSMovement>().moveDirection += (this.GetComponent<PlaneMovement>().currFrameVelocity);

    }

    private void OnTriggerExit(Collider col)
    {
        Player.GetComponent<FPSMovement>().moveDirection = this.GetComponent<PlaneMovement>().currFrameVelocity;
    }
}
