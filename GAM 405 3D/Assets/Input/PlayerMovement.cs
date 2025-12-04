using JetBrains.Annotations;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
public class Playermovement : MonoBehaviour
{
    public static Playermovement i;

    public InputActionReference moveAction;
    public InputActionReference lookAction;
    public InputActionReference jumpAction;
    public Transform cameraTransform;

    public float mouseSensitivity = 2f;

    public float moveSpeed = 5f;

    public bool isGrounded = false;

    [SerializeField] private Vector2 moveInput;
    [SerializeField] private Vector2 lookInput;
    [SerializeField] float floorCheckDistance;
    [SerializeField] float jumpSpeed;
    [SerializeField] float gravity;

    float pitch;

    [SerializeField] private Rigidbody rb;

    bool paused = false;
    private object pause;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {bool jumpInput = Input.GetKeyDown(KeyCode.Space);
        i = this;

        rb = GetComponent<Rigidbody>();
        //this grabs the rigid body component 

    }

    private void OnDestroy()
    {
        i = null;
    }


    void Update()
    {
        if(paused)
        {
            return;
        }
        
        moveInput = moveAction != null ? moveAction.action.ReadValue<Vector2>() : Vector2.zero;
       // lookInput = lookAction != null ? lookAction.action.ReadValue<Vector2>() : Vector2.zero;
        
        //bool jumpInput = jumpAction.action.started;

       // if (cameraTransform) HandleLook();

       
    }

    private void FixedUpdate()
    {
        HandleMovement(jumpAction);
    }

    void OnEnable()
    {
        moveAction?.action.Enable();
       lookAction?.action.Enable();

    }
    void OnDisable()
    {
        moveAction?.action.Disable();
        lookAction?.action.Disable();

    }

    private void HandleMovement(bool jumpInput)
    {
        if(jumpInput)
        {
            Debug.Log("Jump input is working");
        }

        Vector3 inputDir = new Vector3(moveInput.x, 0f, moveInput.y);
        if (inputDir.sqrMagnitude > 1f) inputDir.Normalize();

        Vector3 move = transform.TransformDirection(inputDir) * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);



        Vector3 horizontalVelocity = transform.TransformDirection(inputDir) * moveSpeed;
        Vector3 verticalVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);

        if (isGrounded == true)
        {

            if (jumpInput)
            {
                verticalVelocity = Vector3.up * jumpSpeed;
            }
        }
        else if(isGrounded == false) 
        {
            verticalVelocity -= Vector3.up * gravity * Time.deltaTime;
        }


        rb.linearVelocity = horizontalVelocity + verticalVelocity;
    }

  /*  public void HandleLook()
    {
        float yaw = lookInput.x * mouseSensitivity;
        transform.Rotate(Vector3.up * yaw, Space.World);

        pitch -= lookInput.y * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -80f, 80f);
        cameraTransform.localEulerAngles = new Vector3(pitch, 0f, 0f);

    }*/
    public void GroundCheck()
    {
        RaycastHit hitInfo;
        Physics.Raycast(this.transform.position, -transform.up, out hitInfo, floorCheckDistance);

        if(hitInfo.collider != null)
        {
            isGrounded = true;
            
        }
        else
        {
            isGrounded = false;
        }
    }
    //private void OnEnable() => EventManager.TogglePause += TogglePause;

   // private void OnDisable() => EventManager.TogglePause -= TogglePause;

    public void TogglePause(bool paused)
    {
       // pause.SetActive(paused);
      //  object Value = pause.SetActive(paused);
      //  _ = pause.SetActive(paused);
    }


}


