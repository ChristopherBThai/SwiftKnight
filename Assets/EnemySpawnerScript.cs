using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {

	public GameObject target;
	public float spawnInterval;
	public Transform[] groundSpawnPoint,flyingSpawnPoint;
	public GameObject[] groundEnemies,flyingEnemies;

	private float timer;


	// Use this for initialization
	void Start () {
		timer = spawnInterval;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0) {
			timer -= Time.deltaTime;
			if (timer <= 0) {
				spawnRandomEnemy ();
				timer = Random.Range (1, spawnInterval);
			}
		}
	}

	void spawnRandomEnemy(){
		if (Random.value > .5) { //Ground
			GameObject enemy = Instantiate(groundEnemies[(int)Random.Range(0,groundEnemies.Length)]);
			enemy.transform.position = (groundSpawnPoint[(int)Random.Range(0,groundSpawnPoint.Length)].transform.position);
			enemy.GetComponent<EnemyMove>().setTarget (target);
		} else { //Flying
			GameObject enemy = Instantiate(flyingEnemies[(int)Random.Range(0,flyingEnemies.Length)]);
			enemy.transform.position = (flyingSpawnPoint[(int)Random.Range(0,flyingSpawnPoint.Length)].transform.position);
			enemy.GetComponent<EnemyMove>().setTarget (target);
		}
	}
}
