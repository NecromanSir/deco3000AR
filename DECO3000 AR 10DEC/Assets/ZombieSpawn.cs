using UnityEngine;
using System.Collections;


public class ZombieSpawn : MonoBehaviour {

    int count = 0;
    public Transform spawned_Zom;
    private Transform ground;
    public bool playerEnabled;
    private bool playerExists;
    // Use this for initialization
    void Start () {
        ground = GameObject.Find("Plane").transform;
        transform.parent = ground.transform;
        
    }
	
	// Update is called once per frame
	void Update () {

        count++;
        if (count == 500)
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            Physics.IgnoreCollision(spawned_Zom.GetComponent<Collider>(), GetComponent<Collider>());
            //Instantiate(attack_orb, transform.position, transform.rotation);
			PhotonNetwork.Instantiate("ZombieBro_prefab", spawnPosition, transform.rotation,0);

<<<<<<< HEAD
            if (playerEnabled == true && GameObject.FindWithTag("playerPrefab") == null)
=======

           
            if (playerEnabled == true && GameObject.FindWithTag("playerPrefab") == null)

>>>>>>> origin/master
            {
                PhotonNetwork.Instantiate("playerPrefab", spawnPosition, transform.rotation, 0);
            }

            count = 0;
        }
    }
}
