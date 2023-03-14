using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PumpkinsController : MonoBehaviour
{
    public Text pumpkins;
    public int pumpkinsCnt;

    public GameObject finish;
    public static bool win=false;

    void Start(){
        win=false;
        pumpkinsCnt=0;
        showPumpkinsValue();
    }

    public void updatePumpkinsValue(int n){
        pumpkinsCnt+=n;
        showPumpkinsValue();

        if(pumpkinsCnt>=10){
            winBehavior();
        }
    }

    void showPumpkinsValue(){
        pumpkins.text = pumpkinsCnt.ToString()+"/10";
    }

    public void winBehavior(){
        win=true;
        finish.SetActive(true);
    }
}
