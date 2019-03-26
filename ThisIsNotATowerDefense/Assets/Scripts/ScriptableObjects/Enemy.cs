using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Enemy : ScriptableObject {

	public int life;
    public int degat;
    public float attaque_Speed;
	public float move_speed;
	public Sprite sprite;
	public float size;
	public Color color;
	public int gold;
	public int value;

}
