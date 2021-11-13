using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtFMovement : MonoBehaviour
{
    private Vector3 playerMovementInput;
    private Vector3 playerMouseInput;
    private float xRot;
    private bool onGround = true;
    private GameObject backpack;
    private GameObject teamColor;

    [SerializeField] private Transform playerCamera;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private float speed;
    [SerializeField] private float sensitivity;
    [SerializeField] private float jumpForce;

	private void Start()
	{
        backpack = GameObject.Find("Backpack");
        teamColor = GameObject.Find("Team");
	}

	private void Update()
    {
        //Gets the values of mouse and key inputs
        playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        playerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        //Resets spawn of the flag
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject flag;
            GameObject flagSpawn;
            flag = GameObject.Find("FlagObject");
            flagSpawn = GameObject.Find("Red Flag Spawn");
            flag.transform.parent = flagSpawn.transform;
            flag.transform.localPosition = new Vector3(0f, 1.5f, 0f);
            flag.transform.rotation = flagSpawn.transform.rotation;
        }
        //Only call MovePlayer() if there is input
        if (playerMovementInput != Vector3.zero)
        {
            MovePlayer();
        }
        //Only call MovePlayerCamera if there is input
        if (playerMouseInput != Vector3.zero)
        {
            MovePlayerCamera();
        }
    }
    private void MovePlayer()
    {
        //Moves the player in regards to the keyboard inputs
        Vector3 moveVector = transform.TransformDirection(playerMovementInput) * speed;
        playerRb.velocity = new Vector3(moveVector.x, playerRb.velocity.y, moveVector.z);

        //Makes the player jump
        if(Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
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
    private void OnTriggerEnter(Collider other)
    {
        //Checks tag of gameObject that player collided with
        //Checks for "Flag" tag
        if (other.gameObject.CompareTag("Flag"))
        {
            //Finds a gameobject named "Flag"
            Transform flag = other.gameObject.transform.Find("Flag");

            //If flag's tag is the opposite of that of the player's team tag
            if (teamColor.tag != flag.tag)
            {
                Debug.Log("You got the flag!");
                other.gameObject.transform.parent = transform;
                other.gameObject.transform.localPosition = new Vector3(0f,1.3f,-0.8f);
                other.gameObject.transform.rotation = backpack.transform.rotation;
            }
            //This tells the player they are interacting with their own flag
            else
            {
                Debug.Log("This is your team's flag!");
            }
        }
    }
}
