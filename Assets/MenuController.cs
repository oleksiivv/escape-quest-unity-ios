using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject levelsPanel;

    void Start(){
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality",0));
    }

    public void setLevelsPanelActive(bool active){
        levelsPanel.SetActive(active);
    }

    public void openLevel(int level){
        if(PlayerPrefs.GetInt("level",1) >= level){
            StartCoroutine(loadAsync(level));
        }
    }

    public void openScene(int id){
        StartCoroutine(loadAsync(id));
    }



    public GameObject loadingPanel;
    public Slider loadingSlider;

    IEnumerator loadAsync(int id)
    {
        AsyncOperation operation = Application.LoadLevelAsync(id);
        loadingPanel.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingSlider.value = progress;
            Debug.Log(progress);
            yield return null;

        }
    }
}
