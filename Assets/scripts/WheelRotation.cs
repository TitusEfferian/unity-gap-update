using UnityEngine;

public class WheelRotation : MonoBehaviour
{

    [SerializeField] private float wheelRadius = 0.3f;
    [SerializeField] private Vector3 localSpinAxis = Vector3.right;

    private float currentAngle;
    private PlayerController playerController;
    void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
    }


    // Update is called once per frame
    void Update()
    {
        float forwardSpeed = playerController.CurrentSpeed;
        float degreePerSecond = forwardSpeed / wheelRadius * Mathf.Rad2Deg;

        currentAngle += degreePerSecond * Time.deltaTime;
        currentAngle %= 360f;
        transform.localRotation = Quaternion.AngleAxis(currentAngle, localSpinAxis);

    }
}
