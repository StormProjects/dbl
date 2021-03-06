﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {

	public GameObject[] EnemySpawnPoints;
	public GameObject[] EnemyPrefabs;
	public AnimationCurve SpawnAnimationCurve;
	public CanvasGroup theButtons;

	private int enemyCount;
	
	enum BattlePhase {
		PlayerAttack,
		EnemyAttack
	}

	private BattlePhase phase;


	// Use this for initialization
	void Start () {
		// Calculate how many enemies
		enemyCount = Random.Range(1, EnemySpawnPoints.Length);
		// Spawn the enemies in
		StartCoroutine(SpawnEnemies());
		// Set the beginning battle phase
		phase = BattlePhase.PlayerAttack;
	}
	
	// Update is called once per frame
	void Update () {
		if (phase == BattlePhase.PlayerAttack) {
			theButtons.alpha = 1;
			theButtons.interactable = true;
			theButtons.blocksRaycasts = true;
		}else {
			theButtons.alpha = 0;
			theButtons.interactable = false;
			theButtons.blocksRaycasts = false;
		}
 	}

 	public void GiveUp() {
 		NavigationManager.NavigateTo("Plains");
	}

	IEnumerator SpawnEnemies() {
		// Spawn enemies in over time
		for (int i = 0; i < enemyCount; i++) {
			var newEnemy = (GameObject)Instantiate(EnemyPrefabs[0]);
			newEnemy.transform.position = new Vector3(10, -1, 0);
			
			yield return StartCoroutine(MoveCharacterToPoint(EnemySpawnPoints[i], newEnemy));
			
			newEnemy.transform.parent = EnemySpawnPoints[i].transform;
		}
	}

	IEnumerator MoveCharacterToPoint(GameObject destination, GameObject character) {
		float timer = 0f;
		var StartPosition = character.transform.position;
		if (SpawnAnimationCurve.length > 0) {
			while (timer < SpawnAnimationCurve.keys[SpawnAnimationCurve.length - 1].time) {
				character.transform.position = Vector3.Lerp(StartPosition,
					destination.transform.position,SpawnAnimationCurve.Evaluate(timer));
				timer += Time.deltaTime;
				yield return new WaitForEndOfFrame();
			}
		} else {
			character.transform.position = destination.transform.position;
		}
	}

}
