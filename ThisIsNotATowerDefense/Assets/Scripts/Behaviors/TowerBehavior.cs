using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour {

	// Tower properties
	private int damage;
	private float range;
	private float attack_speed;
	private float ready_time;
    private int pv;
    private int maxPv;
    [NonSerialized] public int cost;

	private Projectile projectile;
	private ProjectileBehavior projectile_template;

	private bool placing = false;
	private bool selected = false;

	private BoxCollider2D mouse_collider;
	[SerializeField] private GameObject tower_base;
	[SerializeField] private GameObject tower_turret;
	[SerializeField] private GameObject tower_range;
    [SerializeField] private Transform life_bar;


    private MatricePlateau mat;


    private Collider2D target;
	private float current_time = 0f;

	// CONSTANTS
	private const float TURRET_ROTATION_SPEED = 1f;

	public void Init(Tower tower, MatricePlateau pMat, bool placing = false) {
        this.mat = pMat;
		mouse_collider = GetComponent<BoxCollider2D>();

		SpriteRenderer base_renderer = tower_base.GetComponent<SpriteRenderer>();
		base_renderer.sprite = tower.base_sprite;
		base_renderer.color = tower.base_color;
		SpriteRenderer turret_renderer = tower_turret.GetComponent<SpriteRenderer>();
		turret_renderer.sprite = tower.turret_sprite;
		turret_renderer.color = tower.turret_color;

		damage = tower.damage;
		range = tower.range;
        pv = tower.pv;
        maxPv = pv;
        attack_speed = tower.attack_speed;
		ready_time = tower.ready_time;
		cost = tower.cost;

		projectile = tower.projectile;
		projectile_template = tower.projectile_template;

		this.placing = placing;
		tower_range.transform.localScale = new Vector3(tower.range * 2f, tower.range * 2f, 0f);
		tower_range.SetActive(placing);
        
	}

    private float placement(float coord)
    {
        if (coord < 0)
        {
            return (coord - (coord % 1)) - 0.5f;
        }
        return (coord - (coord % 1))  + 0.5f;
    }

	private bool IsInRange(Transform point) {
		return Vector3.Distance(transform.position, point.position) <= range;
	}

	private void GetEnemyInRange() {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range);
        int i = 0;
        if (enemies.Length < 0)
        {
            target = null;
        }
        else
        {
            while (i < enemies.Length && i != -2)
            {
                if (enemies[i].gameObject.tag != "Targetable")
                {
                    i++;
                }
                else
                {
                    target = enemies[i];
                    i = -2;
                }
            }
        }
       // target = Physics2D.OverlapCircle(transform.position, range);
	}

	private void FollowTarget() {
		Vector3 dir = target.transform.position - transform.position;
		Debug.DrawRay(transform.position, dir, Color.red);
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		tower_turret.transform.rotation = Quaternion.Lerp(
			tower_turret.transform.rotation,
			Quaternion.AngleAxis(angle, Vector3.forward),
			0.1f
		);
	}

	private void Fire() {
		current_time = current_time - attack_speed;
		ProjectileBehavior bullet = GameObject.Instantiate(projectile_template);
		bullet.transform.position = tower_turret.transform.position;
		bullet.Init(projectile, target.transform, damage);
	}
    

	// Update is called once per frame
	void Update () {
        if (!placing)
        {
            if (target == null || !IsInRange(target.transform))
				GetEnemyInRange();

			current_time += Time.deltaTime;

			if (target != null) {
				FollowTarget();
				if (current_time >= attack_speed)
					Fire();
			} else if (current_time >= attack_speed) {
				current_time = attack_speed - ready_time;
			}

			if (Input.GetMouseButtonDown(0)){
				if (!selected && IsMouseIn())
                {
                        selected = true;
                        tower_range.SetActive(true);
                        gameObject.transform.position = new Vector3(placement(gameObject.transform.position.x), placement(gameObject.transform.position.y), 0);
                      //  Debug.Log("je pose la tour a la position " + gameObject.transform.position);                                            
                }
                else if (selected) {
					selected = false;
					tower_range.SetActive(false);
				}
            }
            
        }
    }

    public bool IsDead()
    {
        if (this.pv <= 0)
        {
            destructionTour();
            return true;
        }
        return false;
    }

    private void destructionTour()
    {
        mat.suppresionTour(gameObject.transform.position.y, gameObject.transform.position.x);
    }

    private bool IsMouseIn() {
		Vector3 mouse = GameObject.FindObjectOfType<Camera>().ScreenToWorldPoint(Input.mousePosition);
		return mouse_collider.bounds.Contains(new Vector3(mouse.x, mouse.y, 0f));
	}

    public bool peutEtrePause()
    {
        return mat.ajoutTour(gameObject.transform.position.y, gameObject.transform.position.x);
    }


    public void Place() {
		placing = false;
		selected = false;
		tower_range.SetActive(false);
        }

    public void attaque(int degat)
    {
        this.pv -= degat;

        float health_ratio = pv / (float)maxPv;

        life_bar.localScale = new Vector3(health_ratio, 0.1f, 0f);
        life_bar.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.green, health_ratio);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!placing)
        {
            if (col.gameObject.tag != "PathCollider")
                return;

            EnemyBehavior enemy = col.gameObject.GetComponentInParent<EnemyBehavior>();

            if (enemy == null)
                return;
            enemy.arret(this);
        }
        //enemy.ChangeDirection(target_direction);
    }
}