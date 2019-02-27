using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSc : MonoBehaviour
{
    private Transform target;
    // Start is called before the first frame update
   public void Init(Transform target)
    {
        this.target = target;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (target.position - transform.position) * Time.deltaTime;
    }
}
