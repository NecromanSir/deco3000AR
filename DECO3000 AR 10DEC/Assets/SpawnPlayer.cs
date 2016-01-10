using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {
    public Camera standbyCamera;
    SpawnSpot[] spawnSpots;

	// Use this for initialization
	void Start () {
        spawnSpots = GameObject.FindObjectsOfType<SpawnSpot>();
	}

    void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");

        SpawnMyPlayer();
    }

    void SpawnMyPlayer()
    {
        if (spawnSpots == null)
        {
            Debug.LogError("WTF?!?!?");
            return;
        }

        SpawnSpot mySpawnSpot = spawnSpots[0];
        GameObject myPlayerGO = (GameObject)PhotonNetwork.Instantiate("FPSController", mySpawnSpot.transform.position, mySpawnSpot.transform.rotation, 0);
        standbyCamera.enabled = false;

        ((MonoBehaviour)myPlayerGO.GetComponent("FPSInputController")).enabled = true;
        ((MonoBehaviour)myPlayerGO.GetComponent("MouseLook")).enabled = true;
        myPlayerGO.transform.FindChild("Main Camera").gameObject.SetActive(true);
    }
}
