using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls movement for either character based on keyboard input.
public class CharacterMovement : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D body;    
    public SpriteRenderer spriteRenderer;
    
    [Header("Settings")]
    public float walkSpeed; //How quick would you like to move?
    public bool active;

    private Vector2 direction;  //The actual direction value, from input
    
    void Start()
    {
        body = this.gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active) //If this character is currently allowed to move...
        {
            direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

            //Set walk based on direction
            body.velocity = direction * walkSpeed;
        }
    }
}
