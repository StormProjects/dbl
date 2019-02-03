using UnityEngine;
using System.Collections;
public class MessagingClientReceiver : MonoBehaviour {
 
	public string changeSceneName;

	void Start() {
		MessagingManager.Instance.Subscribe(PlayerIsTalkingToCharacter);
	}
	
	void PlayerIsTalkingToCharacter() {
		var dialog = GetComponent<ConversationComponent>(); // get conversationcomponent attached to current character
		if (dialog != null) {
			if (dialog.conversations != null && dialog.conversations.Length > 0) {
				var conversation = getCurrentConversation(dialog);
				if (conversation != null) {
					Debug.Log("about to start conversation");
					ConversationManager.Instance.StartConversation(conversation);
					
					StartCoroutine(WaitToChangeScene());
				}
			}
		}
	}

	private Conversation getCurrentConversation(ConversationComponent dialog) {
		if (dialog.conversationIndex < dialog.conversations.Length - 1) {
			return dialog.conversations[dialog.conversationIndex++];
		} else {
			return dialog.conversations[dialog.conversationIndex];
		}
	}

	IEnumerator WaitToChangeScene()
    {
        Debug.Log("Waiting for conversation to complete");
        yield return new WaitUntil(() => ConversationManager.Instance.getConvoComplete());
        Debug.Log("conversation complete");
		ChangeScene(changeSceneName);
    }

	private void ChangeScene(string sceneName) {
		if (NavigationManager.CanNavigate(sceneName)) {
			Debug.Log("attempting to enter " + sceneName);
			NavigationManager.NavigateTo(sceneName);
 		}
	}

}
