using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float walkSpeed = 10.0f;
    public float gravity = 9.8f;
    //public float rotateSpeed =0.3f;
    public float jumpSpeed =8.0f;
    public Vector3 moveDirection = Vector3.zero;
    public float aimDirection = 0f;
    public new Camera camera;
    public GameObject player;
    public CharacterController controller;
    void Start()
    {
        player = transform.gameObject;
        controller = GetComponent<CharacterController>();
        if(camera == null)
        {
            camera = Camera.main;
        }
        moveDirection = new Vector3();
    }

    void Update()
    {
        LeftStick();
        RightStick();
        moveDirection.y = moveDirection.y - (gravity*Time.deltaTime);
        controller.Move(moveDirection*Time.deltaTime);
        player.transform.eulerAngles = new Vector3(0,aimDirection,0);

	}
    void LeftStick()
    {
        float inputx = Input.GetAxis("Horizontal");
        float inputy = Input.GetAxis("Vertical");
        float inputMag = Mathf.Sqrt(Mathf.Pow(inputx,2f)+ Mathf.Pow(inputy, 2f));
        if(inputMag > 1)
        {
        	inputx/=inputMag;
        	inputy/=inputMag;
        }
        moveDirection.x =inputx*walkSpeed;
        moveDirection.z = inputy * walkSpeed;
        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

    }

    void RightStick()
    {
        //
        //JOYSTICK CONTROLS
        //
        //float inputx = Input.GetAxis("JOYRx");
        //float inputy = Input.GetAxis("JOYRy");
        //float threshold = 0.2f;
        //if(inputx > threshold || inputx < -threshold ||inputy > threshold || inputy < -threshold )
                //aimDirection = InputToRotation(inputx,inputy);


        //
        //MOUSE CONTROLS
        //
        Vector3 inputMouse = Input.mousePosition;
        float offsetx = Screen.width * 0.5f;
        float offsetz = Screen.height * 0.5f;
        aimDirection = InputToRotation(inputMouse.x -offsetx,inputMouse.y - offsetz);
    }
    float InputToRotation(float x, float y)
    {
        float angle = 0f;
        if (x != 0.0f || y != 0.0f)
        {
            angle = 90 - Mathf.Atan2(y, x) * Mathf.Rad2Deg;

        }
        return angle;
    }
}
