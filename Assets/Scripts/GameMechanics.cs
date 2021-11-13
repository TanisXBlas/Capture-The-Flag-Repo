using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMechanics : MonoBehaviour
{
    private GameObject backpack;
    private GameObject teamColor;
    // Start is called before the first frame update
    void Start()
    {
        backpack = GameObject.Find("Backpack");
        teamColor = GameObject.Find("Team");
    }

    // Update is called once per frame
    void Update()
    {
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
    }
    private void OnCollisionEnter(Collision collision)
    {

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
                other.gameObject.transform.localPosition = new Vector3(0f, 1.3f, -0.8f);
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
