using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseTowers : MonoBehaviour
{
    
    [SerializeField] Transform rotatingPart;
    [SerializeField] float attackRange = 2f;
    [SerializeField] ParticleSystem projectileParticle;


    [SerializeField] Transform enemy;

    void Update()
    {
        SetTargetEnemy();
      
        if(enemy)
        {
            rotatingPart.LookAt(enemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
        
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if(sceneEnemies.Length == 0) { return; }

        Transform nearestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            nearestEnemy = GetNearest(nearestEnemy, testEnemy.transform);
        }

        enemy = nearestEnemy;
    }

    private Transform GetNearest(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);
        var distToB = Vector3.Distance(transform.position, transformB.position);

        if(distToA < distToB)
        {
            return transformA;
        }

        return transformB;
    }

    private void FireAtEnemy()
    {
        float enemyDistance = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
        if(enemyDistance <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }

    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }

}