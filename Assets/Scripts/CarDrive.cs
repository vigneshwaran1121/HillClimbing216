using UnityEngine;
using UnityEngine.InputSystem;

public class CarDrive : MonoBehaviour

{
    [SerializeField] private Rigidbody2D frontTireRB;
    [SerializeField] private Rigidbody2D backTireRB;
    [SerializeField] private Rigidbody2D carRB;

    [SerializeField] private float speed = 50f;
    [SerializeField] private float rotationSpeed = 50f;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheckFront;
    [SerializeField] private Transform groundCheckBack;
    [SerializeField] private float groundCheckRadius = 0.2f;

    private float moveInput;

    void Update()
    {
        moveInput = GetInput();

        // DEBUG: confirm input is detected
        if (moveInput != 0)
            Debug.Log("INPUT: " + moveInput);
    }

    float GetInput()
    {
        float input = 0f;

        // 📱 TOUCH (mobile)
        if (Input.touchCount > 0)
        {
            float x = Input.GetTouch(0).position.x;

            if (x < Screen.width * 0.5f)
                input = -1f;
            else
                input = 1f;
        }

        // 🖱 MOUSE (editor testing)
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x < Screen.width * 0.5f)
                input = -1f;
            else
                input = 1f;
        }

        // ⌨ KEYBOARD (editor testing)
        if (Input.GetKey(KeyCode.LeftArrow)) input = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) input = 1f;

        return input;
    }

    void FixedUpdate()
    {
        bool grounded =
            Physics2D.OverlapCircle(groundCheckFront.position, groundCheckRadius, groundLayer) ||
            Physics2D.OverlapCircle(groundCheckBack.position, groundCheckRadius, groundLayer);

        // wheel torque
        frontTireRB.AddTorque(-moveInput * speed);
        backTireRB.AddTorque(-moveInput * speed);

        // air rotation
        if (!grounded)
        {
            carRB.AddTorque(-moveInput * rotationSpeed);
        }
    }
}