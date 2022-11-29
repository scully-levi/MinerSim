using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMgr : MonoBehaviour
{
    public static UserMgr instance;
    
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
}
