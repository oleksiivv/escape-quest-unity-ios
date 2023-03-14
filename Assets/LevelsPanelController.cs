using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelsPanelController : MonoBehaviour
{
    public Image[] levels;
    public Image[] padlock;

    public Color32 activeColor, unavailableColor;

    void Start(){
        showLevels();
    }


    void showLevels(){

        for(int i=0;i<levels.Length; i++){
            if(i < PlayerPrefs.GetInt("level",1)){
                padlock[i].gameObject.SetActive(false);
                levels[i].GetComponent<Image>().color = activeColor;
            }
            else{
                padlock[i].gameObject.SetActive(true);
                levels[i].GetComponent<Image>().color = unavailableColor;
            }
        }

    }
}
