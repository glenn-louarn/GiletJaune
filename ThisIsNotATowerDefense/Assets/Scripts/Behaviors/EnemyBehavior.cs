using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBehavior : MonoBehaviour {

	// Enemy properties
	private float max_life;
	private float current_life;
	private float speed;
    private bool stop;
	[NonSerialized] public int gold;
	[NonSerialized] public int value;

	[SerializeField] private SpriteRenderer sprite_renderer;
	[SerializeField] private Transform life_bar;

	private Vector3 direction;

	public void Init(Enemy enemy) {
		sprite_renderer.transform.localScale = new Vector3(enemy.size, enemy.size, 0f);
		sprite_renderer.sprite = enemy.sprite;
		sprite_renderer.color = enemy.color;

		max_life = enemy.life;
		current_life = max_life;
		speed = enemy.move_speed;
		gold = enemy.gold;
		value = enemy.value;
        stop = false;
	}

	void Update () {
        if (!stop)
        {
            transform.position = transform.position + direction * speed * Time.deltaTime;
        }
	}

    public void arret()
    {
        stop = true;
    }

	public void ChangeDirection(DirectionEnum dir) {
		switch (dir) {
		case DirectionEnum.UP:
			direction = Vector3.up;
			break;
		case DirectionEnum.DOWN:
			direction = Vector3.down;
			break;
		case DirectionEnum.LEFT:
			direction = Vector3.left;
			break;
		case DirectionEnum.RIGHT:
			direction = Vector3.right;
			break;
		}
	}

	public void Damage(int amount) {
		current_life -= amount;

		float health_ratio = current_life / (float)max_life;
	
		life_bar.localScale = new Vector3(health_ratio, 0.1f, 0f);
		life_bar.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.green, health_ratio);
	}

	public bool IsDead() {
		return current_life <= 0;
	}
}
