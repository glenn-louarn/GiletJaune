using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSc : MonoBehaviour
{
    public Transform target;
    private float speed = 7f;
    // Start is called before the first frame update
   public void Init(Transform ptarget)
    {
        this.target = ptarget;
        Debug.Log("je suis init " + target.position);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("target position " + target.position);
        transform.position = transform.position + (target.position - transform.position) * Time.deltaTime* speed;
    }

   
}
