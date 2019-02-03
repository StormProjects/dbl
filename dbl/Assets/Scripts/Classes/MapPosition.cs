using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Awake() {
		var lastPosition = GameState.GetLastScenePosition(SceneManager.GetActiveScene().name);
		if (lastPosition != Vector3.zero) {
			transform.position = lastPosition;
		}
	}

	void OnDestroy() {
		GameState.SetLastScenePosition(SceneManager.GetActiveScene().name, transform.position);
	}

}
