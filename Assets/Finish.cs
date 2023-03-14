using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private Animator anim;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.enabled = false;

        startPos = transform.position;
        transform.position -= new Vector3(0,3,0);
    }

    void Update(){
        transform.position = Vector3.MoveTowards(transform.position, startPos, 0.1f);
    }

    
}
