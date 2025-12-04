using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
   

    public float sphereRadius;
    public InputActionReference moveAction;
    public float moveSpeed = 5f;

    [SerializeField] private Vector2 moveInput;

    public bool isActive;
    [SerializeField] private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveInput = moveAction != null ? moveAction.action.ReadValue<Vector2>() : Vector2.zero;
    }

    void OnEnable()
    {
        moveAction?.action.Enable();


    }

    void OnDisable()
    {
        moveAction?.action.Disable();


    }




    // Pick up or interact logic here





    private void HandleMovement()
    {
        Vector3 inputDir = new Vector3(moveInput.x, 0f, moveInput.y);
        if (inputDir.sqrMagnitude > 1f) inputDir.Normalize();

        Vector3 move = transform.TransformDirection(inputDir) * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }

    void FixedUpdate()
    {
        HandleMovement();

    }
}








