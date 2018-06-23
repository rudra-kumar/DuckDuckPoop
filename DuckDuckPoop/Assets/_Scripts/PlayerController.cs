using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] float moveSpeed = 15;
    private Vector3 moveDir;
    Rigidbody rb;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject spawnLoc;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;


        if (Input.GetButtonDown("Fire1"))
        {
            //.Log("Fire");
            GameObject.Instantiate(bullet, spawnLoc.transform.position, spawnLoc.transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
    }
}
