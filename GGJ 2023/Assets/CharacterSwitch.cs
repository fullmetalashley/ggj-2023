using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Currently, just switches which character is actively moving. 
public class CharacterSwitch : MonoBehaviour
{
    public List<CharacterMovement> theCharacters;

    public void SwitchChars()
    {
        foreach (CharacterMovement movement in theCharacters)
        {
            movement.active = !movement.active;
        }
    }
}
