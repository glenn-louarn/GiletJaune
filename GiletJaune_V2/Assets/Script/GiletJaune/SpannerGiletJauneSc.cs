using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpannerGiletJauneSc : MonoBehaviour
{

    [SerializeField] private EnemyScr enemy;
    [SerializeField] private int enemyCount;
    [SerializeField] private float enemyInterval;
    [SerializeField] private DirectionEnum startDirection;

    private int currentCount=0;
    private float currentInterval=0;

    private void spawnEnemy()
    {
        GameObject obj = GameObject.Instantiate(enemy.gameObject);
        obj.transform.position = transform.position;
        obj.GetComponent<EnemyScr>().changeDirection(startDirection);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCount == enemyCount)
        {
            gameObject.SetActive(false);
        }
        ++currentInterval;
        currentInterval += Time.deltaTime;

        if (currentInterval >= enemyInterval)
        {
            spawnEnemy();
            ++currentCount;
            currentInterval = 0;
        }
    }
}
