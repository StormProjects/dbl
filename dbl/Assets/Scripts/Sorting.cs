 using UnityEngine;
 using System.Collections;
 
 
 public class Sorting : MonoBehaviour {
 
 public Transform player;
 
	void Update () {
		if (transform.position.y >= player.transform.position.y) {
			Debug.Log(this.name + " behind player");
			GetComponent<SpriteRenderer>().sortingOrder = (player.GetComponent<SpriteRenderer>().sortingOrder) - 1;
			
			setBoxColliders(false, true);
		}
		if (transform.position.y < player.transform.position.y) {
			Debug.Log( this.name + " in front of player");
			GetComponent<SpriteRenderer>().sortingOrder = (player.GetComponent<SpriteRenderer>().sortingOrder) + 1;

			setBoxColliders(true, false);
		}
	}

	void setBoxColliders(bool bottom, bool top) {
		if (gameObject.tag.Equals("terrain")) {
			Debug.Log("this is a terrain tagged object!");
			GetComponents<BoxCollider2D>()[0].enabled = bottom;
 			GetComponents<BoxCollider2D>()[1].enabled = top;
		}
		else {
			GetComponents<BoxCollider2D>()[1].enabled = bottom;
 			GetComponents<BoxCollider2D>()[2].enabled = top;
		}
	}

 }
