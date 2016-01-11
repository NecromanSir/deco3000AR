using UnityEngine;
using System.Collections;

public class shed4 : MonoBehaviour {
	private Transform ground;
	// Use this for initialization
	void Start () {
		ground = GameObject.Find("Plane").transform;
		transform.parent = ground.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
