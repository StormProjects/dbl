using UnityEngine;
using System.Collections;
	public class FollowCamera : MonoBehaviour {
	
	public float xOffset = 0f; // Distance between player and camera in horizontal direction
	
	public float yOffset = 0f; // Distance between player and camera in vertical direction
	
	public Transform player; // Reference to the player's transform.

	void LateUpdate() {
		this.transform.position = new Vector3(player.transform.position.x +
		xOffset, player.transform.position.y + yOffset, -10);
	}
}
