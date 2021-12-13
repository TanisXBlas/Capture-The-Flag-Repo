using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMechanics : MonoBehaviour
{
    private Transform backpack;
    private Transform teamColor;
    private float flagLift = 1.5f; //This variable is meant to bring up the flag so it doesn't clip through the ground
    private float flagPush = -0.8f; //This variable is meant to fix the flag's position while it is in the player's "backpack"
    // Start is called before the first frame update
    void Start()
    {
        backpack = transform.Find("Backpack");
        teamColor = transform.Find("Team");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        //Checks if player collides with a Flag Platform
        if (collision.gameObject.CompareTag("Flag Platform"))
        {
            //Checks player's children for a "FlagObject" AND if the spawn platform (the Flag Platform's parent) has its own team's "FlagObject"
            if (transform.Find("FlagObject") && collision.gameObject.transform.parent.Find("FlagObject"))
            {
                //If found, this means the player has the opponent's flag AND their flag is still present in its spawn. Score a point
                Debug.Log("You scored a point.!");
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

                //Returns the BLUE FlagObject to its team's spawn
                else if (flagReturn.transform.Find("Flag").tag == "Blue")
                {
                    Transform spawn = GameObject.Find("Blue Flag Spawn").transform;
                    flagReturn.transform.parent = spawn;
                    //Resets the transform of the FlagObject to match that of the flag's spawn 
                    flagReturn.transform.localPosition = new Vector3(0f, flagLift, 0f);
                    flagReturn.transform.localRotation = spawn.transform.localRotation;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Checks tag of gameObject that player collided with
        //Checks for "Flag" TAG on trigger object (FlagObject)
        if (other.gameObject.CompareTag("Flag"))
        {
            //Finds a GAMEOBJECT named "Flag"
            Transform flag = other.gameObject.transform.Find("Flag");

            //If flag's tag is the opposite of that of the player's team tag
            if (teamColor.tag != flag.tag)
            {
                Debug.Log("You got the flag!");
                other.gameObject.transform.parent = transform;
                other.gameObject.transform.localPosition = new Vector3(0f, flagLift, flagPush);
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
