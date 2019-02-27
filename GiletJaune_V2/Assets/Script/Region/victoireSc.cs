using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victoireSc : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyScr>() == null)
        {
            return;
        }
        //enelever une vie
        GameObject.Destroy(collision.gameObject);
        // enemy.changeDirection(targetDirection);
        Debug.Log("Les gilets jaune on gagné");
    }
}
