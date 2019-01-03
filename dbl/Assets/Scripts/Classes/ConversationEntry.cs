using UnityEngine;

[System.Serializable] // tagged attribute required for custom classes intended to be used in serialization, otherwise Unity will not know

public class ConversationEntry {

	public string SpeakingCharacterName;
	public string ConversationText;
	public Sprite DisplayPortrait;
	
}