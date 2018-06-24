using UnityEngine;

public class DuckController : MonoBehaviour {

    [SerializeField] float moveSpeed = 15;
    [SerializeField] float dashForce = 30;
    private Vector3 moveDir;
    Rigidbody rb;

    bool duck = false;

    [SerializeField] GameObject poop;

    // Reference to the Manager Script
    Manager manager;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }

    private void Update()
    {
        // If game is not over
        if (!manager.gameOver)
        {
            // Get controls from Controller 1
            moveDir = new Vector3(Input.GetAxis("Horizontal1"), 0, Input.GetAxis("Vertical1")).normalized;

            // If duck is pressed
            if (Input.GetButtonDown("DDuck"))
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
            if (Input.GetButtonUp("DDuck"))
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
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
    }
}
