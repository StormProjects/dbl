using System;
using System.Collections.Generic;
using UnityEngine;


public class MessagingManager : MonoBehaviour {
 
 	public static MessagingManager Instance { get; private set; } // Static singleton property
 	
 	private List<Action> subscribers = new List<Action>(); // public property for manager, list of delegates that need notified

	void Awake() {
		Debug.Log("Messaging Manager Started");
		// First, we check if there are any other instances conflicting
		if (Instance != null && Instance != this) {
			Destroy(gameObject); // Destroy other instances if it's not the same
		}
		
		Instance = this; // Save our current singleton instance
		DontDestroyOnLoad(gameObject); // Make sure that the instance is not destroyed between scenes(this is optional)
	}

	public void Subscribe(Action subscriber) {
		Debug.Log("Subscriber registered");
		subscribers.Add(subscriber);
	}
	
	public void UnSubscribe(Action subscriber) {
		Debug.Log("Subscriber removed");
		subscribers.Remove(subscriber);
	}
	
	public void ClearAllSubscribers() {
		Debug.Log("All subscribers removed");
		subscribers.Clear();
	}

	public void Broadcast() {
		Debug.Log("Broadcast requested, No. of Subscribers = " +
		subscribers.Count);
		foreach (var subscriber in subscribers) {
			subscriber();
		}
	}

}