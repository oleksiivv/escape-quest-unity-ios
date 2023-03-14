using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    protected Vector3 newDir;
    public float speed=1;
    protected float startSpeed;

    public GameObject player;

    protected bool moveTowardsPlayer;
    protected Rigidbody rb;


    void Start(){
        startSpeed=speed;
        moveTowardsPlayer=true;

        rb=gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(PlayerPrefs.GetInt("Studied",-1) == -1){
            return;
        }

        if(moveTowardsPlayer && !PumpkinsController.win){
            Vector3 diff = player.transform.position - transform.position;
            //diff.y = transform.position.y;
            newDir = Vector3.RotateTowards(transform.forward, diff, 1, 0.0F);
            transform.rotation = Quaternion.LookRotation(newDir);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                
                //rb.AddRelativeForce(Vector3.forward*0.06f*Time.timeScale/8*speed, ForceMode.VelocityChange);
            transform.Translate(Vector3.forward*0.06f*Time.timeScale/8*speed);
        }
        else{
            //rb.AddRelativeForce(Vector3.forward*0.06f*Time.timeScale/8*speed, ForceMode.VelocityChange);
            transform.Translate(Vector3.forward*0.06f*Time.timeScale/8*speed);
        }
    }


    public void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            if(other.isTrigger && moveTowardsPlayer){
                speed=8;
            }
            else{
                moveTowardsPlayer=false;
                Invoke(nameof(resetSpeed), 2f);
                Invoke(nameof(restartMoveToPlayer), 10);
            }
        }
    }

    protected void resetSpeed(){
        speed=startSpeed;
    }

    protected void restartMoveToPlayer(){
        moveTowardsPlayer=true;
    }
}
