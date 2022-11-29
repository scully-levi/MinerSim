using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMgr : MonoBehaviour
{
    public GameObject rayRight;
    public GameObject rayLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RayCastCheck();
        PauseCheck();
    }



    //Checks if grip is squeezed if so does a Ray Cast
    //for main menu and pause menu
    void RayCastCheck()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu" || UiMgr.instance.isPaused == true)
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) > 0.1)
            {
                rayLeft.SetActive(true);
            }
            else 
            {
                rayLeft.SetActive(false);
            }

            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch) > 0.1)
            {
                rayRight.SetActive(true);
            }
            else 
            {
                rayRight.SetActive(false);
            }
        }
        else
        {
            rayLeft.SetActive(false);
            rayRight.SetActive(false);
        }
    }


    void PauseCheck()
    {
        if (OVRInput.GetUp(OVRInput.Button.Start))
        {
            if (UiMgr.instance.menus[0].activeInHierarchy){
                UiMgr.instance.OpenCloseMenu(UiMgr.instance.menus[0]);
                UiMgr.instance.OpenCloseMenu(UiMgr.instance.menus[UiMgr.instance.lastMenuOpen]);
            }
            else
            {
                UiMgr.instance.CloseAllMenus();
                UiMgr.instance.OpenCloseMenu(UiMgr.instance.menus[0]);
            }
            UiMgr.instance.isPaused = true;
            Debug.Log("Paused");
        }
      
    }

}

