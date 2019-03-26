using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnerBehavior : MonoBehaviour {

	[SerializeField] private Text wave_text;
	[SerializeField] private Wave[] waves;
	[SerializeField] private DirectionEnum start_direction;

	private int current_wave;
	private int current_count;
	private float current_interval;
	private bool active;

	void Start() {
		current_wave = 0;
		current_count = 0;
		current_interval = 0f;
		active = true;

		UpdateWaveText();
	}

	private void UpdateWaveText() {
		wave_text.text = "Vague: " + (current_wave + 1);
	}

	private void SpawnEnemy() {
		GameObject obj = GameObject.Instantiate(waves[current_wave].enemy_template.gameObject);
		obj.transform.position = transform.position;
		EnemyBehavior behavior = obj.GetComponent<EnemyBehavior>();
		behavior.Init(waves[current_wave].enemy);
		behavior.ChangeDirection(start_direction);
	}

	void Update () {
		if (active) {
			if (current_count == waves[current_wave].enemy_count)
				active = false;

			current_interval += Time.deltaTime;

			if (current_interval >= waves[current_wave].enemy_interval) {
				SpawnEnemy();
				++current_count;
				current_interval = current_interval - waves[current_wave].enemy_interval;
			}
		} else {
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Targetable");

			if (enemies.Length == 0) {
				active = true;
				current_wave += 1;
				current_count = 0;
				UpdateWaveText();
			}
		}
	}
}
