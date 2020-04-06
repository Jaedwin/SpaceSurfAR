/*
Script for Line
Credit to Shivang Chopra.
https://heartbeat.fritz.ai/the-subtle-art-of-making-lines-in-augmented-reality-using-arcore-and-unity3d-e26718dffa03
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScript : MonoBehaviour {

	public GameObject lineObject, railLeft, railRight;
	public GameObject playerObject;
	Rigidbody rigidBody;

	public GameObject Player;
	public GameObject camera;
	public List<GameObject> Points = new List<GameObject>();
	public bool buttonPressed = false;
	public bool playPressed = false;

	public bool clearPressed = false;

	bool playerVisible = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if(buttonPressed) {
			Debug.Log("Touched");
			Vector3 camPos = camera.transform.position;
 			Vector3 camDirection = camera.transform.forward;
 			Quaternion camRotation = camera.transform.rotation;
 			float spawnDistance = 0.5f;
			Debug.Log("Touched"+camPos.x+" "+camPos.y+" "+camPos.z);

 			Vector3 spawnPos = camPos + (camDirection * spawnDistance);
			spawnPos.z = .5f; 

			GameObject cur = Instantiate(lineObject, spawnPos,  camRotation);

			if(!playerVisible){
				playerVisible = true;
				Vector3 playerPos = spawnPos;
				playerPos.y = spawnPos.y + 0.1f;
				playerPos.x = spawnPos.x + 0.1f;
				playerPos.z = .5f; 
				Instantiate(playerObject, playerPos, camRotation);
			}

			cur.transform.SetParent(this.transform);
		}

		if(playPressed) {
			if(playerVisible){
				Player = GameObject.FindGameObjectsWithTag("player")[0];
				rigidBody = Player.GetComponent<Rigidbody>();
				rigidBody.constraints &= ~RigidbodyConstraints.FreezePositionY;
				rigidBody.constraints &= ~RigidbodyConstraints.FreezePositionX;
			}
		}

		if(clearPressed) {
			GameObject[] spheres = GameObject.FindGameObjectsWithTag("sphere");
			int count = spheres.Length;

			foreach (var sphere in spheres){
				Destroy(sphere);
			}

			if(playerVisible){
				playerVisible = false;
				Player = GameObject.FindGameObjectsWithTag("player")[0];
				Destroy(Player);
			}

			Vector3 camPos = camera.transform.position;
 			Vector3 camDirection = camera.transform.forward;
 			Quaternion camRotation = camera.transform.rotation;
 			float spawnDistance = 0.5f;
			Debug.Log("Touched"+camPos.x+" "+camPos.y+" "+camPos.z);
 			Vector3 spawnPos = camPos + (camDirection * spawnDistance);
			GameObject cur = Instantiate(lineObject, spawnPos,  camRotation);
			cur.transform.SetParent(this.transform);
		}
	}
}