using UnityEngine;
using System.Collections;

public class targetCubeScript : MonoBehaviour {

    private Transform ground;
    

    int count = 0;

    // Use this for initialization
    void Start () {
        ground = GameObject.Find("Plane").transform;
        transform.parent = ground.transform;
    }
	
	// Update is called once per frame
	void Update () {
        count++;
        transform.parent = ground.transform;
        //if (count == 15)
        //{
        //    Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        //    PhotonNetwork.Instantiate("playerPrefab", spawnPosition, transform.rotation, 0);
        //}
    }
}
