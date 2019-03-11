using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSc : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private Transform turret;
    [SerializeField] private float attackSpeed;
    [SerializeField] private bulletSc bullet;
    [SerializeField] private float pv = 100;

    private Collider2D target;
    private float currentTime;
    private  Vector2 towerPosition;
    private const float TURRET_ROTATION_SPEED = 1f;

    // Start is called before the first frame update
    void Start(){
        currentTime = 0;
        towerPosition = new Vector2(transform.position.x, transform.position.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    // Vas prendre le premiére ou le plus pret et vas le focus jusqu'a qu'il sorte de la range
    private bool IsInRange(Transform point)
    {
        return Vector3.Distance(transform.position, point.position) <= range;
    }

    //return true tant que la tour est en vie
    public bool etreAttaque(float attaqueMonstre)
    {
        pv -= attaqueMonstre;
        return pv > 0;
    } 

    //collision d'un GJ
    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyScr enemy = collision.gameObject.GetComponent<EnemyScr>();
        if (enemy == null)
        {
            return;
        }
        // enemy.changeDirection(targetDirection);
        enemy.rencontreCRS(this);
    }

    //Recherche cible
    private void getEnemyInRange()
    {
        //target = Physics2D.OverlapCircle(transform.position, range);
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range);
        //target = enemies == null ? null : enemies.transform;
        //for (int i = 0; i < enemy.Length;i++)
        //    if (enemy[i] != target)
        //    {
        //        if (target != null)
        //        {
        //            target.GetComponent<SpriteRenderer>().color = Color.gray;
        //        }
        //    }
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

        //if (target != null)
        //    target.GetComponent<SpriteRenderer>().color = Color.cyan;
        //else
        //    ResetTurretRotation();
    }

    // private void ResetTurretRotation()
    //{
    //     //rotation doucement Optionnel 
    //     turret.rotation = Quaternion.SlerpUnclamped(turret.rotation, Quaternion.identity, 2f*Time.deltaTime);
    //    // turret.rotation = new Quaternion(0f, 0f, 0f, 0f);
    // }

    private void followTarget()
    {
        Vector3 dir = target.transform.position - transform.position;
        Debug.DrawRay(transform.position, dir, Color.red);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        turret.rotation = Quaternion.Lerp(turret.rotation, Quaternion.AngleAxis(angle, Vector3.forward),0.1f);
    }

    private void fire()
    {
        currentTime = currentTime - attackSpeed;
        bulletSc bulletT = GameObject.Instantiate(bullet);
        bulletT.transform.position = turret.position;
        bullet.Init(target.transform);
        Debug.Log("FIREEE!!!! " + target.transform.position);

    }
    // Update is called once per frame
    void Update()
    {
        //if (pv <=0)
        //{      
        //    GameObject.Destroy(turret.gameObject);
        //    // enemy.changeDirection(targetDirection);
        //    Debug.Log("Tour détruite");
        //}
        //else
        //{

        if(target == null || !IsInRange(target.transform))
            getEnemyInRange();
        
        currentTime += Time.deltaTime;

        Debug.Log("Voici la target " + target);
        if(target != null)
        {
            followTarget();
            if(currentTime >= attackSpeed)
            {
                fire();
            }
        }
        else if(currentTime >= attackSpeed)
        {
            currentTime = 0f;
        }     
    }
}


