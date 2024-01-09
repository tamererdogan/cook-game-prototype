using UnityEngine;

public class ChefController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 150f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 movementVector = transform.TransformDirection(new Vector3(0, 0, verticalInput)) * moveSpeed * Time.fixedDeltaTime;
        rigidBody.MovePosition(transform.position + movementVector);
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.fixedDeltaTime);
    }
}
