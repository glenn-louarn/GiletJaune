using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBarSc : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth = 100;
    public float degatMonstre = 0.5f;
    private float originalScale;


    // Use this for initialization
    void Start()
    {
        originalScale = gameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmpScale = gameObject.transform.localScale;
        if (currentHealth >= 0)
        {
            currentHealth -= degatMonstre;
            tmpScale.x = currentHealth / maxHealth * originalScale;
        }
        gameObject.transform.localScale = tmpScale;
    }
}
