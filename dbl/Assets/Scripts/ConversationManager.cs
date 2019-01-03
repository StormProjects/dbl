using System.Collections;
using UnityEngine;


public class ConversationManager : Singleton<ConversationManager> {
 
	// To guarantee this will always be a singleton only, don't use the constructor
	protected ConversationManager () {}

	public void StartConversation(Conversation conversation) {
		ConversationManager.Instance.StartConversation(conversation);
	}

}
