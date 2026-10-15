using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private InputSystem_Actions controls;
    public float rotationSpeed = 150f; // Adjust this value to control the rotation speed   

    private void Awake()
    {
        controls = new InputSystem_Actions();
    }

    void OnEnable()
    {
        controls.Player.Enable();
        Debug.Log("Controls enabled");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
        float horizontalInput = moveInput.x; // Left/Right movement AD - Arrows
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * rotationSpeed); // Rotate the camera around the Y-axis
    }
}
