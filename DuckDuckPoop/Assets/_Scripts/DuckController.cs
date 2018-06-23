using UnityEngine;

public class DuckController : MonoBehaviour {

    [SerializeField] float moveSpeed = 15;
    private Vector3 moveDir;
    Rigidbody rb;

    //[SerializeField] GameObject poop;
    //[SerializeField] GameObject spawnLoc;

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

            // If dodge is pressed
            if (Input.GetButtonDown("DDuck"))
            {
                // TODO: Dodge

                // TODO: Poop

                Debug.Log("Dodge");
                //GameObject.Instantiate(poop, spawnLoc.transform.position, spawnLoc.transform.rotation);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
    }
}
