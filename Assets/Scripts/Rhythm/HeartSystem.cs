using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeartSystem : MonoBehaviour
{
    private float leftBound = -654.5f;
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

    }
}
