using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour {

    public float thrust = 0.0000001f;

    Rigidbody body;

	// Use this for initialization
    void Start() {
        
            
	}

    // Update is called once per frame
    void Update () {
        // Check if the input is coming from the local player
        if(!isLocalPlayer)
        {
            return;
        }
        switch(SystemInfo.deviceType)
        {
            case DeviceType.Desktop:
                if (Input.GetKey(KeyCode.A))
                {
                    transform.position = new Vector3(transform.position.x - Time.deltaTime * thrust, transform.position.y, transform.position.z);

  
                    Debug.Log("A Pressed");
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.position = new Vector3(transform.position.x + Time.deltaTime * thrust, transform.position.y, transform.position.z);
         
                    Debug.Log("D Pressed");
                }
                if (Input.GetKey(KeyCode.S))
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * thrust);

                    Debug.Log("S Pressed");
                }
                if (Input.GetKey(KeyCode.W))
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * thrust);
                   
                    Debug.Log("W Pressed");
                }
                break;
            case DeviceType.Handheld:
                transform.position = new Vector3(transform.position.x + Input.acceleration.x * thrust * Time.deltaTime, transform.position.y, transform.position.z + Input.acceleration.y * thrust * Time.deltaTime);
                //body.AddForce(new Vector2(Input.acceleration.x, Input.acceleration.y));
                break;


        }



	}
}
