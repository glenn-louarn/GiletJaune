using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : MonoBehaviour
{
    //afficher le champs dans l'editeur
    [SerializeField] private float speed;
    [SerializeField] private float degatGJ;
    [SerializeField] private int pv;
    private Vector3 direction;
    private bool stop=false;
    private TowerSc gameObjectCRS;
    private int tempo=0;   

    // Update is called once per frame
    void Update()
    {
        if (stop)
        {
            taperCRS();
        }
        else
        {
            direction = Vector3.right;
            transform.position = transform.position + direction * speed;
        }
    }

    private void taperCRS()
    {
        
            if (tempo <= 0)
            {
                tempo = 200;
                if (gameObjectCRS != null)
                {
                    bool tourEnVie = gameObjectCRS.etreAttaque(degatGJ);
                    if (!tourEnVie)
                    {
                        GameObject.Destroy(gameObjectCRS.gameObject);
                        stop = false;
                    }
                }
                else
                {
                    stop = false;
                }

            }
            else
            {
                tempo--;
            }
        
    }

    public void changeDirection(DirectionEnum dir)
    {
        switch (dir)
        {
            case DirectionEnum.UP:
                direction = Vector3.up;
                break;
            case DirectionEnum.DOWN:
                direction = Vector3.down;
                break;
            case DirectionEnum.RIGHT:
                direction = Vector3.right;
                break;
            case DirectionEnum.LEFT:
                direction = Vector3.left;
                break;
        }
    }

    public void rencontreCRS(TowerSc PgameObjectCRS)
    {
        this.gameObjectCRS = PgameObjectCRS;
        Debug.Log("Colision");
        stop = true;
    }

    public bool estMort(int degat)
    {
        pv -= degat;
        return pv <= 0;
    }
}
