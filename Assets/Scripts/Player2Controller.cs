using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Controller : MonoBehaviour
{
    PlayerControls controls;
    Vector2 move;
    private float xRot;
    private bool onGround = true;
    private Vector3 playerMouseInput;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float speed;
    [SerializeField] private float sensitivity;
    [SerializeField] private float jumpForce;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Player2.Keys.performed += ctx => KeysPerformed(ctx.control);
        controls.Player2.Move.performed += ctx => SendMessage(ctx.ReadValue<Vector2>());
        controls.Player2.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player2.Move.canceled += ctx => move = Vector2.zero;
    }
    private void KeysPerformed(InputControl control)
    {
        //Allows player to jump in "space" is pressed and sets onGround to false 
        if (control.name == "space" && onGround == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        }
    }
    private void OnEnable()
    {
        controls.Player2.Enable();
    }
    private void OnDisable()
    {
        controls.Player2.Disable();
    }
    void SendMessage(Vector2 coordinates)
    {
        //Tests WASD controls
        Debug.Log("Keyboard coordinates = " + coordinates);
    }

    void FixedUpdate()
    {
        //To move the player in regards to their position and rotation
        Vector3 movement = new Vector3(move.x, 0.0f, move.y) * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);
    }
	private void Update()
	{
        playerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        //Only call MovePlayerCamera if there is input
        if (playerMouseInput != Vector3.zero)
        {
            MovePlayerCamera();
        }
    }
	private void MovePlayerCamera()
    {
        //Rotates the camera in regards to the mouse input
        xRot -= playerMouseInput.y * sensitivity;

        transform.Rotate(0f, playerMouseInput.x * sensitivity, 0f);
        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Checks if player has touched the ground
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }

}
