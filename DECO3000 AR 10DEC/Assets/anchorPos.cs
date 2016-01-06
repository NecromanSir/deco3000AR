using UnityEngine;
using System.Collections;

public class anchorPos : MonoBehaviour {

    public Transform theAnchor;

    
	// Use this for initialization
	void Start () {
        transform.parent = theAnchor.transform;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = theAnchor.transform.position;
    }
}
