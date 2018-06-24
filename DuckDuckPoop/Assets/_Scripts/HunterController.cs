using UnityEngine;

public class HunterController : MonoBehaviour {

    [SerializeField] float moveSpeed = 15;
    private Vector3 moveDir;
    Rigidbody rb;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject spawnLoc;

    Manager manager;

    private void Start()
    {
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
            moveDir = new Vector3(Input.GetAxis("Horizontal2"), 0, Input.GetAxis("Vertical2")).normalized;

            // If Fire button is pressed
            if (Input.GetButtonDown("HFire"))
            {
                //Debug.Log("Fire");
                GameObject.Instantiate(bullet, spawnLoc.transform.position, spawnLoc.transform.rotation);
            }
        }
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
    }
}
