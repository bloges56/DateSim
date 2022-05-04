using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Managers : MonoBehaviour
{
    public static SceneManagement sceneManager;
    public static GameManager gameManager;
    public static DialogueManager dialogueManager;

    void Awake()
    {
        sceneManager = GameObject.FindWithTag("SceneManager").GetComponent<SceneManagement>();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        dialogueManager = GameObject.FindWithTag("DialogueManager").GetComponent<DialogueManager>();
    }

}
