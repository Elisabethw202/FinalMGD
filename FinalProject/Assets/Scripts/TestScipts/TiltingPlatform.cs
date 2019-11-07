using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltingPlatform : MonoBehaviour
{
    Vector3 calibratedDir;
    Transform body;
    // Start is called before the first frame update
    void Start()
    {
        body = this.transform.GetChild(0);
        Calibrate();
    }

    public void Calibrate(){
        calibratedDir.x = Input.acceleration.x;
        calibratedDir.y = Input.acceleration.y;
        Debug.Log("Calibrated Dir = " + calibratedDir);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;

        dir.x = Input.acceleration.x - calibratedDir.x;
        dir.y = Input.acceleration.y - calibratedDir.y;
    }
}
