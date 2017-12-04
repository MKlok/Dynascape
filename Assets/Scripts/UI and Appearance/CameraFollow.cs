using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private GameObject player;       //Public variable to store a reference to the player game object

    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        GameObject oc = GameObject.FindWithTag("OverworldController");

        player = oc.gameObject.GetComponent<PlayerInput>().GetPlayer();


        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = new Vector3(0, 0, transform.position.z - player.transform.position.z);
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}