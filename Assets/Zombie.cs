using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Ghost
{

    [SerializeField] private Animator m_animator = null;
    private float m_currentV = 0;
    private readonly float m_interpolation = 10;

    private bool attack=false;
   


    void Start(){
        speed=2;
        startSpeed=speed;
        moveTowardsPlayer=true;

        rb=gameObject.GetComponent<Rigidbody>();
    }

    public void OnTriggerEnter(Collider other){
        //
    }


    void OnCollisionStay(Collision other){
        if(other.gameObject.tag == "Player"){
            attack=true;
            m_animator.SetBool("Attack", true);
        }
    }

    void OnCollisionExit(Collision other){
        if(other.gameObject.tag == "Player"){
            attack=false;
            speed=0.3f;
            Invoke(nameof(resetSpeed), 5f);
            TankUpdate();
        }
    }

    private void FixedUpdate()
    {
       if(PlayerPrefs.GetInt("Studied",-1) == -1){
            return;
        }

        if(!PumpkinsController.win && !attack){
            Vector3 diff = player.transform.position - transform.position;

            newDir = Vector3.RotateTowards(transform.forward, diff, 1, 0.0F);
            transform.rotation = Quaternion.LookRotation(newDir);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            
            transform.Translate(Vector3.forward*0.06f*Time.timeScale/8*speed);
            TankUpdate();
        }
   
    }

    private void TankUpdate()
    {
        float v = 1;
        float h = 1;
        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);

        m_animator.SetFloat("MoveSpeed", m_currentV);
    }
}
