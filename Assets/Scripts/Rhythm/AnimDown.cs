using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDown : MonoBehaviour
{
    float endPos = -1.5f;
    float speed;
    static bool released = false;
    GameObject colliderObj;
    // Start is called before the first frame update
    void Start()
    {
        // objToMove = this.Game
        // speed = Random.Range(10.05f,25.0f);
        speed = 35.0f;
        colliderObj = GameObject.Find("colliderObj");

    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(released){
            if(this.transform.position.y > endPos){
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y -  (0.01f*speed), this.transform.position.z);

                // this.transform.position.y -=0.1f;
            }
        }
    }


    public static void releaseObj(){
        released = true;
    }
    public bool getReleaseStatus()
    {
        return released;
    }

    public static void stopObj()
    {
        released = false;
    }
}
