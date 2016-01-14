using UnityEngine;
using System.Collections;


public class ZombieSpawn : MonoBehaviour {

    int count = 0;
    public Transform spawned_Zom;
    private Transform ground;
    public bool playerEnabled;
    private bool playerExists;
    public GameObject[] zombieCount;

    public string status = "idle";
    

    // Use this for initialization
    void Start () {
        ground = GameObject.Find("Plane").transform;
        transform.parent = ground.transform;
        zombieCount = GameObject.FindGameObjectsWithTag("zombieBro");
        
    }
	
	// Update is called once per frame
	void Update () {

        zombieCount = GameObject.FindGameObjectsWithTag("zombieBro");

        count++;
        if (count == 500)
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            Physics.IgnoreCollision(spawned_Zom.GetComponent<Collider>(), GetComponent<Collider>());
            //Instantiate(attack_orb, transform.position, transform.rotation);

            if (zombieCount.Length < 5)
            {
                PhotonNetwork.Instantiate("ZombieBro_prefab", spawnPosition, transform.rotation, 0);
            }

			



           
            if (playerEnabled == true && GameObject.FindWithTag("playerPrefab") == null)
            {
                PhotonNetwork.Instantiate("playerPrefab", spawnPosition, transform.rotation, 0);
            }

            count = 0;
        }
    }
}
