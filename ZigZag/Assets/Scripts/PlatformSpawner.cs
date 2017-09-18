﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {


	public GameObject platform;
	public GameObject diamonds;
	public GameObject enemies;
	public GameObject slowDowns;
	public GameObject speedUps;
	Vector3 lastPos;
	float size;
	public bool gameOver;


	// Use this for initialization
	public void Start () {
		lastPos = platform.transform.position;
		size = platform.transform.localScale.x;
		for (int i = 0; i < 20; i++) {
			SpawnPlatforms ();
		}

	}

	public void StartSpawningPlatforms(){
		InvokeRepeating ("SpawnPlatforms", 0.1f, 0.2f);
	}

	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameOver==true) {
			CancelInvoke ("SpawnPlatforms");
		}
	}

	void SpawnPlatforms(){
		
		int rand = Random.Range (0, 6);
		if (rand < 3) {
			SpawnX ();
		} else if (rand >= 3) {
			SpawnZ ();
		}
	}

	void SpawnX(){
		Vector3 pos = lastPos;
		pos.x += size;
		lastPos = pos;
		Instantiate (platform, pos, Quaternion.identity);
		int rand = Random.Range (0, 4);
		if (rand < 1) {
			Instantiate (diamonds, new Vector3 (pos.x, pos.y + 1, pos.z), diamonds.transform.rotation);
		} else {
			int randEnemy = Random.Range (0, 10);
			if (randEnemy < 1) {
				Instantiate (enemies, new Vector3 (pos.x, pos.y + 1, pos.z), enemies.transform.rotation);
			} else {
				int randSlowDown = Random.Range (0, 5);
				if (randSlowDown < 1) {
					Instantiate (slowDowns, new Vector3 (pos.x, pos.y + 1, pos.z), enemies.transform.rotation);
				} else if (randSlowDown < 2) {
					Instantiate (speedUps, new Vector3 (pos.x, pos.y + 1, pos.z), enemies.transform.rotation);
				}
			}
		}
	}

	void SpawnZ(){
		Vector3 pos = lastPos;
		pos.z += size;
		lastPos = pos;
		Instantiate (platform, pos, Quaternion.identity);
		int rand = Random.Range (0, 4);
		if (rand < 1) {
			Instantiate (diamonds, new Vector3(pos.x, pos.y +1, pos.z), diamonds.transform.rotation);
		} 
	}

}