using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDown : MonoBehaviour
{
    float endPos = -4.0f;
    float speed;
    static bool released = false;
    RhythmLevelOneManager rhyMan;

    CollectionSystem collectionSyst;
    GameObject colObj;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 55.0f;

        rhyMan = GameObject.Find("RhythmLevelOneManager").GetComponent<RhythmLevelOneManager>();


        // colObj = GameObject.Find("Collection");
        // collectionSyst = colObj.GetComponent<CollectionSystem>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(released){
            if(this.transform.position.y > endPos){
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y -  (0.01f*speed), this.transform.position.z);
            }
            else
            {
                rhyMan.checkScore(this.gameObject);
                // collectionSyst.checkCollisionResult(this.gameObject);
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
