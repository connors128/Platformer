using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    Vector3 resetPosition;

    public GameObject prefabPlayer;
    private GameObject focussedObject;
    private Camera cam;
    void Start()
    {
        resetPosition = gameObject.transform.position;
        focussedObject = prefabPlayer;
        cam = gameObject.GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))//reset position of current player
        {
            gameObject.transform.position = resetPosition;
        }
        if(gameObject.transform.position.y < 0) //add rigidbody, disable FPSMovement, create new prefab at resetPoint
        {

            //gameObject.transform.position = resetPosition;
            gameObject.AddComponent<Rigidbody>();
            gameObject.GetComponent<FPSMovement>().enabled = false;
            Destroy(transform.GetChild(0).transform.gameObject);
            gameObject.GetComponent<PlayerManager>().enabled = false;
            //remove camera component
            //create prefab at resetPosition
            Instantiate(prefabPlayer, prefabPlayer.transform); //, resetPosition, Quaternion.identity);
            focussedObject = prefabPlayer;
            //cam.transform.parent = focussedObject.transform;
        }
    }
}
