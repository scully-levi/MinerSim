using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    public static SceneMgr instance;
    
    public List<string> sceneList;

    private void Awake()
    {
        if (instance != null)
        {
        Destroy(gameObject);
        return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneList = new List<string>();
        sceneList.Add("MainMenu");
        sceneList.Add("MoleculeWorld");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
