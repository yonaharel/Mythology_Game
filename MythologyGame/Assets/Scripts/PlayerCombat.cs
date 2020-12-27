using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    enum SkillType {fireBall, icePick, none}

    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;
    public float attackRange = .5f;
    public int attackDamage = 40;

    public List<GameObject> skills;

    public float attackRate = 2f;
    float nextAttackTime = 0f;
  
    public int maxHealth = 100;
    public int defense = 0; 
    int currentHealth;
    public GameObject currentSkill;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        //Shooting Logic
        animator.SetTrigger("Attack");
        //  GameObject currentSkill;
      
        if(currentSkill)
            Instantiate(currentSkill, attackPoint.position, attackPoint.rotation);
      
        
        //with RayCast 
        //RaycastHit2D hitInfo = Physics2D.Raycast(attackPoint.position, attackPoint.right);
        //if (hitInfo)
        //{
        // //   Debug.Log(hitInfo.transform.name);
        //   Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
        //    if (enemy)
        //    {
        //        enemy.TakeDamage(attackDamage);
        //    }

        //    if (impactEffect)
        //    {
        //        Instantiate(impactEffect, hitInfo.point, Quaternion.identity);
        //    }
            
        //    if (lineRenderer)
        //    {
        //        lineRenderer.SetPosition(0, attackPoint.position);
        //        lineRenderer.SetPosition(1, hitInfo.point);
        //    }

        //} else
        //{
        //    if (lineRenderer)
        //    {
        //        lineRenderer.SetPosition(0, attackPoint.position);
        //        lineRenderer.SetPosition(1, attackPoint.position + attackPoint.right * 100);
        //    }
        //}
    }

    //GameObject GetSkill()
    //{
    //    switch (currSkill)
    //    {
    //        case SkillType.icePick: return IcePickPrefab;
    //        case SkillType.fireBall: return FireBallPrefab;
    //    }
    //    return null;
    //}

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //picked up an ice pick
        if (hitInfo.gameObject.tag == "IcePick" )
        {
            currentSkill = skills[(int)SkillType.icePick];
        }
        if (hitInfo.gameObject.tag == "FireBall")
        {
            currentSkill = skills[(int)SkillType.fireBall];
        }

        Destroy(hitInfo.gameObject);
    }

    void Attack()
    {

        //play Attack animation
        animator.SetTrigger("Attack");
        //Detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
      

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    public void MeleeAttackButtonClicked()
    {
        if (Time.time >= nextAttackTime)
        {      
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    public void SkillAttackButtonClicked()
    {
        Shoot();
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
