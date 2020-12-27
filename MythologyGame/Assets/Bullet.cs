using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 10;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        print("we hit " + hitInfo.name);
        if (hitInfo.name == "Hero") return;
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.TakeDamage(damage);
        }
        
        if(impactEffect)    //check if we set an Impact Effect.
            Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);

    }
}
