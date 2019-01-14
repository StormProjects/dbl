using UnityEngine;

[System.Serializable] // tagged attribute required for custom classes intended to be used in serialization, otherwise Unity will not know

public class ConversationEntry {

	public string speakingCharacterName;

	public string conversationText;

	public Sprite displayPortrait;

	public int displayTime;  // time (seconds) for text to be displayed on screen
	
}