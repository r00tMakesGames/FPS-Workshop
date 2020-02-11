using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 60f;
    public float mouseSensitivity = 1f;
    public float maxLookRotation = 45f;

    private float verticalRotation;
    private CharacterController controller = null;
    private float xInput = 0f;
    private float zInput = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        Look();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void Move()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        Vector3 movement = (zInput * transform.forward) + (xInput * transform.right);
        controller.Move(Time.deltaTime * movementSpeed * movement);
    }

    private void Look()
    {
        
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        verticalRotation = Mathf.Clamp(verticalRotation + (mouseY * mouseSensitivity), -maxLookRotation, maxLookRotation);

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x = -verticalRotation;
        newRotation.y += mouseX * mouseSensitivity;

        transform.localEulerAngles = newRotation;
    }

    
}