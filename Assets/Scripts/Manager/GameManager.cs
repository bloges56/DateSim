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
    [SerializeField] GameObject redHeart;
    [SerializeField] GameObject blackHeart;

    private float xMovePos = 120.0f;
    private Vector3 clairePosStart = new Vector3(-364.0f, -34.42f, 0.0f);
    private Vector3 deonPosStart = new Vector3(-413.5f,135.7f,0.0f);
    private Vector3 remingtonStart = new Vector3(-155.0f, -210.0f, 0.0f);

    List<GameObject> deonHeart = new List<GameObject>();
    List<GameObject> claireHeart = new List<GameObject>();
    List<GameObject> remHeart = new List<GameObject>();
 

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
            updateHearts("Deon",true);
            break;
        case "Claire":
            claireNameText.text += relationshipVals[name];
            updateHearts("Claire",true);

            break;
        case "Remington":
            remingtonNameText.text += relationshipVals[name];
            updateHearts("Remington",true);
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
            updateHearts("Deon",false);
            break;
        case "Claire":
            claireNameText.text += relationshipVals[name];
            updateHearts("Claire",false);
            break;
        case "Remington":
            remingtonNameText.text += relationshipVals[name];
            updateHearts("Remington",false);
            break;
        default:
            break;
        }
    }

    private void updateHearts(string name, bool updateType)
    {
        int heartVal = relationshipVals[name];
        GameObject objToSpawn;
        if(heartVal>1){
            objToSpawn = redHeart;
        }
        else{
            objToSpawn = blackHeart;
        }

        if(!updateType & heartVal != -1)
        {
            switch(name) 
            {
            case "Deon":
                Destroy(deonHeart[deonHeart.Count-1]);
                deonHeart.RemoveAt(deonHeart.Count-1);
                break;
            case "Claire":
                Destroy(claireHeart[claireHeart.Count-1]);
                claireHeart.RemoveAt(claireHeart.Count-1);
                break;
            case "Remington":
                Destroy(remHeart[remHeart.Count-1]);
                remHeart.RemoveAt(remHeart.Count-1);
                break;
            default:
                break;
            }
        }

        else
        {
            Vector3 newPos;
            GameObject newHeart;
            switch(name) 
            {
            case "Deon":
                newPos = new Vector3(-413.5f + (xMovePos * deonHeart.Count),135.7f,0.0f);
                newHeart = Instantiate(objToSpawn);
                newHeart.transform.position = newPos;
                deonHeart.Add(newHeart);
                break;
            case "Claire":
                newPos = new Vector3(-364.0f + (xMovePos * claireHeart.Count), -34.42f, 0.0f);
                newHeart = Instantiate(objToSpawn);
                newHeart.transform.position = newPos;
                claireHeart.Add(newHeart);
                break;
            case "Remington":
                newPos = new Vector3(-155.0f + (xMovePos * remHeart.Count), -210.0f, 0.0f);
                newHeart = Instantiate(objToSpawn);
                newHeart.transform.position = newPos;
                remHeart.Add(newHeart);
                break;
            default:
                break;
            }
        }
        
    }
}
