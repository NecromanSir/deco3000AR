using UnityEngine;
using System.Collections;

public class door_jam : MonoBehaviour {

    private Transform ground;
    private Transform target;
    private Animation animator;
    private bool playerPresent = false;

    // Use this for initialization
    void Start () {
        ground = GameObject.Find("Plane").transform;
        transform.parent = ground.transform;

        animator = GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {

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

        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance < 1.0f)
        {
            //animator.Play("open");
            //animator.SetBool("keyNear", true);
        } else
        {
            animator.Play("close");
            //animator.SetBool("keyNear", false);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "playerPrefab")
        {
            animator.Play("open");
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "playerPrefab")
        {
            animator.Play("close");
        }
    }
}
