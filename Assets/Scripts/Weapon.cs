using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject owner;
 
    float time =0;

    public float fireTime;
    public Transform bulletSpawnPoint;
    public GameObject bullet;
    public float bulletForce;
    public float accuracy = 1f;
    // Start is called before the first frame update
    void Start()
    {
        if(owner==null)
            owner=transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > time+fireTime){
            FireBullet();
            time+=fireTime;
        }
        
    }


    void FireBullet(){
        GameObject bull = Instantiate(bullet,bulletSpawnPoint.position,bulletSpawnPoint.rotation);
        Rigidbody brigid = bull.GetComponent<Rigidbody>();
        Collider bcoll = bull.GetComponent<Collider>();
        Physics.IgnoreCollision(owner.GetComponent<Collider>(),bcoll,true);
        brigid.AddForce(bulletForce*bulletSpawnPoint.forward);
        Destroy(bull,3f);
        
    }
}
