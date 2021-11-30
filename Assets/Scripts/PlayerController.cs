using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerControls controls;
    Vector2 move;
    float horizontalLook;
    float verticalLook;
    private bool onGround = true;
    private bool deceased = false;
    private bool respawning = false;
    private float xRot;
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
        controls.Player.Buttons.performed += ctx => ButtonsPerformed(ctx.control);
        controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => move = Vector2.zero;

        //Takes input values from thumbstick's horizontal and vertical axis values
        controls.Player.HorizontalLook.performed += ctx => horizontalLook = ctx.ReadValue<float>();
        controls.Player.VerticalLook.performed += ctx => verticalLook = ctx.ReadValue<float>();
    }
	private void Start()
	{
        //Saves the camera localPosition and localRotation
        Vector3 currentCamTransform = transform.Find("Camera").transform.localPosition;
        Quaternion currentCamQuarternion = transform.Find("Camera").transform.localRotation;
    }

	private void OnEnable()
    {
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }
    void FixedUpdate()
    {
        //Ensures the player is alive
        if (deceased != true)
        {
            //To move the player in regards to their position and rotation
            Vector3 movement = new Vector3(move.x, 0.0f, move.y) * speed * Time.deltaTime;
            transform.Translate(movement, Space.Self);
        }
    }
	private void Update()
	{
        //Ensures the player is alive
        if (deceased != true)
        {
            //Rotates the camera in regards to the right thumbstick input
            xRot -= -verticalLook * sensitivity;

            transform.Rotate(0f, horizontalLook * sensitivity, 0f);
            playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        }
        //if the player is dead...
        else if (deceased == true && respawning == false)
        {
            StartCoroutine(Respawn());
            respawning = true;
        }
    }
    private void ButtonsPerformed(InputControl control)
    {
        //Ensures the player is alive
        if (deceased != true)
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
    }
	private void OnCollisionEnter(Collision collision)
	{
        //Checks if player has touched a wall. If so, the player cannot jump
        if (collision.gameObject.CompareTag("Wall"))
        {
            onGround = false;
        }
        //Checks if player has collided with the Dead Zone (Pink Milk)
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            deceased = true;
            Debug.Log("Player has died...");
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
