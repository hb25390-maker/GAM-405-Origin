using UnityEngine;
using UnityEngine.InputSystem;
public class CameraControl : MonoBehaviour

{
    [SerializeField] private float sensitivity = 5f;
    [SerializeField] private Vector2 clampValue = new(-75f, 75f);
    public bool isActive = false;
    

    public InputActionReference cameraAction;

    void Update()
    {
        if (!isActive || cameraAction == null)
        {
            return;
        }
        Vector2 cameraInput = new(-cameraAction.action.ReadValue<Vector2>().y, 0f);
        cameraInput *= sensitivity;
        transform.Rotate(cameraInput); 
        float cameraEulerX = transform.rotation.eulerAngles.x > 180f ? transform.rotation.eulerAngles.x - 360f : transform.rotation.eulerAngles.x;
        transform.rotation = Quaternion.Euler(Mathf.Clamp(cameraEulerX,clampValue.x,clampValue.y), transform.rotation.eulerAngles.y, 0f);
        //Debug.Log(transform.rotation.eulerAngles.x);
    }
}
