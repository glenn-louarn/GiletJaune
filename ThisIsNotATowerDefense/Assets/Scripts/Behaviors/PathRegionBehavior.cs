using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRegionBehavior : MonoBehaviour {

	[SerializeField] private DirectionEnum target_direction;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag != "PathCollider")
			return;

		EnemyBehavior enemy = col.gameObject.GetComponentInParent<EnemyBehavior>();

		if (enemy == null)
			return;
        enemy.arret();
		//enemy.ChangeDirection(target_direction);
	}
}
