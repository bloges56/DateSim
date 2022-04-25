using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSide : MonoBehaviour
{
    public static float rightBound = 8.3f;
    public static float leftBound = -7.9f; 
    public float speed; 
    Vector3 initPos; 

    bool hands; 
    bool snowflake;
    public static bool isMoving = true;
    public bool movingPos = true;
    public bool movEnabled = true;

    public static GameObject currObj;
    // Start is called before the first frame update
    void Start()
    {
        initPos = this.transform.position;
        speed = Random.Range(10.0f,20.0f);
        currObj = this.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(movEnabled){
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
