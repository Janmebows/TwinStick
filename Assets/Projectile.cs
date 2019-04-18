using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 pos;
    Vector3 dir;
    float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Init(Vector3 _pos, Vector3 _dir,float _force){
        pos = _pos;
        dir = _dir;
        force = _force;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
