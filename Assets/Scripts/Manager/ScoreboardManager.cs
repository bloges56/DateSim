using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardManager : MonoBehaviour
{
    [SerializeField] GameObject redHeart;
    [SerializeField] GameObject blackHeart;
    [SerializeField] GameObject heartParent;

    private float xMovePos = 120.0f;
    Vector3 deonPosition = new Vector3(-413.5f,135.7f,0.0f);
    Vector3 clairePosition = new Vector3(-364.0f, -34.42f, 0.0f);
    Vector3 remPosition = new Vector3(-155.0f, -210.0f, 0.0f);


    List<GameObject> deonHeart = new List<GameObject>();
    List<GameObject> claireHeart = new List<GameObject>();
    List<GameObject> remHeart = new List<GameObject>();

    public void updateHearts(string name, bool updateType, int heartVal)
    {
        GameObject objToSpawn;
        addHeart(name,objToSpawn);

        if(heartVal == -1)
        {
            removeHeart(name, blackHeart);
        }
        else if(heartVal == 1)
        {
            addHeart(name, redHeart);
        }
    }

    private void addHeart(string name, GameObject objToSpawn)
    {
        // Vector3 newPos;
        GameObject newHeart;
        switch(name) 
        {
        case "Deon":
            if(deonHeart.Count > 0)
            {
                Destroy(deonHeart[deonHeart.Count-1]);
                deonHeart.RemoveAt(deonHeart.Count-1);
            }
            // newPos = new Vector3(-413.5f + (xMovePos * deonHeart.Count),135.7f,0.0f);
            newHeart = Instantiate(objToSpawn);
            newHeart.transform.position = deonPosition;
            newHeart.transform.SetParent(heartParent.transform, false);
            deonHeart.Add(newHeart);
            break;
        case "Claire":
            if(claireHeart.Count > 0)
            {
                Destroy(claireHeart[claireHeart.Count-1]);
                claireHeart.RemoveAt(claireHeart.Count-1);
            }
            // newPos = new Vector3(-364.0f + (xMovePos * claireHeart.Count), -34.42f, 0.0f);
            newHeart = Instantiate(objToSpawn);
            newHeart.transform.position = clairePosition;
            newHeart.transform.SetParent(heartParent.transform, false);
            claireHeart.Add(newHeart);
            break;
        case "Remington":
            if(remHeart.Count > 0)
            {
                Destroy(remHeart[remHeart.Count-1]);
                remHeart.RemoveAt(remHeart.Count-1);
            }
            // newPos = new Vector3(-155.0f + (xMovePos * remHeart.Count), -210.0f, 0.0f);
            newHeart = Instantiate(objToSpawn);
            newHeart.transform.position = remPosition;
            newHeart.transform.SetParent(heartParent.transform, false);
            remHeart.Add(newHeart);
            break;
        default:
            break;
        }   
    }
    private void removeHeart(string name, GameObject objToSpawn)
    {
        GameObject newHeart;
        switch(name) 
        {
        case "Deon":
            newHeart = Instantiate(objToSpawn);
            newHeart.transform.position = deonPosition;
            newHeart.transform.SetParent(heartParent.transform, false);
            deonHeart.Add(newHeart);
            break;
        case "Claire":
            newHeart = Instantiate(objToSpawn);
            newHeart.transform.position = clairePosition;
            newHeart.transform.SetParent(heartParent.transform, false);
            claireHeart.Add(newHeart);
            break;
        case "Remington":
            newHeart = Instantiate(objToSpawn);
            newHeart.transform.position = remPosition;
            newHeart.transform.SetParent(heartParent.transform, false);
            remHeart.Add(newHeart);
            break;
        default:
            break;
        }   
    }
}
