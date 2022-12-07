using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentChalcopyrite : MonoBehaviour
{

    public int numberBonded = 0;
    public GameObject cloneParent;

    // Start is called before the first frame update
    void Start()
    {
        
        cloneParent = Instantiate(cloneParent, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
