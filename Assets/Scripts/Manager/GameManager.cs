using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    static public bool started = false;
    public string playerName = " ";

    //Scoreboard stuff
    [SerializeField]Canvas scoreBoard;
    [SerializeField] TextMeshProUGUI playerNameText;
    [SerializeField] TextMeshProUGUI deonNameText;
    [SerializeField] TextMeshProUGUI claireNameText;
    [SerializeField] TextMeshProUGUI remingtonNameText;


    //Relationships
    Dictionary<string, int> relationshipVals = new Dictionary<string, int>(){
	{"Deon", 0},
	{"Claire", 0},
	{"Remington", 0}};


    // Start is called before the first frame update
    void Start()
    {
        if(!started)
        {
            StartGame();
        }
    }


    void ScoreboardSetup(){


    }
    // Update is called once per frame
    void Update()
    {
        if(started){
            scoreBoard.gameObject.SetActive(Input.GetKey(KeyCode.Tab));
           
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
        playerNameText.text = inputName;
    }

    public string GetName()
    {
        return playerName;
    }

    public int getRelVal(string name)
    {
        return relationshipVals[name];
    }

    public void addRelVal(string name)
    {
        relationshipVals[name] +=1;

        switch(name) 
        {
        case "Deon":
            deonNameText.text += relationshipVals[name];
            break;
        case "Claire":
            claireNameText.text += relationshipVals[name];
            break;
        case "Remington":
            remingtonNameText.text += relationshipVals[name];
            break;
        default:
            break;
        }
    }

    public void removeRelVal(string name)
    {
        relationshipVals[name] -=1;

        switch(name) 
        {
        case "Deon":
            deonNameText.text += relationshipVals[name];
            break;
        case "Claire":
            claireNameText.text += relationshipVals[name];
            break;
        case "Remington":
            remingtonNameText.text += relationshipVals[name];
            break;
        default:
            break;
        }
    }
}
