using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float TTL = 3;
    private GameObject bullet;

    private void Awake()
    {
        bullet = this.gameObject;
    }

   
    private void Update()
    {
        if (TTL <= 0) 
        {
           Destroy(bullet);
        }
        TTL = TTL - Time.deltaTime;
    }

    public float DamageDealt(float var)
    {
        return var = 35f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy (bullet);
    }
}
