using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyController : MonoBehaviour
{
    public GameObject studyPanel;


    void Start(){
        if(PlayerPrefs.GetInt("Studied",-1) == -1){
            studyPanel.SetActive(true);
            Invoke(nameof(CompleteStudy), 7f);
        }
    }

    public void CompleteStudy(){
        PlayerPrefs.SetInt("Studied",1);
        studyPanel.SetActive(false);
    }
}
