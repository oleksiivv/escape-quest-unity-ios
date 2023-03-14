using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public GameObject character;
    public GameObject camera;

    private Vector3 diff;

    void Start(){
        diff = camera.transform.position - character.transform.position;
    }

    void Update(){
        camera.transform.position = Vector3.MoveTowards(camera.transform.position, character.transform.position + diff, 0.2f);
    }

}
