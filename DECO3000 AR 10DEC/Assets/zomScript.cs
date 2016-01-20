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
    public GameObject[] zombieCount;
    private Animator animator;

    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("playerPrefab").transform;
        ground = GameObject.Find("Plane").transform;
        animator = GetComponent<Animator>();
       
        //transform.LookAt(target.position);
        //gravity = Physics.gravity;
        transform.parent = ground.transform;
    }
   
	// Update is called once per frame
	void Update () {

        

        target = GameObject.FindWithTag("playerPrefab").transform;

        float distance = Vector3.Distance(transform.position, target.transform.position);
        var targetPos = target.position;
        targetPos.y = transform.position.y;
       
        float step = speed * Time.deltaTime;


        if (distance < 1.0f)
        {
            transform.LookAt(targetPos, target.up);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
            animator.SetBool("isWalking", true);
        } else
            animator.SetBool("isWalking", false);
        {

            //transform.LookAt(targetPos, target.up);
            //transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        }
        count++;

       

        if (transform.eulerAngles.z != 0 || transform.eulerAngles.x != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.LookAt(targetPos, target.up);
          
            //transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        }

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
