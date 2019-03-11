using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderBehavior : MonoBehaviour {

	[SerializeField] private EnemyBehavior enemy;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag != "Projectile")
			return;

		ProjectileBehavior projectile = col.GetComponent<ProjectileBehavior>();
		enemy.Damage(projectile.damage);
		GameObject.Destroy(col.gameObject);

		// TODO: ANIMATE ENEMY? (TAKEN DAMAGE)

		if (enemy.IsDead()) {
			GameObject.FindObjectOfType<Player>().AddGold(enemy.gold);
			GameObject.Destroy(enemy.gameObject);
			// TODO: ANIMATE +X GOLD!
		}
	}
}
