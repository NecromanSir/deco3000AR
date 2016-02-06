using UnityEngine;
using System.Collections;

public class door_jam : MonoBehaviour {

    private Transform ground;
    private Transform target;
    private Animation animator;
    private GameObject theDoor;
    private bool playerPresent = false;

    // Use this for initialization
    void Start () {
        ground = GameObject.Find("Plane").transform;
        theDoor = GameObject.Find("door");
        transform.parent = ground.transform;

        animator = GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {

        if (GameObject.FindGameObjectsWithTag("sedanPrefab").Length > 0)
        {
            playerPresent = true;
            target = GameObject.FindWithTag("sedanPrefab").transform;
        }
        else
        {
            target = GameObject.FindWithTag("CubeZom").transform;
            playerPresent = false;
        }

        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance < 1.0f)
        {
          
            theDoor.SetActive(false);
        } else
        {
            
            theDoor.SetActive(true);
    
        }
    }

    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.tag == "playerPrefab")
    //    {
    //        //animator.Play("open");
    //        gameObject.SetActive(false);
    //    }
    //}

    //void OnCollisionExit(Collision col)
    //{
    //    if (col.gameObject.tag == "playerPrefab")
    //    {
    //        //animator.Play("close");
    //        gameObject.SetActive(true);
    //    }
    //}
}
