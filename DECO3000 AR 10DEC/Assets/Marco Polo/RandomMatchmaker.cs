using UnityEngine;
using System.Collections;
using Photon;

public class RandomMatchmaker : PunBehaviour {

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings("0.1");
		// PhotonNetwork.logLevel = PhotonLogLevel.Full;
	}

	void OnGUI(){

		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	public override void OnJoinedLobby() {
		PhotonNetwork.JoinRandomRoom ();
	}
	
	void OnPhotonRandomJoinFailed() {
		Debug.Log ("Can't join random room!");
		PhotonNetwork.CreateRoom (null);
	}
}
