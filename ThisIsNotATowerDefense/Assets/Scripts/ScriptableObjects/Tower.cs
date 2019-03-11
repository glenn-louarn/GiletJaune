using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Tower : ScriptableObject {

	public string tower_name;
	public string description;

	public int damage;
	public float range;
	public float attack_speed;
	public float ready_time;
	public int cost;

	public Sprite base_sprite;
	public Color base_color;

	public bool freezeRotation = false;
	public Sprite turret_sprite;
	public Color turret_color;

	public Projectile projectile;
	public ProjectileBehavior projectile_template;
}