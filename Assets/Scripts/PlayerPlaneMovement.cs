using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaneMovement : MonoBehaviour
{

    public GameObject Player;

    static int onNumPlatforms = 0;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == Player)
        {
            //Player.transform.parent = null;
            Player.transform.parent = this.transform;
            onNumPlatforms++;
            //Debug.Log("Enter " + onNumPlatforms);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject == Player && onNumPlatforms == 1)
        {
            Player.transform.parent = null;

            onNumPlatforms--;
            //Debug.Log("Exit " + onNumPlatforms);
        }
        else if(col.gameObject == Player && onNumPlatforms > 1)
        {
            onNumPlatforms--;
            //Debug.Log("Exit " + onNumPlatforms);
        }

    }
}
