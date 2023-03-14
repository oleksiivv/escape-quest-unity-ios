using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private float dir=-1f;

    void Start(){
        StartCoroutine(changeDir());
    }

    void Update(){
        transform.Translate(Vector3.up*dir/50f*Time.timeScale);
        transform.Rotate(0,1,0);
    }

    IEnumerator changeDir(){
        while(true){
            yield return new WaitForSeconds(1f);
            dir*=-1;
        }
    }
}
