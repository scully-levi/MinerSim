using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMgr : MonoBehaviour
{
    //Global public variables for Spawning Bubbles

    public GameObject bubblePrefab;
    public GameObject bubbleSpawner;
    public List<GameObject> bubbleList;

    //This is to make a temporary singleton so that we can access using EntityMgr.instance
    public static EntityMgr instance;    
    public void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bubbleList.Count < 1000) SpawnBubbles();
        
    }

    //Entity Manager Spawning Functions

    public void SpawnBubbles()
    {
        GameObject newBubble;
        float x = Random.Range(-70.0f, 70.0f);
        float z = Random.Range(-70.0f, 70.0f);

        float scaleValue = Random.Range(10.0f, 100.0f);

        newBubble = Instantiate(bubblePrefab, bubbleSpawner.transform);
        newBubble.transform.position += (new Vector3( x* 100, 0, z * 100));
        newBubble.transform.localScale = (new Vector3(1,1,1) * scaleValue);
        newBubble.GetComponent<Rigidbody>().AddForce(transform.up * 20 * scaleValue);
        bubbleList.Add(newBubble);
    }

    //EntityMgr functions for entities to use

    public void KillBubble(GameObject bubble)
    {
        if(bubble.transform.position.y > 700)
        {
            bubbleList.RemoveAt(bubbleList.IndexOf(bubble));
            Destroy(bubble);
            //Debug.Log("Kill me");
        }   
    }

}
