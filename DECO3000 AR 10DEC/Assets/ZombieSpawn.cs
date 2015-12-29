using UnityEngine;
using System.Collections;

public class ZombieSpawn : MonoBehaviour {

    int count = 0;
    public Transform spawned_Zom;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        count++;
        if (count == 500)
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            Physics.IgnoreCollision(spawned_Zom.GetComponent<Collider>(), GetComponent<Collider>());
            //Instantiate(attack_orb, transform.position, transform.rotation);
            Instantiate(spawned_Zom, spawnPosition, transform.rotation);
            count = 0;
        }
    }
}
