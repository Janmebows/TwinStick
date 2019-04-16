using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public GameObject player;
    Camera cam;
    public Vector3 offset;
    private void Awake() {
        if(player==null)
            Debug.Log("baka");
        if(cam==null)
            cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = Vector3.Slerp(cam.transform.position,player.transform.position + offset,0.5f);
    }
}
