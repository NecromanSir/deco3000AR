using UnityEngine;
using System.Collections;

public class door_jam : MonoBehaviour
{

    private Transform ground;
    private Transform target;
    private Animation animator;
    private GameObject theDoor;
    private Renderer renderer;
    private Collider collider;
    public string doorState;
    private int count = 0;

    private bool playerPresent = false;
    public bool doorEnabled;

    // Use this for initialization
    void Start()
    {
        //ground = GameObject.Find("Plane").transform;
        theDoor = GameObject.Find("door");
        //transform.parent = ground.transform;
        updateDoorEnabled(true);
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
        doorState = "ready";
        //Physics.IgnoreLayerCollision(8, 9, true);
    }

    // Update is called once per frame
    void Update()
    {



        if (GameObject.FindGameObjectsWithTag("playerPrefab").Length > 0)
        {
            playerPresent = true;
            target = GameObject.FindWithTag("playerPrefab").transform;
        }
        else
        {
            target = GameObject.FindWithTag("CubeZom").transform;
            playerPresent = false;
        }

        if (getDoorEnabled() == false)
        {
            Physics.IgnoreCollision(transform.GetComponent<Collider>(), target.GetComponent<Collider>());
            Physics.IgnoreLayerCollision(8, 9, true);
        }
        else if (getDoorEnabled() == true)
        {
            Physics.IgnoreCollision(transform.GetComponent<Collider>(), target.GetComponent<Collider>(), false);
            Physics.IgnoreLayerCollision(8, 9, false);
        }

        Physics.IgnoreLayerCollision(8, 9, true);

        float distance = Vector3.Distance(transform.position, target.transform.position);
        count++;

        if (doorState == "recharging" && count > 100)
        {
            doorState = "ready";
        }

        if (distance < 1.0f && doorState == "ready")
        {

            renderer.enabled = false;
            updateDoorEnabled(false);
            //collider.enabled = false;
            count = 0;
            doorState = "off";

        }
        else if (doorState == "off")
        {
            count++;

            if (count > 500f)
            {
                doorState = "recharging";
                renderer.enabled = true;
                updateDoorEnabled(true);
                //collider.enabled = true;
                count = 0;
            }


        }
    }

    //void OnCollisionEnter(Collision col)
    //{
    //    if (getDoorEnabled() == false)
    //    {
    //        Debug.Log("False");
    //    } else
    //    {
    //        Debug.Log("True");
    //    }
    //    if (getDoorEnabled() == false)
    //    {
    //        Physics.IgnoreCollision(GetComponent<Collider>(), GetComponent<Collider>());
    //    }

    //}

    public bool getDoorEnabled()
    {
        return doorEnabled;
    }

    public void updateDoorEnabled(bool passBool)
    {
        doorEnabled = passBool;
    }
}
