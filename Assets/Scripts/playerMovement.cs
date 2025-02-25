using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] float speed = 1;
    Rigidbody rb; // Coding the movement through RigidBody, Doesnt need to be serialized, but could be!
    Vector3 movement;
    [SerializeField] float jumpForce = 1;

    void Start()
    {
        // GetComponent will search ITSELF. FindObjectType will search other objects

        rb = GetComponent<Rigidbody>(); // Will search on the object this script is on for this.
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        /*Vector3 movement = new Vector3(xInput * speed * Time.deltaTime, rb.linearVelocity.y, yInput * speed * Time.deltaTime);*/
        movement = new Vector3(xInput, 0, yInput) * speed * Time.deltaTime;
        movement.y = rb.linearVelocity.y;

        if (Input.GetButtonDown("Jump")) // Jumping Yippee
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement;
    }
}
