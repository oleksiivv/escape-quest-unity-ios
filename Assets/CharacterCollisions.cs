using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisions : MonoBehaviour
{
    public CharacterHealth health;
    public PumpkinsController pumpkins;
    public BaseUI ui;

    public CharacterFX fx;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Ghost"){
            var diff = gameObject.transform.position - other.gameObject.transform.position;

            if(Mathf.Abs(diff.x) < 1 && Mathf.Abs(diff.z) < 1){
                health.updateHealth(-10);
                Debug.Log("Enter");
            }
        }
        else if(other.gameObject.tag == "Health"){
            fx.healthGetEffect.Play();
            health.updateHealth(10);
            Destroy(other.gameObject);
        }
        // else if(other.gameObject.tag == "Pumpkin"){
        //     pumpkins.updatePumpkinsValue(1);
        //     fx.itemGetEffect.Play();
        //     Destroy(other.gameObject);
        // }
    }

    void OnCollisionStay(Collision other){
        if(other.gameObject.tag == "Zombie"){
            health.updateHealth(-0.25f);
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Pumpkin"){
            pumpkins.updatePumpkinsValue(1);
            fx.itemGetEffect.Play();
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Finish"){
            PlayerPrefs.SetInt("level", Application.loadedLevel+1);
            ui.setWinPanelActive(true);
            Time.timeScale=0;
        }
    }


}
