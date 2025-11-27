using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerRotate : MonoBehaviour
{

    public float sensitivity = 5f;
    public bool isActive = false;

    public Vector2 clampValue = new Vector2(-90f, 90f);
    public InputActionReference cameraAcion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            return;

            
        }
        Vector2 cameraInput = new Vector2(0f, cameraAcion.action.ReadValue<Vector2>().x);
        cameraInput *= sensitivity;
        transform.Rotate(cameraInput);
        float cameraEulerX = transform.rotation.eulerAngles.x > 180f ? transform.rotation.eulerAngles.x - 360f : transform.rotation.eulerAngles.x;
        transform.rotation = Quaternion.Euler(Mathf.Clamp(cameraEulerX, clampValue.x, clampValue.y), transform.rotation.eulerAngles.y, 0f);
    }
}
