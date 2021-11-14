using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerControls controls;
    Vector2 move;
    float look;
    private bool onGround = true;
    private float xRot;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float speed;
    [SerializeField] private float sensitivity;
    [SerializeField] private float jumpForce;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Buttons.performed += ctx => ButtonsPerformed(ctx.control);
        controls.Player.Move.performed += ctx => SendMessage(ctx.ReadValue<Vector2>());
        controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => move = Vector2.zero;

        controls.Player.Look.performed += ctx => MovePlayerCamera(ctx.ReadValue<float>());
        controls.Player.Look.performed += ctx => look = ctx.ReadValue<float>();
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }
    void SendMessage(Vector2 coordinates)
    {
        //Tests LEFT thumbstick input
        Debug.Log("Thumb-stick coordinates = " + coordinates);
    }
    void FixedUpdate()
    {
        //To move the player in regards to their position and rotation
        Vector3 movement = new Vector3(move.x, 0.0f, move.y) * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);
    }
    private void MovePlayerCamera(float input)
    {
        //To move the player's character AND camera

    }
    private void ButtonsPerformed(InputControl control)
    {
        //Checks any buttons pressed on controller
        Debug.Log($"Buttons performed received: {control.name}, {control.displayName}");
        //button 3 is "A" on Switch controller
        if (control.name == "button3" && onGround == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        }
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
