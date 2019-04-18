using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float walkSpeed = 10.0f;
    public Vector3 moveDirection;
    public float aimDirection = 0f;
    public new Camera camera;
    public GameObject player;
    public Weapon weapon;
    public Rigidbody rigid;
    bool tryFireThisFrame = false;
    void Start()
    {
        player = transform.gameObject;
        if(camera == null)
        {
            camera = Camera.main;
        }
        moveDirection = new Vector3(0f,0f,0f);
        rigid = GetComponent<Rigidbody>();
        weapon = GetComponentInChildren<Weapon>();
        weapon.autofire = false;
    }

    void Update()
    {
        LeftStick();
        RightStick();
        
        
        player.transform.eulerAngles = new Vector3(0,aimDirection,0);

	}
    void FixedUpdate() {
        
        if(moveDirection.sqrMagnitude >0)
            rigid.velocity =moveDirection*Time.deltaTime;
        if(tryFireThisFrame)
        {
            weapon.FireBullet();
            tryFireThisFrame = false;
        }

    }
    void LeftStick()
    {
        float inputhoriz = Input.GetAxis("Horizontal");
        float inputvert = Input.GetAxis("Vertical");
        float inputMag = Mathf.Sqrt(Mathf.Pow(inputhoriz,2f)+ Mathf.Pow(inputvert, 2f));
        if(inputMag > 1)
        {
        	inputhoriz/=inputMag;
        	inputvert/=inputMag;
        }
        moveDirection.x = inputhoriz*walkSpeed;
        moveDirection.z = inputvert * walkSpeed;
    }

    void RightStick()
    {
        //
        //JOYSTICK CONTROLS
        //
        float inputx = Input.GetAxis("JOYRx");
        float inputy = Input.GetAxis("JOYRy");
        float threshold = 0.2f;
        if(inputx > threshold || inputx < -threshold ||inputy > threshold || inputy < -threshold ){
                aimDirection = InputToRotation(inputx,inputy);
                tryFireThisFrame = true;
        }

        //
        //MOUSE CONTROLS
        //
        //Vector3 inputMouse = Input.mousePosition;
        //float offsetx = Screen.width * 0.5f;
        //float offsetz = Screen.height * 0.5f;
        //aimDirection = InputToRotation(inputMouse.x -offsetx,inputMouse.y - offsetz);
    }
    float InputToRotation(float x, float y)
    {
        float angle = 0f;
        //if (x != 0.0f || y != 0.0f)
        //{
            angle = 90 - Mathf.Atan2(y, x) * Mathf.Rad2Deg;

        //}
        return angle;
    }
}
