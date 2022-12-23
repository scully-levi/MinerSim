using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChalcopyriteBehavior : MonoBehaviour
{
    public bool hitTrigger = false;
    public GameObject chalcopyrite;
    public List<GameObject> xanthateList;
    public GameObject GO_Parent;
    public Rigidbody chalcopyrite_rb;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(xanthateList.Count > 0) {
            chalcopyrite.transform.localPosition = new Vector3(0, 0, 0);
            chalcopyrite.transform.localRotation = new Quaternion(0, 0, 0, 0);
            for(int i = 0; i < xanthateList.Count; i++) {
                xanthateList[i].transform.localPosition = findCorrectPosition();
                xanthateList[i].transform.localRotation = findCorrectRotation();
            }            
        }
    }

    public void combineMole(GameObject xanthate, float difference) 
    {
        Debug.Log("trigger");        
        // Compares tag of colliding object with the xanthate tag
        // if(xanthate.GetComponent<Collider>().tag == "xanthate" && ) {
        if(difference < .5) {
            Debug.Log("inside");
            // Disables the collision so no other Xanthates can attach
            // this.GetComponent<CapsuleCollider>().enabled = false;

            /* // Uses variables from chalcopyrite parent script
            parentChalcopyrite parentModel = transform.parent.GetComponent<parentChalcopyrite>();
            GameObject GO_Parent = parentModel.cloneParent; */

            // Sets xanthates and chalcopyrites rigidbody to the current model colliding 
            // Rigidbody xanthate_rb = xanthate.attachedRigidbody;

            // Checks to see if a parent object already was instantiated by counting number of bonds
            if(GO_Parent.activeInHierarchy == false) {
                GO_Parent = Instantiate(GO_Parent, chalcopyrite.transform.position, Quaternion.identity);
                GO_Parent.AddComponent<Rigidbody>();

                chalcopyrite.transform.parent = GO_Parent.transform;
                xanthate.transform.parent = GO_Parent.transform;

                xanthate.transform.localPosition = findCorrectPosition();
                xanthate.transform.localRotation = findCorrectRotation();

                chalcopyrite.transform.localPosition = new Vector3(0, 0, 0);
                chalcopyrite.transform.localRotation = new Quaternion(0, 0, 0, 0);

                chalcopyrite.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                chalcopyrite.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                
                Destroy(chalcopyrite.GetComponent<Rigidbody>());
                Destroy(xanthate.GetComponent<Rigidbody>());
            } 
            else {

                xanthate.transform.parent = GO_Parent.transform;

                xanthate.transform.localPosition = findCorrectPosition();
                xanthate.transform.localRotation = findCorrectRotation();

                Destroy(xanthate.GetComponent<Rigidbody>());
            }
            hitTrigger = true;
            GO_Parent.GetComponent<parentChalcopyrite>().numberBonded++;
            chalcopyrite.transform.localPosition = new Vector3(0, 0, 0);
            chalcopyrite.transform.localRotation = new Quaternion(0, 0, 0, 0);
            if(GO_Parent.GetComponent<parentChalcopyrite>().numberBonded > 3) {
                EntityMgr.instance.calcoList.Remove(chalcopyrite);
            }
            xanthateList.Add(xanthate);
            EntityMgr.instance.xanthateList.Remove(xanthate);
            Destroy(this);           
        }
    }

   public Vector3 findCorrectPosition() 
    {
        if(this.gameObject.tag == "Cu.1") {

            return new Vector3(-9.417f, 1.901f, 0.093f);
        }
        else if(this.gameObject.tag == "Cu.3") {

            return new Vector3(4.17f, 4.9f, 1.679991f);
        }
        else if(this.gameObject.tag == "Cu.9") {

            return new Vector3(-1.7f, 9.529998f, 9.240002f);
        }
        else if(this.gameObject.tag == "Cu.12") {

            return new Vector3(-4.4886f, -4.1972f, 8.826225f);
        }
        else {

            return new Vector3(0,0,0);
        }
    }

    public Quaternion findCorrectRotation() 
    {
        if(this.gameObject.tag == "Cu.1") {

            return Quaternion.Euler(39.805f, -389.419f, 650.952f);
        }
        else if(this.gameObject.tag == "Cu.3") {

            return Quaternion.Euler(37.709f, -202.028f, 644.946f);
        }
        else if(this.gameObject.tag == "Cu.9") {

            return Quaternion.Euler(-9.841f, -220.213f, 933.098f);
        }
        else if(this.gameObject.tag == "Cu.12") {

            return Quaternion.Euler(12.362f, -320.623f, 752.787f);
        }
        else {

            return Quaternion.Euler(0,0,0);
        }
    }
}