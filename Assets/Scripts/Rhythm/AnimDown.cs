using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDown : MonoBehaviour
{
    float endPos = -4.0f;
    float speed;
    static bool released = false;
    RhythmLevelOneManager rhyMan;
    
    void Start()
    {
        speed = Random.Range(10f,50f);
        rhyMan = GameObject.Find("RhythmLevelOneManager").GetComponent<RhythmLevelOneManager>();
    }

    void FixedUpdate()
    {   
        if(released){
            if(this.transform.position.y > endPos){
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y -  (0.01f*speed), this.transform.position.z);
            }
            else
            {
                rhyMan.checkScore(this.gameObject);
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
