using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupManager : MonoBehaviour
{
    public string SceneToLoad;
    public SceneManagement manager;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadSceneAsync(SceneToLoad,LoadSceneMode.Additive);
    }
}
