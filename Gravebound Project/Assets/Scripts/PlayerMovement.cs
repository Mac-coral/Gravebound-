using UnityEngine;
using UnityEngine.UI; 

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform playerCamera;

    [Header("Movement Settings")]
    public float walkSpeed = 20f;
    public float sprintSpeed = 43f;
    public float gravity = -251f;
    public float jumpHeight = 2f;

    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 150f;

    [Header("Stamina Settings")]
    public Slider staminaBar;       
    public float maxStamina = 100f;
    public float staminaDrainRate = 20f; 
    public float staminaRegenRate = 10f; 

    private float currentStamina;
    private float xRotation = 0f;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        currentStamina = maxStamina;

        if (staminaBar != null)
        {
            staminaBar.maxValue = maxStamina;
            staminaBar.value = currentStamina;
        }
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
        UpdateStamina();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) && currentStamina > 0f;
        float speed = isSprinting ? sprintSpeed : walkSpeed;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        
        if (isSprinting)
            currentStamina -= staminaDrainRate * Time.deltaTime;
        else if (currentStamina < maxStamina)
            currentStamina += staminaRegenRate * Time.deltaTime;

        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
    }

    void UpdateStamina()
    {
        if (staminaBar != null)
            staminaBar.value = currentStamina;
    }
}


