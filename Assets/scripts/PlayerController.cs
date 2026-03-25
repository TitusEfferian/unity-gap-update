using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 25;
    [SerializeField] private float turnSpeed = 10;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody rigidBody;
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // prev codebase
        // transform.Translate(Vector3.forward * Time.deltaTime * forwardInput * speed);
        // transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * turnSpeed);
    }

    void FixedUpdate()
    {
        // improved codebase learned with claude code
        Vector3 movement = transform.forward * (forwardInput * speed * Time.fixedDeltaTime);
        Quaternion turn = Quaternion.Euler(0f, horizontalInput * turnSpeed * Time.fixedDeltaTime, 0f);
        rigidBody.MovePosition(rigidBody.position + movement);
        rigidBody.MoveRotation(rigidBody.rotation * turn);
    }
}
