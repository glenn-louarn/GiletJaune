using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Wave : ScriptableObject {

	public Enemy enemy;
	public EnemyBehavior enemy_template;
	public int enemy_count;
	public float enemy_interval;

}
