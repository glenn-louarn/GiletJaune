using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBehavior : MonoBehaviour {

	// Enemy properties
	private float max_life;
	private float current_life;
	private float speed;
    private int degat;
    private float attack_speed;
    private float current_Time = 0.0f;
    private bool stop;
    private TowerBehavior target;
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
        degat = enemy.degat;
        attack_speed = enemy.attaque_Speed;
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
        else if(target != null)
        {
            current_Time += Time.deltaTime;
            if (current_Time >= attack_speed)
            {
                target.attaque(this.degat);
                current_Time = 0.0f;
                if (target.IsDead())
                {
                    GameObject.Destroy(target.gameObject);
                    target = null;
                    stop = false;
                }
            }

        }
        else
        {
            stop = false;
        }
	}

    public void arret(TowerBehavior targ)
    {
        this.target = targ;
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
	}

	public bool IsDead() {
		return current_life <= 0;
	}

}

//Fin de game
//Equilibre argent degat pv et autre ............
//annonce fin de partie
