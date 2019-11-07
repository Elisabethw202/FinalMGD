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

    public TextMeshProUGUI scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        speed *= 1.5f;
        rb = this.GetComponent<Rigidbody>();
        Calibrate();
        startPos = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 dir = Vector3.zero; // new Vector 3(0,0,0)l=;

        dir.x = Input.acceleration.x - calibratedDir.x;
        dir.z = Input.acceleration.y - calibratedDir.z;
        

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
        scale.z = dir.magnitude * 2;
        arrowIndicator.localScale = scale * 2;

        if(this.transform.position.y <=0){
            RestartPosition();
        }
    }
    Vector3 startPos;

    void RestartPosition(){
        this.transform.position = startPos;
        rb.velocity = Vector3.zero;             // this stops all movement.
    }
    void FixedUpdate() {
        rb.AddForce(dir * speed);
    }

    public float jumpSpeed = 5f;
    public void Jump(){
        if(isGrounded && canJump){
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);}

    }

    bool isGrounded = true;
    bool canJump = false;
    void OnCollisionEnter(){
        isGrounded = true;
    }

    void OnCollisionExit(){
        isGrounded = false;
    }

    public int score = 0;
    void OnTriggerEnter (Collider other){
        if(other.gameObject.CompareTag("JumpPowerup")){
            canJump = true;
        }
        if(other.gameObject.CompareTag("LeBox")){
            score += 500;
            scoreText.text = "Score: " + score;
            Destroy(other.gameObject);
            // play audio(coin pikcup sound)
        }
    }
}
