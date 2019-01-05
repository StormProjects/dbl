 using UnityEngine;
 using System.Collections;
 
 
 public class Sorting : MonoBehaviour {
 
 	public Transform player;

	float offset = 0.025f;
 
	void Update () {
		if (transform.position.y >= player.transform.position.y) {
			GetComponent<SpriteRenderer>().sortingOrder = (player.GetComponent<SpriteRenderer>().sortingOrder) - 1;
			
			setBoxColliders(false, true);
		}
		if (transform.position.y < player.transform.position.y + offset) {
			GetComponent<SpriteRenderer>().sortingOrder = (player.GetComponent<SpriteRenderer>().sortingOrder) + 1;

			setBoxColliders(true, false);
		}
	}

	void setBoxColliders(bool bottom, bool top) {
		if (gameObject.tag.Equals("terrain")) {
			GetComponents<BoxCollider2D>()[0].enabled = bottom;
 			GetComponents<BoxCollider2D>()[1].enabled = top;
		}
		else if (gameObject.tag.Equals("npc")) {
			GetComponents<BoxCollider2D>()[1].enabled = bottom;
 			GetComponents<BoxCollider2D>()[2].enabled = top;
		}
	}

 }
