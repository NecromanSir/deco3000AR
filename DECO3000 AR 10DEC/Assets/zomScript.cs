using UnityEngine;
using System.Collections;

public class zomScript : MonoBehaviour {

    float speed = 0.03f;
    //float rotationSpeed = 0.9f;
    private float range;
    int count = 0;
    private Transform target;
    private Transform ground;
    //Vector3 gravity;
    public Transform theAnchor;

    // Use this for initialization
    void Start () {
        target = GameObject.Find("playerPrefab").transform;
        ground = GameObject.Find("Plane").transform;
        //transform.LookAt(target.position);
        //gravity = Physics.gravity;
        transform.parent = ground.transform;
    }
   
	// Update is called once per frame
	void Update () {

        target = GameObject.FindWithTag("playerPrefab").transform;

        //transform.Translate(Vector2.up * (speed));
        //Physics.gravity = gravity;

        //gravity = ground.position;
        //gravity.x = 1;
        //gravity.y = 1;
        //gravity.z = 1

        //target = GameObject.Find("CubeZom").transform;

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
