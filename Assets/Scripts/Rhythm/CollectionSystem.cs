using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectionSystem : MonoBehaviour
{
    public static float rightBound = 8.3f;
    public static float leftBound = -7.9f;

    public static GameObject currObj;
    RhythmLevelOneManager rhyMan;

    public bool hasCollided = false;

    void Start()
    {
        currObj = this.gameObject;
        currObj.transform.position = new Vector3(Random.Range(leftBound, rightBound), currObj.transform.position.y, currObj.transform.position.z);
        rhyMan = GameObject.Find("RhythmLevelOneManager").GetComponent<RhythmLevelOneManager>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Start animation here
        hasCollided = true;
        checkCollisionResult(other.transform.parent.gameObject);
    }
    public void checkCollisionResult(GameObject objTest)
    {
        if(hasCollided)
        {
            rhyMan.succScore(objTest);
        }
        else
        {
            rhyMan.failedScore(objTest);
        }
    }

}
