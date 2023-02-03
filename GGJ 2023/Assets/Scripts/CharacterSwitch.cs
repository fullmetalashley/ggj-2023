using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Currently, just switches which character is actively moving. 
public class CharacterSwitch : MonoBehaviour
{
    public List<Player> characters;
    private CameraFollow theCamera;

    void Start()
    {
        theCamera = FindObjectOfType<CameraFollow>();
    }

    public void SwitchChars()
    {
        foreach (Player movement in characters)
        {
            movement.active = !movement.active;
            movement.GetComponent<BoxCollider2D>().enabled = movement.active;
            movement.controller.enabled = movement.active;
            
            if (movement.active)
            {
                //Call the camera and set this to the new thing
                theCamera.SwitchTarget(movement.controller);
            }
        }
    }
}
