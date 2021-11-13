using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerControls controls;
    Vector2 move;
    private bool onGround = true;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float sensitivity;
    [SerializeField] private float jumpForce;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Buttons.performed += ctx => Buttons_performed(ctx.control);
        controls.Player.Move.performed += ctx => SendMessage(ctx.ReadValue<Vector2>());
        controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => move = Vector2.zero;
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
        Debug.Log("Thumb-stick coordinates = " + coordinates);
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(move.x, 0.0f, move.y) * speed
                                                             * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
    private void Buttons_performed(InputControl control)
    {
        Debug.Log($"Buttons performed received: {control.name}, {control.displayName}");
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
