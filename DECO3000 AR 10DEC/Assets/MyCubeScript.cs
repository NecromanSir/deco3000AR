using UnityEngine;
using System.Collections;

public class MyCubeScript : MonoBehaviour {

    public Transform attack_orb;
    
    

    // Use this for initialization
    void Start () {

        
        

    }
    int count = 0;

	// Update is called once per frame
	void Update () {
        count++;
        if (count == 100) {
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.x + 0.1f, transform.position.z);
            Physics.IgnoreCollision(attack_orb.GetComponent<Collider>(), GetComponent<Collider>());
            //Instantiate(attack_orb, transform.position, transform.rotation);
            Instantiate(attack_orb, spawnPosition, transform.rotation);
            count = 0;
        }
        
    }

    public void OnGrab()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    public void OnGrabRelease()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    public void OnPinch() 
    {
        gameObject.GetComponent<Renderer>().material.color = Color.black;
    }

    public void OnTouchHold()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }

    public void OnPointHold()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }
}
