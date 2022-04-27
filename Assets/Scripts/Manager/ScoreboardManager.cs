using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardManager : MonoBehaviour
{
    [SerializeField] GameObject redHeart;
    [SerializeField] GameObject blackHeart;
    [SerializeField] GameObject heartParent;

    private float xMovePos = 120.0f;

    List<GameObject> deonHeart = new List<GameObject>();
    List<GameObject> claireHeart = new List<GameObject>();
    List<GameObject> remHeart = new List<GameObject>();

    public void updateHearts(string name, bool updateType, int heartVal)
    {
        GameObject objToSpawn;

        if(heartVal>0){
            objToSpawn = redHeart;
        }
        else{
            objToSpawn = blackHeart;
        }

       if(updateType)
       {
           if(heartVal > 0)
           {
               addHeart(name,objToSpawn);
           }
           else
           {
                removeHeart(name);               
           }
       }
       else
       {
           if(heartVal > -1)
           {
               removeHeart(name);
           }
           else
           {
               addHeart(name,objToSpawn);
           }
       }
        
    }

    private void addHeart(string name, GameObject objToSpawn)
    {
        Vector3 newPos;
        GameObject newHeart;
        switch(name) 
        {
        case "Deon":
            newPos = new Vector3(-413.5f + (xMovePos * deonHeart.Count),135.7f,0.0f);
            newHeart = Instantiate(objToSpawn);
            newHeart.transform.position = newPos;
            newHeart.transform.SetParent(heartParent.transform, false);
            deonHeart.Add(newHeart);
            break;
        case "Claire":
            newPos = new Vector3(-364.0f + (xMovePos * claireHeart.Count), -34.42f, 0.0f);
            newHeart = Instantiate(objToSpawn);
            newHeart.transform.position = newPos;
            newHeart.transform.SetParent(heartParent.transform, false);
            claireHeart.Add(newHeart);
            break;
        case "Remington":
            newPos = new Vector3(-155.0f + (xMovePos * remHeart.Count), -210.0f, 0.0f);
            newHeart = Instantiate(objToSpawn);
            newHeart.transform.position = newPos;
            newHeart.transform.SetParent(heartParent.transform, false);
            remHeart.Add(newHeart);
            break;
        default:
            break;
        }   
    }
    private void removeHeart(string name)
    {
        switch(name) 
        {
        case "Deon":
            Destroy(deonHeart[deonHeart.Count-1]);
            deonHeart.RemoveAt(deonHeart.Count-1);
            break;
        case "Claire":
            Destroy(claireHeart[claireHeart.Count-1]);
            claireHeart.RemoveAt(claireHeart.Count-1);
            break;
        case "Remington":
            Destroy(remHeart[remHeart.Count-1]);
            remHeart.RemoveAt(remHeart.Count-1);
            break;
        default:
            break;
        }
    }

}
