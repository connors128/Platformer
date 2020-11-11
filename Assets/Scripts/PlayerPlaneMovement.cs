using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaneMovement : MonoBehaviour
{

    public static GameObject Player;

    static int onNumPlatforms = 0;
    //public static Vector3 playerJumpVelocity;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == Player)
        {            
            Player.transform.parent = this.transform;
            onNumPlatforms++;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject == Player && onNumPlatforms == 1 )
        {
            Player.transform.parent = null;

            onNumPlatforms--;
            //Debug.Log("Exit " + onNumPlatforms);
        }
        else if(col.gameObject == Player && onNumPlatforms > 1 )
        {
            onNumPlatforms--;
            //Debug.Log("Exit " + onNumPlatforms);
        }

    }
}
