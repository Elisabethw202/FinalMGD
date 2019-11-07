using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MarbleMovement : MonoBehaviour
{
    Vector3 dir;
    

    Rigidbody rb;
    
    public Transform arrowIndicator;

    public bool debug = true;
    public float speed = 10;
    Vector3 calibratedDir;
    
    // Start is called before the first frame update
    void Start()
    {
        speed *= 1.5f;
        rb = this.GetComponent<Rigidbody>();
        Calibrate();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 dir = Vector3.zero; // new Vector 3(0,0,0)l=;

        dir.x = Input.acceleration.x - calibratedDir.x;
        dir.y = Input.acceleration.y - calibratedDir.z;
        

        if(debug){
            Debug.DrawRay(this.transform.position, dir, Color.red, 0.5f);
        }
        
        

    }
    public void Calibrate(){
        calibratedDir.x = Input.acceleration.x;
        calibratedDir.y = Input.acceleration.y;
        Debug.Log("Calibrated Dir = " + calibratedDir);
    }
    void LateUpdate(){
        arrowIndicator.rotation = Quaternion.LookRotation(dir, Vector3.up);
        Vector3 scale = Vector3.one;
        scale.z = dir.magnitude;
        arrowIndicator.localScale = scale * 2;
    }
    void FixedUpdate() {
        rb.AddForce(dir * speed);
    }

    public float jumpSpeed = 5f;
    public void Jump(){
        if(isGrounded){
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);}

    }

    bool isGrounded = true;
    void OnCollisionEnter(){
        isGrounded = true;
    }

    void OnCollisionExit(){
        isGrounded = false;
    }
}
