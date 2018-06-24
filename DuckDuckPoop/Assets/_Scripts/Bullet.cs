using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour {

    [SerializeField] float bullSpeed = 100.0f;
    Vector3 planet;
    Vector3 forward;

    // Reference to the Manager Script
    Manager manager;

    void Start () {
        // Reference to the Manager Script
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        // Getting the planets position
        planet = GameObject.FindGameObjectWithTag("Planet").transform.position;
        // Store the forward vector when spawned
        forward = transform.right;
	}

    private void FixedUpdate()
    {
        // If game is not over
        if (!manager.gameOver)
        {
            // Rotate around the center of the planet every second
            transform.RotateAround(planet, forward, bullSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If it collides with the Duck
        if (collision.gameObject.transform.tag == "Duck")
            // Call HunterWin function in the Manager Script
            GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>().HunterWin();

        // If it collides with the Hunter
        if (collision.gameObject.transform.tag == "Hunter")
            // Call DuckWin function in the Manager Script
            GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>().DuckWin();
    }
}
