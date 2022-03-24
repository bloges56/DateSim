using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderManager : MonoBehaviour
{

    public ManageScene manager; 
    public GameObject colliderObject;
    public string SceneToLoad;
    public string currentScene;
    

    // Start is called before the first frame update
    void Start()
    {
        // currentScene = SceneManager.GetActiveScene().name;

        // Debug.Log("Current Scene: " + currentScene);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided");
        // manager.LoadUnScene(SceneToLoad,currentScene);
        // ManageScene.LoadUnScene(SceneToLoad,currentScene);
    }
}
