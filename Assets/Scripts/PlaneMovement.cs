using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public enum axisTransform { Forward, Right, Up, Down, Left, Back, Zero };
    public axisTransform axisOfTransform;
    public float Amplitude = 2.0f,
                 Speed = 2.0f,
                 changeTime = 2.0f;
    private Vector3[] vectorAxis = new Vector3[7];
    public Vector3 currentPos;
    public Vector3 FrameVelocity { get; set; }
    public Vector3 PrevPosition { get; set; }
    GameObject Plane;

    // Start is called before the first frame update
    void Start()
    {
        Plane = this.gameObject;
        vectorAxis[0] = Vector3.forward;
        vectorAxis[1] = Vector3.right;
        vectorAxis[2] = Vector3.up;
        vectorAxis[3] = Vector3.down;
        vectorAxis[4] = Vector3.left;
        vectorAxis[5] = Vector3.back;
        vectorAxis[6] = Vector3.zero;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Plane.transform.Translate(Amplitude * GetAxis(axisOfTransform) * Mathf.Sin(((2 * Time.timeSinceLevelLoad) / changeTime) * Speed) * Time.fixedDeltaTime);
    }

    public void Update()
    {
        Vector3 currFrameVelocity = (transform.position - PrevPosition) / Time.deltaTime;
        FrameVelocity = Vector3.Lerp(FrameVelocity, currFrameVelocity, 0.1f); //lerping the velocity to avoid single frame irregularities
        PrevPosition = transform.position;
    }
    public Vector3 GetAxis(axisTransform axis)
    {
        return vectorAxis[(int)axis];
    }

}
