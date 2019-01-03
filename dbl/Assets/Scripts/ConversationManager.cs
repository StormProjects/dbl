using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class ConversationManager : Singleton<ConversationManager> {
 
	// To guarantee this will always be a singleton only, don't use the constructor
	protected ConversationManager () {}

	bool talking = false;
	
	ConversationEntry currentConversationLine;
	//the Canvas Group for the dialog box
	public CanvasGroup dialogBoxCanvasGroup;
	public Image imageHolder;
	public Text textHolder;


	public void StartConversation(Conversation conversation) {
		
		dialogBoxCanvasGroup = GameObject.Find("DialogBox").GetComponent<CanvasGroup>();
 		imageHolder = GameObject.Find("SpeakerImage").GetComponent<Image>();
		textHolder = GameObject.Find("DialogText").GetComponent<Text>();
		
		if (!talking) {
			StartCoroutine(DisplayConversation(conversation));
		}
	}

	// Coroutine to loop through conversation data
	IEnumerator DisplayConversation(Conversation conversation) {
		talking = true;
		
		foreach (var conversationLine in conversation.ConversationLines) {
			currentConversationLine = conversationLine;
			textHolder.text = currentConversationLine.ConversationText;
			imageHolder.sprite = currentConversationLine.DisplayPortrait;
			
			yield return new WaitForSeconds(3);
		}

		talking = false;
	}

	void OnGUI() {
		if (talking) {
			dialogBoxCanvasGroup.alpha = 1;
			dialogBoxCanvasGroup.blocksRaycasts = true;
		} 
		else {
			dialogBoxCanvasGroup.alpha = 0;
			dialogBoxCanvasGroup.blocksRaycasts = false;
		}
	}


}
