using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public Joystick joystick;
    public GameObject character;
    public Animator characterAnimator;

    public Rigidbody characterRb;

    void Update(){
        if(!CharacterHealth.alive){
            return;
        }
        else if(joystick.Vertical != 0 || joystick.Horizontal != 0){

            float heading = Mathf.Atan2(joystick.Horizontal,joystick.Vertical);
            character.transform.rotation=Quaternion.Euler(0f,heading*Mathf.Rad2Deg,0f);

            characterAnimator.SetBool("run", true);

            Vector3 tempVect = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
            tempVect = tempVect.normalized * 3f * Time.deltaTime;
            characterRb.MovePosition(character.transform.position + tempVect);

            //character.transform.Translate(Vector3.forward/10*Time.timeScale/2);
        }
        else{
            characterRb.velocity=Vector3.zero;
            characterAnimator.SetBool("run", false);
        }
    }

}
