using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xanthate : MonoBehaviour
{
    public GameObject rod1;
    public GameObject rod2;

    // Start is called before the first frame update
    void Start()
    {
        rod1.SetActive(false);
        rod2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {

        if(other.GetComponent<Collider>().tag == "Cu.1" ||
           other.GetComponent<Collider>().tag == "Cu.3" ||
           other.GetComponent<Collider>().tag == "Cu.9" ||
           other.GetComponent<Collider>().tag == "Cu.12") {

            rod1.SetActive(true);
            rod2.SetActive(true);
        }
    }
}
