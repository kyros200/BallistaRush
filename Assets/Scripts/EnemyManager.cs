using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyPrefab = null;
    [SerializeField] float actualCooldown = 3f;
    [SerializeField] float cooldown = 3f;

    void Update()
    {
        actualCooldown -= Time.deltaTime;
        if (actualCooldown <= 0)
        {
            Instantiate(
                enemyPrefab[Random.Range(0, enemyPrefab.Count)],
                new Vector2(
                    9, 
                    Random.Range(-4.5f, 4.5f)),
                    Quaternion.identity
                );
            actualCooldown = cooldown;
        }
    }
}
