using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystickcoding : MonoBehaviour
{
    protected Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(joystick.Horizontal * 20f + Input.GetAxis("Horizontal") * 20f, rigidbody.velocity.y, joystick.Vertical * 20f + Input.GetAxis("Vertical") * 20f );
    }

    void TelePort(){
        // this.transform.Translate(dir * 3);
    }

    public Camera mainCam;
    void OnTriggerEnter (Collider other){
        if (other.gameObject.CompareTag("CustomCam")){
            mainCam.gameObject.SetActive(false);
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("CustomCam")){
            mainCam.gameObject.SetActive(true);
            other.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
