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
			imageHolder.sprite = currentConversationLine.DisplayPortrait;
			
			StartCoroutine(StepThroughConversationText(currentConversationLine.ConversationText));
			
			// TODO: add property to conversation lines to indicate wait time for each conversation line
			yield return new WaitForSeconds(4);
		}

		talking = false;
	}

	// Coroutine to step through conversation text, letter by letter
	IEnumerator StepThroughConversationText(string conversationText) {

		for (int i = 1; i <= conversationText.Length; i++) {
			textHolder.text = conversationText.Substring(0, i);

			// yield return null;
		yield return new WaitForSeconds(0.025f);
		}

	}

	void OnGUI() {
		if (talking) {
			dialogBoxCanvasGroup.alpha = 1;
			dialogBoxCanvasGroup.blocksRaycasts = true;
		} else {
			dialogBoxCanvasGroup.alpha = 0;
			dialogBoxCanvasGroup.blocksRaycasts = false;
		}
	}


}
