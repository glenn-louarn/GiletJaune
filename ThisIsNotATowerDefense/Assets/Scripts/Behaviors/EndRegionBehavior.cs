using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRegionBehavior : MonoBehaviour {

	private Player player;

	void Start() {
		player = GameObject.FindObjectOfType<Player>();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag != "PathCollider")
			return;

		EnemyBehavior enemy = col.gameObject.GetComponentInParent<EnemyBehavior>();

		if (enemy == null)
			return;

		player.RemoveLives(enemy.value);
		GameObject.Destroy(col.gameObject);
        Debug.Log("je detruit le gilet jaune");
	}
}
