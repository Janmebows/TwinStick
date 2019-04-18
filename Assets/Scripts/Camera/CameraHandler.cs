using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [Range(50,120)]
    public float fov = 90;
    Camera cam;
    public Vector3 offset;
    public Vector3 cameraAngle;
    public GameObject player;

    private void Awake() {
        if(player==null)
            Debug.Log("Camera doesn't know who the player is");
        if(cam==null)
            cam = Camera.main;

        cam.fieldOfView = fov;
        cam.transform.eulerAngles = cameraAngle;
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = Vector3.Slerp(cam.transform.position,player.transform.position + offset,0.5f);
    }
}
