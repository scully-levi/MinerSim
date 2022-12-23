using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moleculeSpawner : MonoBehaviour
{
    public GameObject chalco;
    public GameObject xantate;
    public GameObject h20;
    public GameObject parent;
    public float speed;
    public List<GameObject> moleculeList = new List<GameObject>();
    public int chalcoAmount;
    public int h20Amount;
    public int xanthateAmount;
    public float distanceThreshold;
    void Start()
    {
       initializeMolecules(chalco, xantate, h20, chalcoAmount, h20Amount, xanthateAmount);
    }

    void Update()
    {
        // moveObjects(moleculeList, distanceThreshold);
    }
    void spawnBall(GameObject molecule, List<GameObject> moleculeList) 
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(3, -3), Random.Range(3,-3), Random.Range(3, -3));
        moleculeList.Add(Instantiate(molecule, randomSpawnPosition, Quaternion.identity, parent.transform));
    }

    void pulseObjects(List<GameObject> moleculeList) 
    {
        foreach(var molecule in moleculeList) 
        {
            float nearestDist = float.MaxValue;
            GameObject nearestObj = null;
            GameObject secondNearest = null;

            foreach(var scndMolecule in moleculeList) 
            {
                if(Vector3.Distance(molecule.transform.position, scndMolecule.transform.position) < nearestDist)
                {
                    nearestDist = Vector3.Distance(molecule.transform.position, scndMolecule.transform.position);
                    nearestObj = molecule;
                    secondNearest = scndMolecule;
                }
                if((nearestDist < 1.5) && (nearestObj.tag != secondNearest.tag) && (nearestObj.tag != "attached")) 
                { 
                    var step = speed * Time.deltaTime * .01f;
                    nearestObj.transform.position = Vector3.MoveTowards(nearestObj.transform.position, secondNearest.transform.position, step);
                    secondNearest.transform.position = Vector3.MoveTowards(secondNearest.transform.position, nearestObj.transform.position, step);
                    
                }
            }
        }
    }

    void moveObjects(List<GameObject> moleculeList, float threshold) 
    {
        GameObject[] otherObjects = moleculeList.ToArray();
        for(int i = 0; i < otherObjects.Length; i++) 
        {
            for(int j = i + 1; j < otherObjects.Length; j++) 
            {
                Transform objOne = otherObjects[i].transform;
                Transform objTwo = otherObjects[j].transform;
                Vector3 toOtherObject = objOne.transform.position - objTwo.transform.position;
                
                if ((toOtherObject.sqrMagnitude < threshold) && ((objOne.tag != "attached") && (objTwo.tag != "attached")) && (objOne.tag != objTwo.tag)) 
                {
                    var difference = toOtherObject.sqrMagnitude - threshold;
                    float step;
                    if (difference < 1) 
                    {
                        step = speed * Time.deltaTime * .1f;
                    }
                    else 
                    {
                        step = speed * Time.deltaTime * .01f;
                    }
                    /* if(Vector3.Distance(objOne.transform.position, objTwo.transform.position) < .05)
                    {
                        objOne.tag = "attached";
                        objTwo.tag = "attached";
                    } */

                    // objOne.GetComponent<Rigidbody>().AddForce(toOtherObject * 2, ForceMode.Impulse);
                    // objTwo.GetComponent<Rigidbody>().AddForce(toOtherObject * -2, ForceMode.Impulse);
                    objOne.transform.position = Vector3.MoveTowards(objOne.transform.position, objTwo.transform.position, step);
                    objTwo.transform.position = Vector3.MoveTowards(objTwo.transform.position, objOne.transform.position, step);
                }
            }
        }
    }

    void initializeMolecules(GameObject chalco, GameObject xantate, GameObject h20, int amountOne, int amountTwo, int amountThree) {
        for(int i = 0; i < amountOne; i++) 
        {
            spawnBall(chalco, EntityMgr.instance.calcoList);
        }
        for(int j = 0; j < amountTwo; j++)
        {
            spawnBall(xantate, EntityMgr.instance.xanthateList);
        }
        for(int z = 0; z < amountThree; z++)
        {
            // spawnBall(h20, );
        }
    }
}

