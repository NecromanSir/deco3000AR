using UnityEngine;
using System.Collections;

public class relativeScript : MonoBehaviour {

    private Transform ground;
	// Use this for initialization
	void Start () {
        ground = GameObject.Find("Anchor").transform;
        transform.parent = ground.transform;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
