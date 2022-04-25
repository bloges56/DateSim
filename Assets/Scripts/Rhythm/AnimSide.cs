using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSide : MonoBehaviour
{
    public float rightBound;
    public float leftBound; 
    public float speed; 
    Vector3 initPos; 

    bool hands; 
    bool snowflake;
    static bool isMoving = true;
    bool movingPos = true;

    // Start is called before the first frame update
    void Start()
    {
        initPos = this.transform.position;
        speed = Random.Range(2.05f,10.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isMoving)
        {
            float currPos = this.transform.position.x;
            float moveToPosRight = currPos + (0.01f*speed);
            float moveToPosLeft = currPos - (0.01f*speed);

            if(movingPos)
            {
                if(moveToPosRight < rightBound){
                    this.transform.position = new Vector3(moveToPosRight, this.transform.position.y, this.transform.position.z);

                }
                else{
                    movingPos = !movingPos;
                }
            }
            else if(!movingPos)
            {
                if(moveToPosLeft > leftBound)
                {
                    this.transform.position = new Vector3(moveToPosLeft, this.transform.position.y, this.transform.position.z);

                }
                else{
                    movingPos = !movingPos;
                }
            }
            else
            {
                  this.transform.position = initPos;
                movingPos = true;
            }
        }
    }

    public static void releaseObj(){
        isMoving = true;
    }
    public bool getReleaseStatus()
    {
        return isMoving;
    }

    public static void stopObj()
    {
        isMoving = false;
    }

}
