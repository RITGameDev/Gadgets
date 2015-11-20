using UnityEngine;
using System.Collections;

public class PlayerCharacterController : ACharacterController
{
    // Input variables
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode use;
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement()
    {
        /* Moving and jumping with the keys. */
        if (Input.GetKey(left))
        {
            character.MoveLeft();
        }
        else if (Input.GetKey(right))
        {
            character.MoveRight();
        }
        if (Input.GetKeyDown(jump))
        {
            character.Jump();
        }
        // Using items
        if (Input.GetKeyDown(use))
        {
            character.Use();
        }
    }
}
