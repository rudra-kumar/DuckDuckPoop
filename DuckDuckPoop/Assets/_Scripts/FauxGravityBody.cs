using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FauxGravityBody : NetworkBehaviour {

    [SerializeField] FauxGravityAttractor attractor;
    private Transform myTransform;

    void Start()
    {
        // Get Attractor component from Planet
        if (attractor == null) attractor = GameObject.FindWithTag("Planet").GetComponent<FauxGravityAttractor>();

        // Get rigid body component reference
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation; // Disable Rotation
        rb.useGravity = false;                                // Disable Gravity
        
        // Get transform reference
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        attractor.Attract(myTransform);
    }
}
