using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButtonBehavior : MonoBehaviour {

	[SerializeField] private Tower tower;
	[SerializeField] private Transform infos;
	[SerializeField] private TowerBehavior selected_tower;
    [SerializeField] private MatricePlateau mat;

    private Player player;
	private Button button;
	private bool mouse_in;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<Player>();
		button = GetComponent<Button>();
		infos.gameObject.SetActive(false);
		mouse_in = false;

		button.onClick.AddListener(OnClick);
	}

	void OnClick() {
		TowerBehavior t = GameObject.Instantiate(selected_tower);
		t.Init(tower, mat, true);
		player.SetSelectedTower(null);
		player.SetSelectedTower(t);
	}

	void Update() {
		if (mouse_in) {
			infos.transform.position = Input.mousePosition;
		}
	}

	public void OnPointerEnter() {
		mouse_in = true;
		infos.gameObject.SetActive(true);

		GameObject.Find("TowerNameText").GetComponent<Text>().text = tower.tower_name;
		GameObject.Find("CostText").GetComponent<Text>().text = "Cout: " + tower.cost;
		GameObject.Find("DamageText").GetComponent<Text>().text = "Dégât: " + tower.damage;
		GameObject.Find("AttackSpeedText").GetComponent<Text>().text = "Vitesse Attaque: " + tower.attack_speed;
		GameObject.Find("InfoText").GetComponent<Text>().text = "Info: \n" + tower.description;
		// TODO: SET "INFOS" TEXT
	}

	public void OnPointerExit() {
		mouse_in = false;
		infos.gameObject.SetActive(false);
	}
}
