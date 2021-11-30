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
    private bool deceased = false;
    private bool respawning = false;
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

        //Changes eyes to DEATH
        Transform eyes = transform.Find("Model").Find("Face").Find("Eyes"); //Locates "Eyes" in model
        GameObject currentEyes = eyes.GetChild(0).gameObject; //Gets gameObject of currently selected eyes
        currentEyes.gameObject.SetActive(false); //Sets currently selected eyes to inactive
        eyes.Find("Dead Eyes").gameObject.SetActive(true); //Sets Dead Eyes to active

        yield return new WaitForSeconds(5f); //Length of Respawn Time

        //Returns Camera to original position and rotation;
        transform.Find("Camera").transform.localPosition = currentCamTransform;
        transform.Find("Camera").transform.localRotation = currentCamQuarternion;

        //Spawns character in a random spawnpoint
        if (GameObject.Find("RedSpawner").tag == transform.tag) //Used for RED Team
        {
            GameObject redSpawner = GameObject.Find("RedSpawner");
            int totalSpawners = redSpawner.transform.childCount;
            transform.position = redSpawner.transform.GetChild(Random.Range(0, totalSpawners - 1)).position;
        }
        else if (GameObject.Find("BlueSpawner").tag == transform.Find("Team").tag) //Used for BLUE Team
        {
            GameObject blueSpawner = GameObject.Find("BlueSpawner");
            int totalSpawners = blueSpawner.transform.childCount;
            transform.position = blueSpawner.transform.GetChild(Random.Range(0, totalSpawners)).position;
        }

        //Player has been revived and respawn completes
        deceased = false;
        respawning = false;

        //Returns eyes to original active states
        eyes.Find("Dead Eyes").gameObject.SetActive(false);
        eyes.Find(currentEyes.name).gameObject.SetActive(true);
    }
}
