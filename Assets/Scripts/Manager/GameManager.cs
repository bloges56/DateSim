using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public bool started = false;
    public string playerName = " ";

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
        if(Input.GetKeyDown(KeyCode.B)){
        Debug.Log("Name is: "+playerName);
    }

    }

    void StartGame()
    {
        SceneManager.LoadSceneAsync("HomeScreen",LoadSceneMode.Additive);
    }

    public void LoadGame(){
        started = true;
    }

    public void SetName(string inputName)
    {
        playerName = inputName;
    }

    public string GetName()
    {
        return playerName;
    }
}
