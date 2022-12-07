using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chalcopyrite : MonoBehaviour
{
    public bool hitTrigger = false;
    public GameObject chalcopyrite;
    public Rigidbody chalcopyrite_rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter(Collider xanthate) 
    {
        
        // Compares tag of colliding object with the xanthate tag
        if(xanthate.GetComponent<Collider>().tag == "xanthate") {
            
            // Disables the collision so no other Xanthates can attach
            this.GetComponent<CapsuleCollider>().enabled = false;

            // Uses variables from chalcopyrite parent script
            parentChalcopyrite parentModel = transform.parent.GetComponent<parentChalcopyrite>();
            GameObject GO_Parent = parentModel.cloneParent;

            // Sets xanthates and chalcopyrites rigidbody to the current model colliding 
            Rigidbody xanthate_rb = xanthate.attachedRigidbody;

            // Checks to see if a parent object already was instantiated by counting number of bonds
            if(parentModel.numberBonded == 0) {
                
                chalcopyrite.transform.parent = GO_Parent.transform;
                xanthate.transform.parent = GO_Parent.transform;

                xanthate.transform.localPosition = findCorrectPosition();
                xanthate.transform.localRotation = findCorrectRotation();

                chalcopyrite.transform.localPosition = new Vector3(0, 0, 0);
                chalcopyrite.transform.eulerAngles = new Vector3(0, 0, 0);

                Destroy(chalcopyrite_rb);
                Destroy(xanthate_rb);
            } 
            else {

                xanthate.transform.parent = GO_Parent.transform;

                xanthate.transform.localPosition = findCorrectPosition();
                xanthate.transform.localRotation = findCorrectRotation();

                Destroy(xanthate_rb);
            } 

            hitTrigger = true;
            parentModel.numberBonded++;
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
