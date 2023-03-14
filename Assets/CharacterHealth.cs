using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public Slider healthBar;

    public static bool alive=true;

    private float health;

    public Animator characterAnimator;

    public BaseUI ui;

    void Start(){
        health = 100;
        alive=true;
    }

    public void updateHealth(float value){
        health+=value;
        if(health>100){
            health=100;
        }
        else if(health<0){
            health=0;
            death();
        }
        showHealthValue(health);
    }

    private void showHealthValue(float val){
        healthBar.value = val;
    }

    public void death(){
        alive=false;
        characterAnimator.SetBool("dead", true);
        Invoke(nameof(showDeathPanel), 2f);
    }

    public void showDeathPanel(){
        ui.setDeathPanelActive(true);
    }
}
