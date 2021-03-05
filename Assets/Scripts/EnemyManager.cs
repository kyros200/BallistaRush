using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] List<Wave> Waves = null;
    [SerializeField] float actualCooldown = 3f;
    [SerializeField] float cooldown = 3f;

    Session actualSession = null;

    List<Wave> FilterWaves()
    {
        List<Wave> tmp = new List<Wave>();
        for(int i = 0; i < Waves.Count; i++)
        {
            if (Waves[i].getDifficulty() < actualSession.GetActualDifficulty())
                tmp.Add(Waves[i]);
        }

        if(tmp.Count == 0)
        {
            actualSession.AddActualDifficulty(actualSession.GetActualDifficulty() * -1);
        }

        return tmp;
    }

    void SpawnEnemies(List<Enemy> enemies)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            Instantiate(
                enemies[i],
                new Vector2(
                    9,
                    Random.Range(-4.5f, 4.5f)),
                    Quaternion.identity
                );
        }
    }

    private void Start()
    {
        actualSession = FindObjectOfType<Session>();
    }

    void Update()
    {
        List<Wave> avaiablesWaves = FilterWaves();

        if(avaiablesWaves.Count > 0)
        {
            actualCooldown -= Time.deltaTime;
            if (actualCooldown <= 0)
            {
                int selectedWave = Random.Range(0, Waves.Count);

                actualSession.AddActualDifficulty(Waves[selectedWave].getDifficulty() * -1);

                List<Enemy> enemies = Waves[selectedWave].getEnemies();

                SpawnEnemies(enemies);
                actualCooldown = cooldown;
            }
        }

    }
}
