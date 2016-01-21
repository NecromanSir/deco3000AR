using UnityEngine;
using System.Collections;

public class zomScript : MonoBehaviour {

    float speed = 0.03f;
    private float range;
    private Transform target;
    private Transform ground;
    public Transform theAnchor;
    public GameObject[] zombieCount;
    private Animator animator;
    private string zomState;
    private int timeLeft;
    private bool doneSpawn;
    private Vector3 lastTargetPos;

    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("playerPrefab").transform;
        ground = GameObject.Find("Plane").transform;
        animator = GetComponent<Animator>();
        transform.parent = ground.transform;
        zomState = "spawned";
        doneSpawn = false;
        timeLeft = 100;
    }
   
	// Update is called once per frame
	void Update () {
        target = GameObject.FindWithTag("playerPrefab").transform;
        float distance = Vector3.Distance(transform.position, target.transform.position);
        var targetPos = target.position;
        targetPos.y = transform.position.y;
        float step = speed * Time.deltaTime;

        if (doneSpawn == false)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                transform.position += (Vector3.forward * 0.001f);
                animator.SetBool("isWalking", true);
            }  else
            {
                doneSpawn = true;
                zomState = "ready";
                animator.SetBool("isWalking", false);
            }
            //doneSpawn = true;
            //animator.SetBool("isWalking", false);
        }

        if (doneSpawn == true) {
            if (distance < 1.0f)
            {
                zomState = "pursuit";
                transform.LookAt(targetPos, target.up);
                transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
                animator.SetBool("isWalking", true);
            }
            else if (distance >= 1.0f && zomState.Equals("pursuit"))
            {
                zomState = "lost";
                timeLeft = 1000;
                animator.SetBool("isWalking", true);
                lastTargetPos = target.transform.position;
            }
            else if(zomState.Equals("lost")) {
                if (timeLeft > 0)
                {
                    timeLeft--;
                    //transform.LookAt(lastTargetPos);
                    transform.position = Vector3.MoveTowards(transform.position, lastTargetPos, step);
                }
                else
                {
                    zomState = "idle";
                    animator.SetBool("isWalking", false);
                }
            }
                

            if (transform.eulerAngles.z != 0 || transform.eulerAngles.x != 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.LookAt(targetPos, target.up);
            }
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
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
