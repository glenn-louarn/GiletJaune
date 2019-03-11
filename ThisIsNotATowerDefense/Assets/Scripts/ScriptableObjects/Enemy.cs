using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Enemy : ScriptableObject {

	public int life;
	public float move_speed;
	public Sprite sprite;
	public float size;
	public Color color;
	public int gold;
	public int value;

}
