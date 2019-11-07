using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    // add this to the platform
    // this will bounce off any rigid body
    // Start is called before the first frame update

    public float forceSpeed = 20;

    Vector3 dir;
    void Start(){
        dir = this.transform.up;
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            if(other.gameObject.GetComponent<Rigidbody> () != null) {
                other.gameObject.GetComponent<Rigidbody>().AddForce(dir * forceSpeed, ForceMode.Impulse);
            }
        }
    }
}
