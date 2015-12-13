using UnityEngine;
using System.Collections;

public class sphereMovement : MonoBehaviour {

    private Transform mainTarget;
    private Transform target;
    private Transform target1;
    private Transform target2;
    private bool ballDirUp = true;
    float speed = 0.11f;
    int count = 0;
    private float range;

    // Use this for initialization
    void Start () {
        //target = GameObject.Find("CubeZom").transform;
        target = GameObject.Find("ZombieBro").transform;
    }
	
	// Update is called once per frame
	void Update () {
        //target = GameObject.Find("CubeZom").transform;
        target = GameObject.Find("ZombieBro").transform;

        range = Vector2.Distance(transform.position, target.position);
        count++;
        if (range < 1.0f){

            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            //if (ballDirUp == true)
            //{
            //    transform.Translate(Vector2.up * (1 * speed));
            //    count++;
            //    if (count > 3)
            //    {
            //        count = 0;
            //        ballDirUp = false;
            //    }
            //}
            //else
            //{
            //    transform.Translate(Vector2.up * (-1 * speed));
            //    count++;
            //    if (count > 3)
            //    {
            //        count = 0;
            //        ballDirUp = true;
            //    }
        //}

        //count = 0;
        //Vector3 vectorToTarget = target.position - transform.position;
        //float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;
        //Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 0.9f);
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed);
        }


    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.name == "ZombieBro")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
