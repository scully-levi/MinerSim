using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UiMgr : MonoBehaviour
{
    public static UiMgr instance;
    
    public bool isPaused = false;

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
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public List<GameObject> menus;
    public int lastMenuOpen = -1;
    
    //switches between main menu and settings menu in MainMenu Scene
    public void TransitionBetweenMMSM()
    {
        if (menus[1].activeInHierarchy){
            menus[1].SetActive(false);
            menus[2].SetActive(true);
            lastMenuOpen = 1;
        }
        else
        {
            menus[1].SetActive(true);
            menus[2].SetActive(false);
            lastMenuOpen = 2;
        }

    }
   
    public void OpenCloseMenu(GameObject menu)
    {
        if (menu.activeInHierarchy)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        }
    }

    public void CloseAllMenus()
    {
        foreach(GameObject menu in menus)
        {
            menu.SetActive(false);
        }
    }

}
