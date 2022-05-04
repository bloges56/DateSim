using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInitialize : MonoBehaviour
{
    void Start()
    {
        SceneManager.SetActiveScene(gameObject.scene);
        
    }
}
