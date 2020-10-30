using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    static int deathCount = 0;
    int childCount;

    static Vector3 resetPosition;
    public static GameObject prefabPlayer;

    bool hasTriggered = false;

    private Rigidbody _rigidbody;
    private FPSMovement _fpsMovement;
    private PlayerManager _playerManager;
    private GameObject platform;
    private Text _text;

    void Start()
    {
        childCount = this.transform.childCount;
        platform = GameObject.FindGameObjectWithTag("Platform");
        prefabPlayer = this.gameObject;

        //resetPosition = prefabPlayer.transform.position;
        resetPosition = gameObject.transform.localPosition;
        _fpsMovement = this.GetComponent<FPSMovement>();
        _playerManager = this.GetComponent<PlayerManager>();
        _text = gameObject.GetComponentInChildren<Canvas>().GetComponentInChildren<Text>();
        PlayerPlaneMovement.Player = prefabPlayer;
    }
    private void Awake()
    {
        childCount = this.transform.childCount;
        prefabPlayer = this.gameObject;
        resetPosition = prefabPlayer.transform.position;
        _text = gameObject.GetComponentInChildren<Canvas>().GetComponentInChildren<Text>();
        this.name = "Player";
        PlayerPlaneMovement.Player = prefabPlayer;
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))//reset position of current player
        {
            this.transform.position = resetPosition;
            deathCount++;
            _text.text = deathCount.ToString();
        }
    }

    void Update()
    {
        if(gameObject.transform.position.y < 0 && !hasTriggered) //add rigidbody, disable FPSMovement, create new prefab at resetPoint
        {
            deathCount++;
            _text.text = deathCount.ToString();
            Instantiate(prefabPlayer, resetPosition, Quaternion.identity); //, resetPosition, Quaternion.identity);
            for(int i = 0; i < childCount; i++)
            {
                if(this.transform.GetChild(i).gameObject)
                    Destroy(this.transform.GetChild(i).gameObject);
            }


            this.gameObject.AddComponent<Rigidbody>();
            this.gameObject.GetComponent<Rigidbody>().velocity = _fpsMovement.GetComponent<CharacterController>().velocity;
            _fpsMovement.GetComponent<CharacterController>().enabled = false;


            gameObject.name = "Dead Body";



            _fpsMovement.enabled = false;
            this.GetComponent<BoxCollider>().material = new PhysicMaterial("Dead Bounce");
            this.GetComponent<BoxCollider>().material.bounciness = .5f;
            _playerManager.enabled = false;

            hasTriggered = true;
        }
    }
}
