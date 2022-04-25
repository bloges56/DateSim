using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectionSystem : MonoBehaviour
{
    public static float rightBound = 8.3f;
    public static float leftBound = -7.9f;

    public static UnityEvent onObjCollide;
    public static GameObject currObj;
    RhythmLevelOneManager rhyMan;

    public bool hasCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        currObj = this.gameObject;
        currObj.transform.position = new Vector3(Random.Range(leftBound, rightBound), currObj.transform.position.y, currObj.transform.position.z);
        rhyMan = GameObject.Find("RhythmLevelOneManager").GetComponent<RhythmLevelOneManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Start animation here
        hasCollided = true;
        checkCollisionResult(other.transform.parent.gameObject);
        rhyMan.setDestroy();
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
