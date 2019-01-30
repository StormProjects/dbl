using UnityEngine;
public class MessagingClientReceiver : MonoBehaviour {
 
	void Start() {
		MessagingManager.Instance.Subscribe(ThePlayerIsTryingToLeave);
	}
	
	void ThePlayerIsTryingToLeave() {
		var dialog = GetComponent<ConversationComponent>();
		if (dialog != null) {
			if (dialog.conversations != null && dialog.conversations.Length > 0) {
				var conversation = getCurrentConversation(dialog);
				if (conversation != null) {
					Debug.Log("about to start conversation");
					ConversationManager.Instance.StartConversation(conversation);
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

}
