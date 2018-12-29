using UnityEngine;
using System.Collections;
	public class FollowCamera : MonoBehaviour {
	
	public float xOffset = 0f; // Distance between player and camera in horizontal direction
	
	public float yOffset = 0f; // Distance between player and camera in vertical direction
	
	public Transform player; // Reference to the player's transform.
	
	public float minPositionX;
	public float maxPositionX;

	public float minPositionY;
	public float maxPositionY;
	
	
	void LateUpdate() {
		var v3 = this.transform.position;
        v3.x = Mathf.Clamp(player.transform.position.x, minPositionX, maxPositionX);
        v3.y = Mathf.Clamp(player.transform.position.y, minPositionY, maxPositionY);
        transform.position = v3;
	}
}
