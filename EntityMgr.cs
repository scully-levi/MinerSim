using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMgr : MonoBehaviour
{
    //Global public variables for Spawning Bubbles

    public GameObject bubblePrefab;
    public GameObject bubbleSpawner;
    public List<GameObject> bubbleList;
    public List<GameObject> calcoList;
    public  List<GameObject> xanthateList;
    public List<GameObject> pyrite;
    public List<GameObject> h20;
    public float threshold;
    public float speed;
    //This is to make a temporary singleton so that we can access using EntityMgr.instance
    public static EntityMgr instance;    
    public float difference;
    public void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if(bubbleList.Count < 1000) SpawnBubbles();
        moveObjects(calcoList, xanthateList, threshold);
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
    public float test;
    void moveObjects(List<GameObject> calcoList, List<GameObject> xanthateList, float threshold) 
    {
    
        for(int i = 0; i < calcoList.Count; i++) 
        {
            for(int j = 0; j < xanthateList.Count; j++) 
            {
                GameObject objOne = calcoList[i];
                GameObject objTwo = xanthateList[j];
                Vector3 toOtherObject = objOne.transform.position - objTwo.transform.position;
                // test = toOtherObject;
                test = Vector3.Distance(objOne.transform.position, objTwo.transform.position);                
                if ((Vector3.Distance(objOne.transform.position, objTwo.transform.position) < threshold)) 
                {
                    Debug.Log("Distance");

                    difference = test;
                    float step;
                    step = speed * Time.deltaTime * 5f;
                    // if (difference < 1) 
                    // {
                    //     step = speed * Time.deltaTime * .1f;
                    // }
                    // else 
                    // {
                    //     step = speed * Time.deltaTime * .01f;
                    // }
                    // objOne.transform.position = Vector3.MoveTowards(objOne.transform.position, objTwo.transform.position, step);
                    objTwo.transform.position = Vector3.MoveTowards(objTwo.transform.position, objOne.transform.position, step);
                    // objOne.GetComponent<Rigidbody>().AddForce(Vector3.MoveTowards(objOne.transform.position, objTwo.transform.position, 0.00001f), ForceMode.Impulse);
                    // // test = Vector3.MoveTowards(objOne.transform.position, objTwo.transform.position, 0.01f);
                    // objTwo.GetComponent<Rigidbody>().AddForce(Vector3.MoveTowards(objTwo.transform.position, objOne.transform.position, 0.00001f), ForceMode.Impulse);
                    objOne.GetComponentInChildren<ChalcopyriteBehavior>().combineMole(objTwo, difference);
                    i = calcoList.Count;
                    j = xanthateList.Count;
                }
            }
        }
    }
}
