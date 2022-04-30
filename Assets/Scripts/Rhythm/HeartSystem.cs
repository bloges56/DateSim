using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeartSystem : MonoBehaviour
{
    private float leftBound = -654.5f;
    // private float rightBound = 676.5f;
    private float rightBound = 676.5f;

    private float areaToCover;
    private float distanceBetween;
    
    RhythmLevelOneManager rhythmManager;
    [SerializeField]GameObject heartObject;
    [SerializeField]GameObject heartParent;

    List<GameObject> hearts = new List<GameObject>();
    Vector3 heartLeft = new Vector3(-654.5f,635.91f,0f);
    int heartsToShow;
    // Start is called before the first frame update
    void Start()
    {
        areaToCover = Math.Abs(leftBound - rightBound);
        rhythmManager = this.gameObject.GetComponent<RhythmLevelOneManager>();
        heartsToShow = rhythmManager.errLeft;
        distanceBetween = areaToCover/heartsToShow;

        Vector3 newPos;
        GameObject newHeart;

        //setup all hearts
        for (int i = 0; i < heartsToShow; i++)
        {
            newPos = new Vector3(-654.5f + (i*distanceBetween),635.91f,0f);
            newHeart = Instantiate(heartObject);
            newHeart.transform.position = newPos;
            newHeart.transform.SetParent(heartParent.transform, false);
            hearts.Add(newHeart);
        }

    }

    public void removeLife()
    {
        Destroy(hearts[hearts.Count-1]);
        hearts.RemoveAt(hearts.Count-1);
        heartsToShow--;
        updatePositions();
    }

    public void updatePositions()
    {        
        float newdistanceBetween = areaToCover/heartsToShow;

        foreach (GameObject oldHeart in hearts)
        {
            Destroy(oldHeart);
        }
        hearts.Clear();
        
        for (int i = 0; i < heartsToShow; i++)
        {
            Vector3 newPos = new Vector3(-654.5f + (i*newdistanceBetween),635.91f,0f);
            GameObject newHeart = Instantiate(heartObject);
            newHeart.transform.position = newPos;
            newHeart.transform.SetParent(heartParent.transform, false);
            hearts.Add(newHeart);
        }
    }
}

            // currHeart = hearts[i];
            // // currHeart.transform.position.x += change;
            // Vector3 pos = currHeart.transform.position;
            // // pos = new Vector3(-654.5f + (i*distanceBetween),635.91f,0f);
            // // hearts[i].transform.SetParent(heartParent.transform, true);

            // pos.x += distanceBetween;
            // // pos.x = -654.5f + (i*distanceBetween);
            // hearts[i].transform.position = pos;

        //     float change = newdistanceBetween - distanceBetween;
        // // distanceBetween = newdistanceBetween;
        // GameObject currHeart;
        // // Vector3 pos;

        // for(int i = 1; i<hearts.Count;i++)
        // // foreach (GameObject currHeart in hearts)
        // {
        //     currHeart = hearts[i];
        //     // currHeart.transform.position.x += change;
        //     Vector3 pos = currHeart.transform.position;
        //     currHeart.transform.SetParent(null);

        //     // pos = new Vector3(-654.5f + (i*distanceBetween),635.91f,0f);
        //     // hearts[i].transform.SetParent(heartParent.transform, true);

        //     pos.x += change;
        //     // pos.x = -654.5f + (i*distanceBetween);
        //     hearts[i].transform.position = pos;
        //     currHeart.transform.SetParent(heartParent.transform,false);


        //     //Somewhat working but the items become bigger than what they're supposed to be
        //     // currHeart.transform.SetParent(null);
        //     // pos = new Vector3(-654.5f + (i*newdistanceBetween),635.91f,0f);
        //     // currHeart.transform.position = pos;
        //     // currHeart.transform.SetParent(heartParent.transform,false);


        // }