using UnityEngine;
public class MessagingClientReceiver : MonoBehaviour {
 
	void Start() {
		MessagingManager.Instance.Subscribe(ThePlayerIsTryingToLeave);
	}
	
	void ThePlayerIsTryingToLeave() {
		Debug.Log("Don't Leave! - " + tag.ToString());
	}
}
