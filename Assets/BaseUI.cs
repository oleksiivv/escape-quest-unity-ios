using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Advertisements;

public class BaseUI : MonoBehaviour
{
    public GameObject pausePanel, deathPanel, winPanel;

#if UNITY_IOS
    private string appId = "4398756";
#else
    private string appId = "4398757";
#endif

    public static int addCnt=1;

    public AdmobController admob;

    void Start(){
        Advertisement.Initialize(appId, false);
    }

    public void pause(){
        Time.timeScale=0;
        setPausePanelActive(true);
    }
    
    public void resume(){
        Time.timeScale=1;
        setPausePanelActive(false);
    }

    public void nextLevel(){
        openScene(Application.loadedLevel+1);
    }

    public void restart(){
        openScene(Application.loadedLevel);
    }

    public void openScene(int id){
        Time.timeScale=1;

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

    private bool alreadShowedAd=false;

    public void setPausePanelActive(bool active){
        pausePanel.SetActive(active);

        if(active){
            if(addCnt%2 == 0){
                if(Advertisement.IsReady("Interstitial_Android") && !alreadShowedAd){
                    Advertisement.Show("Interstitial_Android");
                    alreadShowedAd = true;
                }
            }
            addCnt++;
        }
    }

    public void setDeathPanelActive(bool active){
        deathPanel.SetActive(active);

        if(active){
            if(addCnt%2 == 0){
                if(!admob.showIntersitionalAd()){
                    if(Advertisement.IsReady("Interstitial_Android") && !alreadShowedAd){
                        Advertisement.Show("Interstitial_Android");
                        alreadShowedAd = true;
                    }
                }
            }
            addCnt++;
        }
    }

    public void setWinPanelActive(bool active){
        winPanel.SetActive(active);

        if(active){
            if(addCnt%2 == 0){
                if(Advertisement.IsReady("Interstitial_Android") && !alreadShowedAd){
                    Advertisement.Show("Interstitial_Android");
                    alreadShowedAd = true;
                }
            }
            addCnt++;
        }
    }
}
