using UnityEngine;
using UnityEngine.Networking;

public class DuckController : NetworkBehaviour {

    [SerializeField] float moveSpeed = 15;
    [SerializeField] float dashForce = 30;
    private Vector3 moveDir;
    Rigidbody rb;

    bool duck = false;

    [SerializeField] GameObject poop;

    // Reference to the Manager Script
    Manager manager;

    public float speed = 10.0f;
    public float sensitivity = 0.0004f;
    Vector3 dir;

    private void Start()
    {
        dir = Vector3.zero;
        if(isLocalPlayer)
        {
            var cam = GameObject.FindWithTag("cam");
            cam.transform.parent = transform;
            cam.transform.localPosition = new Vector3(0.0f, 14.5f, -6.0f);
            cam.transform.localRotation = Quaternion.AngleAxis(70.0f, transform.right);
        }
        rb = gameObject.GetComponent<Rigidbody>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }

    private void Update()
    {
        // If game is not over
        if (!manager.gameOver)
        {
            switch(SystemInfo.deviceType)
            {
                case DeviceType.Desktop:
                    // Get controls from Controller 1
                    moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

                    // If duck is pressed
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        // Making it into a ducking state
                        duck = true;

                        // Store the current position
                        Vector3 tempLoc = transform.position;

                        // Change the scale of the mesh
                        transform.Find("Body").transform.localScale = new Vector3(1, 0.5f, 1);
                        // Change the height of the collider
                        GetComponent<CapsuleCollider>().height = 1;
                        // Do a dash
                        //rb.AddForce(transform.forward * dashForce, ForceMode.Impulse);
                        rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * dashForce * Time.deltaTime);

                        // Poop
                        GameObject.Instantiate(poop, tempLoc, transform.rotation);

                        //Debug.Log("Dodge");

                    }
                    if (Input.GetKeyUp(KeyCode.Space))
                    {
                        // If ducking is done, revert to normal
                        if (duck)
                        {
                            // Change the scale of the mesh
                            transform.Find("Body").transform.localScale = new Vector3(1, 1, 1);
                            // Change the height of the collider
                            GetComponent<CapsuleCollider>().height = 2;
                        }
                        duck = false;
                    }
                    break;
                case DeviceType.Handheld:
                    // Get controls from Controller 1
                    dir.x = Input.acceleration.x;
                    dir.z = Input.acceleration.y;
                    dir *= 0.004f;
                    moveDir = dir.normalized;

                    // If duck is pressed
                    if (Input.GetMouseButtonDown(0))
                    {
                        CmdPoop();

                    }
                    if (Input.GetMouseButtonUp(0))
                    {
                        // If ducking is done, revert to normal
                        if (duck)
                        {
                            // Change the scale of the mesh
                            transform.Find("Body").transform.localScale = new Vector3(1, 1, 1);
                            // Change the height of the collider
                            GetComponent<CapsuleCollider>().height = 2;
                        }
                        duck = false;
                    }
                    break;
            }

        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
    }

    [Command]
    void CmdPoop()
    {
        //Debug.Log("Fire");

        // Making it into a ducking state
        duck = true;

        // Store the current position
        Vector3 tempLoc = transform.position;

        // Change the scale of the mesh
        transform.Find("Body").transform.localScale = new Vector3(1, 0.5f, 1);
        // Change the height of the collider
        GetComponent<CapsuleCollider>().height = 1;
        // Do a dash
        //rb.AddForce(transform.forward * dashForce, ForceMode.Impulse);
        rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * dashForce * Time.deltaTime);


        var projectile = Instantiate(poop, tempLoc, transform.rotation) as GameObject;
        NetworkServer.Spawn(projectile);
    }
}
