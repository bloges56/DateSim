using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

using TMPro;

public class PuzzleLevelOneManager : MonoBehaviour
{
    public int HIGHSCORE = 35;
    string[] VALIDLETTERS = new string[] {"W","A","S","D"};
    // static Random rnd;
    public int currScore = 0;
    public bool completed = false;


    [SerializeField] TextMeshProUGUI rhy_text;
    [SerializeField] TextMeshProUGUI curr_score_text;
    [SerializeField] TextMeshProUGUI high_score_text;

    Image img;

    // Start is called before the first frame update
    void Start()
    {
        rhy_text.text = VALIDLETTERS[Random.Range(0,VALIDLETTERS.Length )];
        img =  GameObject.Find("Panel").GetComponent<Image>();
        img.color = UnityEngine.Color.white;
        curr_score_text.text = currScore.ToString();
        high_score_text.text = HIGHSCORE.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N)){
            rhy_text.text = NewLetter();
            img.color = UnityEngine.Color.white;
        }
        
        // StartCoroutine(PlayGame());
        PlayGame();

        curr_score_text.text = currScore.ToString();
        if(currScore>HIGHSCORE){
            HIGHSCORE=currScore;
        }
        high_score_text.text = HIGHSCORE.ToString();

    }
    void PlayGame()
    {
 
        if(completed){
            rhy_text.text = NewLetter();
            img.color = UnityEngine.Color.white;
            completed = false;

        }

        if(Input.GetKeyDown(KeyCode.W)){
            StartCoroutine(MatchLetter("W"));
            // yield return new WaitUntil(completed==true);

        }
        else if(Input.GetKeyDown(KeyCode.A)){
            StartCoroutine(MatchLetter("A"));
            // yield return new WaitUntil(completed==true);

        }
        else if(Input.GetKeyDown(KeyCode.S)){
            StartCoroutine(MatchLetter("S"));
            // yield return new WaitUntil(completed==true);

        }
        else if(Input.GetKeyDown(KeyCode.D)){
            StartCoroutine(MatchLetter("D"));
            // yield return new WaitUntil(completed==true);

        }

        // yield return new WaitUntil(() => completed == true);
    }


    IEnumerator MatchLetter(string letter)
    {
        if(rhy_text.text == letter){
            img.color = UnityEngine.Color.green;
            // completed = true;
            currScore ++;
            yield return new WaitForSeconds(0.5f);
            completed = true;
        }
        else{
            img.color = UnityEngine.Color.red;
            // completed = true;
            yield return new WaitForSeconds(0.5f);
            completed = true;
        }
        // completed = true;

    }

    private string NewLetter()
    {
        return VALIDLETTERS[Random.Range(0,VALIDLETTERS.Length )];
    }
}
