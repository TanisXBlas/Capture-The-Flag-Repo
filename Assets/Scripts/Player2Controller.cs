using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Controller : MonoBehaviour
{
    PlayerControls controls;
    Vector2 move;
    public List<GameObject> spawnPoints;
    public List<GameObject> eyes;
    private float xRot;
    private float flagLift = 1.5f; //This variable is meant to bring up the flag so it doesn't clip through the ground
    private bool onGround = true;
    private bool deceased = false;
    private bool respawning = false;
    private int eyesId;
    private int originalEyesId;
    private Vector3 playerMouseInput;
    private Vector3 currentCamTransform;
    private Quaternion currentCamQuarternion;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float speed;
    [SerializeField] private float sensitivity;
    [SerializeField] private float jumpForce;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Player2.Keys.performed += ctx => KeysPerformed(ctx.control);
        controls.Player2.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player2.Move.canceled += ctx => move = Vector2.zero;
    }
	private void Start()
	{
        //Saves the camera localPosition and localRotation
        Vector3 currentCamTransform = transform.Find("Camera").transform.localPosition;
        Quaternion currentCamQuarternion = transform.Find("Camera").transform.localRotation;
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

    void FixedUpdate()
    {
        //Ensures the player is not deceased
        if (deceased != true)
        {
            //To move the player in regards to their position and rotation using keyboard input
            Vector3 movement = new Vector3(move.x, 0.0f, move.y) * speed * Time.deltaTime;
            transform.Translate(movement, Space.Self);
        }
    }
	private void Update()
	{
        //Ensures the player is not deceased
        if (deceased != true)
        {
            playerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            //Only call MovePlayerCamera if there is input
            if (playerMouseInput != Vector3.zero)
            {
                MovePlayerCamera();
            }
        }
        //if the player is dead and hasn't started respawning...
        else if (deceased == true && respawning == false)
        {
            StartCoroutine(Respawn());
            respawning = true; //Starts the player's respawn, prevents multiple Respawn calls
        }
    }
	private void MovePlayerCamera()
    {
        //Ensures the player is not deceased
        if (deceased != true)
        {
            //Rotates the camera in regards to the mouse input
            xRot -= playerMouseInput.y * sensitivity;

            transform.Rotate(0f, playerMouseInput.x * sensitivity, 0f);
            playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Checks if player has touched a wall. If so, the player cannot jump
        if (collision.gameObject.CompareTag("Wall"))
        {
            onGround = false;
        }
        //Checks if player has collided with the Dead Zone (Pink Milk); INSTANT DEATH
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            deceased = true;
        }
        // If the player touches any surface, they can jump
        else
        {
            onGround = true;
        }
    }
    public IEnumerator Respawn()
    {
        //Player is now respawning...
        //Changes camera position to face character
        transform.Find("Camera").transform.localPosition = new Vector3(0f, 0.5f, 5f);
        transform.Find("Camera").transform.localRotation = new Quaternion(0f, 180f, 0f, 0f);

        //If player is holding a flag, return the flag
        if (transform.Find("FlagObject"))
        {
            Transform flagReturn = transform.Find("FlagObject");
            //Returns the RED FlagObject to its team's spawn
            if (flagReturn.transform.Find("Flag").tag == "Red")
            {
                Transform spawn = GameObject.Find("Red Flag Spawn").transform;
                flagReturn.transform.parent = spawn;
                //Resets the transform of the FlagObject to match that of the flag's spawn 
                flagReturn.transform.localPosition = new Vector3(0f, flagLift, 0f);
                flagReturn.transform.localRotation = spawn.transform.localRotation;
            }
        }

        //Changes eyes to DEATH
        eyesId = originalEyesId; //Saves eye Id to a new variable
        eyes[eyesId].SetActive(false); //Current eyes (iriginal) active state set to false
        eyesId = eyes.Count - 1; //New eye Id becomes the last in the list (Dead Eyes)
        eyes[eyesId].SetActive(true); //Current eyes (Dead Eyes) active state set to true

        yield return new WaitForSeconds(5f); //Length of Respawn Time

        //Returns Camera to original position and rotation;
        transform.Find("Camera").transform.localPosition = currentCamTransform;
        transform.Find("Camera").transform.localRotation = currentCamQuarternion;

        //Spawns character in a random spawnpoint
        transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position;

        //Player has been revived and respawn completes
        deceased = false;
        respawning = false;

        //Returns eyes to original active states
        eyes[eyesId].SetActive(false); //Current eyes (Dead Eyes) active state set to false
        eyesId = originalEyesId; //eyesId returned to original
        eyes[eyesId].SetActive(true); //New eyes (original) active state set to true
    }
}
