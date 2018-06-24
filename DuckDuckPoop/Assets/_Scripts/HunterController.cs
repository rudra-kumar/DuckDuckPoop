using UnityEngine;
using UnityEngine.Networking;

public class HunterController : NetworkBehaviour {

    [SerializeField] float moveSpeed = 15;
    private Vector3 moveDir;
    Rigidbody rb;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject spawnLoc;

    Manager manager;

    private void Start()
    {
        if (isLocalPlayer)
        {
            var cam = GameObject.FindWithTag("cam");
            cam.transform.parent = transform;
            cam.transform.localPosition = new Vector3(0.0f, 14.5f, -6.0f);
            cam.transform.localRotation = Quaternion.AngleAxis(70.0f, transform.right);
        }
        rb = gameObject.GetComponent<Rigidbody>();
        // Reference to the Manager Script
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }

    private void Update()
    {
        // If game is not over
        if(!manager.gameOver)
        {
            // Get input from Controller 2
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

            // If Fire button is pressed
            if (Input.GetMouseButtonDown(0))
            {
                CmdFire();
            }
        }
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
    }
    [Command]
    void CmdFire()
    {
        //Debug.Log("Fire");
        var projectile = Instantiate(bullet, spawnLoc.transform.position, spawnLoc.transform.rotation) as GameObject;
        NetworkServer.Spawn(projectile);
    }
}
