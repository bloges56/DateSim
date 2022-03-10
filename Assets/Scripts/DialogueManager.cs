using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public float waitTime;
    private Queue<string> sentences;
    public string NextScene;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        
    }

    public void StartDialogue(Dialogue dialogue){
        // Debug.Log("Starting Convo with "+dialog.name);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0){
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        // dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    

    public void EndDialogue(){
        // StopAllCoroutines();

        // StartCoroutine(TypeSentence("Goodbye"));
        // yield return new WaitForSeconds(5);
        Debug.Log("End of Convo");
        SceneManager.LoadScene(sceneName: NextScene);
        // Debug.Log("End of Convo");
    }

    IEnumerator TypeSentence(string sentence){
        dialogueText.text = "";
        foreach( char letter in sentence.ToCharArray()){
            dialogueText.text+= letter;
            yield return new WaitForSeconds(waitTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
