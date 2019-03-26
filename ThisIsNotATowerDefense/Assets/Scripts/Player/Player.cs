using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	[SerializeField] private Text gold_text;
	[SerializeField] private Text lives_text;

	[SerializeField] private int starting_gold;
	[SerializeField] private int starting_lives;

	[NonSerialized] public int gold;
	[NonSerialized] public int lives;

	private TowerBehavior selected_tower;

	// Use this for initialization
	void Start () {
		gold = starting_gold;
		lives = starting_lives;

		UpdateGoldText();
		UpdateLivesText();
	}

	private void UpdateGoldText() {
		gold_text.text = "Or: " + gold;
	}

	private void UpdateLivesText() {
		lives_text.text = "Vie: " + lives;
	}

	public void AddGold(int amount) {
		gold += amount;
		UpdateGoldText();
	}

	public void RemoveGold(int amount) {
		AddGold(-amount);
	}

	public void AddLife(int amount) {
		lives += amount;
		UpdateLivesText();
	}

	public void RemoveLives(int amount) {
		AddLife(-amount);
	}

	public void SetSelectedTower(TowerBehavior tower) {
		if (tower == null && selected_tower != null) {
			GameObject.Destroy(selected_tower.gameObject);
		}
		selected_tower = tower;
	}

	void Update() {
		if (selected_tower != null) {
			Vector3 mouse = GameObject.FindObjectOfType<Camera>().ScreenToWorldPoint(Input.mousePosition);
			selected_tower.transform.position = new Vector3(mouse.x, mouse.y, 0f);

			if (Input.GetMouseButtonDown(0)) {
				if (gold >= selected_tower.cost) {
                    if (selected_tower.peutEtrePause())
                    {
                        RemoveGold(selected_tower.cost);
                        selected_tower.Place();
                        selected_tower = null;
                    }
				} else {
					// TODO: DISPLAY "NOT ENOUGH MONEY"
				}
			}
			if (Input.GetMouseButtonDown(1)) {
				GameObject.Destroy(selected_tower.gameObject);
				selected_tower = null;
			}
		}
	}
}
