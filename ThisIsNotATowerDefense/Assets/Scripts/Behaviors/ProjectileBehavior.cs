using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {

	// Projectile properies
	private float speed;

	private Transform target;

	public int damage;

	public void Init(Projectile projectile, Transform target, int damage) {
		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		renderer.color = projectile.color;
		transform.localScale = new Vector3(projectile.size, projectile.size, 1f);

		speed = projectile.speed;

		this.target = target;
		this.damage = damage;
	}
		
	void Update () {
		if (target == null)
			GameObject.Destroy(this.gameObject);
		else {
			transform.position = Vector3.MoveTowards(
				transform.position, target.position, Time.deltaTime * speed
			);
		}
	}
}
