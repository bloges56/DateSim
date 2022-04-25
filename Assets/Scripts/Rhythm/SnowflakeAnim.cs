using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowflakeAnim : MonoBehaviour
{
    bool select; 
    string[] rotations = new string[] {"Y","Z"};
    string move;

    void Start()
    {
        move = rotations[Random.Range(0,rotations.Length)];
        
    }

    void FixedUpdate()
    {
        switch(move) 
        {
        case "Y":
            this.gameObject.transform.Rotate(0, 5, 0, Space.Self);
            break;
        case "Z":
            this.gameObject.transform.Rotate(0, 0, 2, Space.Self);
            break;
        default:
            this.gameObject.transform.Rotate(0, 5, 2, Space.Self);
            break;
        }
    }
}
