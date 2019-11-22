using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CLASS - camMouseLook

public class camMouseLook : MonoBehaviour
{
    // This keeps track of how movement the camera has made
    // since the last update; we need to keep track of the
    // total movement so we can add it to the controller
    Vector2 mouseLook;
    Vector2 smoothV;   // This helps smooth out the mouse movement
    public float sensitivity = 5.0f;  // Mouse sensitivity
    public float smoothing = 2.0f;    // How much movement we want

    GameObject character;   // This points back to the camera

    // Start is called before the first frame update
    void Start()
    {
        character = this.transform.parent.gameObject;  // The parent in this case is the camera
  
    }

    // Update is called once per frame
    void Update()
    {
        // Allows control by getting the movement of the mouse
        // md = "mouse delta"
        // Then multiply the change in mouse movement (delta) by the smoothing and 
        // sensitivity values
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing) ;   // Slows it down and Lerps = Linear Interpolation of Movement 
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing) ;   // Lerp is very useful when moving between one point and another smoothly
        mouseLook += smoothV;                                       // rather than "snapping" from point to point
        // Adding operator of all the operations
        
        // Add the mouse look y as a local rotation to the camera along its right axis
        // the "-" is an inverted system
        // rotation about the y-axis with mouse UP-DOWN
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        // Rotate about the character's upward movement, not the camera, because we want the whole
        // character to move - MOUSE SIDE-SIDE
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
