using UnityEngine;
using System.Collections;

public class zomScript : MonoBehaviour {

    float speed = 0.03f;
    //float rotationSpeed = 0.9f;
    private float range;
    int count = 0;
    private Transform target;

    // Use this for initialization
    void Start () {
        target = GameObject.Find("CubeZom").transform;
        //transform.LookAt(target.position);
    }
   
	// Update is called once per frame
	void Update () {

        //transform.Translate(Vector2.up * (speed));


        target = GameObject.Find("CubeZom").transform;

        //range = Vector2.Distance(transform.position, target.position);
        count++;

        transform.LookAt(target.position, transform.up);
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);


    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "sphere")
        {
            Vector3 startPos = new Vector3(0.0f, 0.0185f, 0.7775f);
            transform.position = startPos;
        }

        if (col.gameObject.tag == "CubeZom")
        {
            //Vector3 startPos = new Vector3(0.0f, 0.0185f, 0.7775f);
            //transform.position = startPos;
            PhotonNetwork.Destroy(gameObject);
        }


        //speed = speed * -1;
        //Destroy(col.gameObject);
    }
}
