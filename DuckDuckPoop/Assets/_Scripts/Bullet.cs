using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] float bullSpeed = 100.0f;
    Vector3 planet;
    Vector3 forward;

	void Start () {
        // Getting the planets position
        planet = GameObject.FindGameObjectWithTag("Planet").transform.position;
        forward = transform.forward;
	}

    private void FixedUpdate()
    {
        transform.RotateAround(planet, forward, bullSpeed * Time.deltaTime);
    }

}
