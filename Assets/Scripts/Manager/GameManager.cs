using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        if(!started)
        {
            StartGame();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        SceneManager.LoadSceneAsync("HomeScreen",LoadSceneMode.Additive);
    }

    public void LoadGame(){
        started = true;
    }
}
