using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowflakeAnim : MonoBehaviour
{
    bool select; 
    // Start is called before the first frame update
    void Start()
    {
        // if(Random.Range(0,1) > 0.5){
        //     select = true;
        // }
        // else
        // {
        //     select = false;
        // }

        select = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(select)
        {
            this.gameObject.transform.Rotate(0, 0, 2, Space.Self);
        }
        else
        {
            this.gameObject.transform.Rotate(0, 5, 0, Space.Self);
        }
    }
}
