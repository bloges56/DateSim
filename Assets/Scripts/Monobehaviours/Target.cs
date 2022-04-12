using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour

{
    float initialSpeed;
    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = Random.Range(7f, 14f);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, initialSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}
