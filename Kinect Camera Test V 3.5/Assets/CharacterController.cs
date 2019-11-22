using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Main Class = Same as File Name: CharacterController
public class CharacterController : MonoBehaviour
{
    // Public exposed variable - speed
    // How fast the charater responds to the keyboard movements
    // or the controller movements
    public float speed = 10.0F;

    // Ise this for initialization
    // FUNCTION - Start
    void Start()
    {
        // This turns off the cursor and keeps it inside the 
        // game window
        // Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
    }

    // FUNTION - Update is called once per frame
    // An update loop does not run at exactly the same
    // time during each iteration of the loop, depending
    // on what's happening in the game
    void Update()
    {
        // "Vertical" and "Horizontal" are global settings from UNITY to define what
        // the keyboard, joystick, etc. will do...
        float translation = Input.GetAxis("Vertical") * speed;  // Forwards and backwards movement
        float straffe = Input.GetAxis("Horizontal") * speed;    // Side-side movements

        // Movement of the character: translate: multipiply by deltaTime to keep the movements
        // smooth and keep up with the Update FUNCTION
        translation *= Time.deltaTime;  // The delta-time is the time interval between updates
        straffe *= Time.deltaTime;      // Using this delta-time to be in sync with the updates

        // Straffe (side-side) along the x-axis and translate along the z axis
        transform.Translate(straffe, 0, translation);

        // If we hit the escape key, the cursor will turn back on
        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;

    }
}
