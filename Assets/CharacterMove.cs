using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public Joystick joystick;
    public GameObject character;
    public Animator characterAnimator;

    public Rigidbody characterRb;
    private float speed = 4f;

    void Start() {
        characterRb.freezeRotation = true;
        characterRb.useGravity = false;
    }

    void FixedUpdate(){
        if(!CharacterHealth.alive){
            return;
        }

        // Get the input from the joystick.
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        // Check if there is significant input to consider movement.
        if(Mathf.Abs(horizontalInput) > 0.01f || Mathf.Abs(verticalInput) > 0.01f){

            float heading = Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg;
            character.transform.rotation = Quaternion.Euler(0f, heading, 0f);

            characterAnimator.SetBool("run", true);

            Vector3 tempVect = new Vector3(horizontalInput, 0, verticalInput);
            tempVect = tempVect.normalized * speed * Time.deltaTime;

            characterRb.MovePosition(character.transform.position + tempVect);
        }
        else{
            // Stop moving and reset the velocity to zero to stop the character when input stops.
            characterRb.velocity = Vector3.zero;
            characterAnimator.SetBool("run", false);
        }
    }
}
