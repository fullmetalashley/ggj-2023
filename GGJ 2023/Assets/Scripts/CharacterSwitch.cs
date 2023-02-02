using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Currently, just switches which character is actively moving. 
public class CharacterSwitch : MonoBehaviour
{
    public List<CharacterMovement> theCharacters;
    private CameraController theCamera;

    void Start()
    {
        theCamera = FindObjectOfType<CameraController>();
    }

    public void SwitchChars()
    {
        foreach (CharacterMovement movement in theCharacters)
        {
            movement.active = !movement.active;
            if (movement.active)
            {
                //Call the camera and set this to the new thing
                theCamera.SwitchTarget(movement);
            }
        }
    }
}
