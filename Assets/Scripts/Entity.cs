using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float maxHp =100f;
    public float currentHp;
    public Collider coll;
    public Rigidbody rigid;
    public bool stunned = false;
    [Range(0,5f)]
    public float stuntime = 1f;
    private bool alreadyStunned = false;
    [Range(1,100)]
    public float knockbackMultiplier = 100f;
    private void Awake() {
        coll = GetComponent<Collider>();
        rigid = GetComponent<Rigidbody>();
    }
    private void Start() {
        currentHp = maxHp;
    }
    private void Update() {
        if(stunned){
            StartCoroutine(Stun());
        }
    }
    IEnumerator Stun(){
        if(alreadyStunned)
            yield return null;
        else{
            alreadyStunned = true;
        yield return new WaitForSeconds(stuntime);
        stunned =false;
        alreadyStunned = false;
        yield return null;
    }
    }
       private void OnCollisionEnter(Collision other) {
       if(other.gameObject.tag=="Projectile")
       {
           //Weapon otherwep = other.gameObject.GetComponent<Weapon>();
           //currentHp -= otherwep.damage;
           currentHp -= other.relativeVelocity.magnitude;
           rigid.AddForce(other.relativeVelocity*knockbackMultiplier);

        Debug.Log("Stunned!");
        stunned = true;
       }
       else if(other.gameObject.tag=="Enemy")
       {
           currentHp -=1f;
       }
        Debug.Log(this.name +  " Hit! Remaining HP: " + currentHp);
        if(currentHp <= 0f)
        {
            Debug.Log(this.name + " is dead. RIP.");
            Destroy(this.gameObject);
        }
    }
}
