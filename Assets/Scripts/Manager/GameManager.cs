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
    [SerializeField] ScoreboardManager scoreboard;

    //Relationships
    Dictionary<string, int> relationshipVals = new Dictionary<string, int>(){
	{"Deon", 0},
	{"Claire", 0},
	{"Remington", 0}};

    void Start()
    {
        if(!started)
        {
            started = true;
            StartGame();
        }
    }

    void Update()
    {
        if(started){
            scoreBoard.gameObject.SetActive(Input.GetKey(KeyCode.Tab));
            if(Input.GetKey(KeyCode.K))
            {
                addRelVal("Deon");
            }
            if(Input.GetKey(KeyCode.L))
            {
                removeRelVal("Deon");
            }
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
        relationshipVals[name] = 1;

        switch(name) 
        {
        case "Deon":
            scoreboard.updateHearts("Deon",true, relationshipVals[name]);
            break;
        case "Claire":
            scoreboard.updateHearts("Claire",true, relationshipVals[name]);
            break;
        case "Remington":
            scoreboard.updateHearts("Remington",true, relationshipVals[name]);
            break;
        default:
            break;
        }
    }

    public void removeRelVal(string name)
    {
        if(relationshipVals[name] == 0){
            relationshipVals[name] = -1;

            switch(name) 
            {
            case "Deon":
                scoreboard.updateHearts("Deon",false, relationshipVals[name]);
                break;
            case "Claire":
                scoreboard.updateHearts("Claire",false, relationshipVals[name]);
                break;
            case "Remington":
                scoreboard.updateHearts("Remington",false, relationshipVals[name]);
                break;
            default:
                break;
            }
        }
    }

    
}                       
