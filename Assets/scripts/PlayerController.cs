using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 25;
    [SerializeField] private float turnSpeed = 10;
    [SerializeField] private float accelerationRate = 10f;
    [SerializeField] private float decelerationRate = 15f;

    private float horizontalInput;
    private float currentSpeed;
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
    }

    void FixedUpdate()
    {
        // Target speed based on input (forwardInput ranges -1 to 1)
        float targetSpeed = maxSpeed * forwardInput;
        float rate = (Mathf.Abs(targetSpeed) > Mathf.Abs(currentSpeed)) ? accelerationRate : decelerationRate;
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, rate * Time.deltaTime);
        // improved codebase learned with claude code
        Vector3 movement = transform.forward * (currentSpeed * Time.fixedDeltaTime);
        Quaternion turn = Quaternion.Euler(0f, horizontalInput * turnSpeed * Time.fixedDeltaTime, 0f);
        rigidBody.MovePosition(rigidBody.position + movement);
        rigidBody.MoveRotation(rigidBody.rotation * turn);
    }
}
