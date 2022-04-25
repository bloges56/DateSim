using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectionSystem : MonoBehaviour
{
    public static UnityEvent onObjCollide;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // ontrigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Start the animation here. should it be a coroutine? 
        Debug.Log("Collided!");
        Destroy(other.transform.parent.gameObject);
        RhythmLevelOneManager.setDestroy();



    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Started Enter");
        Destroy(other.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("3D collision enter");
        Destroy(other.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered!");
        Destroy(other.gameObject);
    }

    // private void oncoll
}
