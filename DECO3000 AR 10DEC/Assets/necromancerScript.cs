using UnityEngine;
using System.Collections;

public class necromancerScript : MonoBehaviour {

    private Transform ground;
    private Transform target;
    private bool playerPresent = false;
    public float speed;

    // Use this for initialization
    void Start () {
        ground = GameObject.Find("Plane").transform;
        transform.parent = ground.transform;
        
    }
	
	// Update is called once per frame
	void Update () {


        

        if (GameObject.FindGameObjectsWithTag("playerPrefab").Length > 0) {
            playerPresent = true;
            target = GameObject.FindWithTag("playerPrefab").transform;
        } else
        {
            target = GameObject.FindWithTag("CubeZom").transform;
            playerPresent = false;
        }

        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance < 1)
        {
            speed = 0.02f;
        } else
        {
            speed = 0.6f;
        }
        float step = speed * Time.deltaTime;
        var targetPos = target.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos, target.up);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

        //if (transform.eulerAngles.z != 0 || transform.eulerAngles.x != 0)
        //{
        //    transform.rotation = Quaternion.Euler(0, 0, 0);
        //    transform.LookAt(targetPos, target.up);
        //}
    }
}
