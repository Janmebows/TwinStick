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
    public bool autofire = true;
    // Start is called before the first frame update
    void Start()
    {
        if(owner==null)
            owner=transform.parent.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if(autofire)
        FireBullet();
        
    }


    //can have various different types of the firebullet method.
    public void FireBullet()
    {
        if(Time.time > time+fireTime){
            
            time=Time.time + fireTime;
        GameObject bull = Instantiate(bullet,bulletSpawnPoint.position,bulletSpawnPoint.rotation);
        Rigidbody brigid = bull.GetComponent<Rigidbody>();
        Collider bcoll = bull.GetComponent<Collider>();
        if(owner!=null)
            Physics.IgnoreCollision(owner.GetComponent<Collider>(),bcoll,true);
        //brigid.AddRelativeForce(bulletForce*bulletSpawnPoint.forward);
        brigid.AddForce(bulletForce*bulletSpawnPoint.forward);
        Destroy(bull,3f);
        }
    }
}
