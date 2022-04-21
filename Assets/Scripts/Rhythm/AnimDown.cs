using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDown : MonoBehaviour
{
    float endPos = -1.5f;
    GameObject objToMove;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        // objToMove = this.Game
        speed = Random.Range(2.05f,10.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(this.transform.position.y > endPos){
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y -  (0.01f*speed), this.transform.position.z);

            // this.transform.position.y -=0.1f;
        }
    }
}
