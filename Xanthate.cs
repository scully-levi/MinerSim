using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xanthate : MonoBehaviour
{
    public GameObject rod1;
    public GameObject rod2;
    public GameObject parent;

    // Update is called once per frame
    void Update()
    {
        if(this.transform.parent != null) {
            activateRods();
        }
    }

    public void activateRods() {
        rod1.SetActive(true);
        rod2.SetActive(true);
    }
}