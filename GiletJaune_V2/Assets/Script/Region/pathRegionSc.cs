using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathRegionSc : MonoBehaviour
{
    [SerializeField] private DirectionEnum targetDirection;

    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyScr enemy = collision.gameObject.GetComponent<EnemyScr>();
        if(enemy== null)
        {
            return;
        }
        // enemy.changeDirection(targetDirection);
       // enemy.esquiveCRS();
    }
}
