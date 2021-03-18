using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] List<Wave> Waves = null;
    [SerializeField] float actualCooldown = 3f;
    [SerializeField] float cooldown = 3f;

    NightSession actualSession = null;

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
        actualSession = FindObjectOfType<NightSession>();
    }

    void Update()
    {
        List<Wave> avaiablesWaves = FilterWaves();

        if(avaiablesWaves.Count > 0)
        {
            actualCooldown -= Time.deltaTime;
            if (actualCooldown <= 0)
            {
                //Get random avaiable Wave to get the enemies from it
                int selectedWave = Random.Range(0, avaiablesWaves.Count);
                List<Enemy> enemies = avaiablesWaves[selectedWave].getEnemies();

                //Update Game Session
                actualSession.AddEnemiesAlive(enemies.Count);
                actualSession.AddActualDifficulty(Waves[selectedWave].getDifficulty() * -1);

                //Spawn enemies
                SpawnEnemies(enemies);

                //Reset Cooldown for next wave
                actualCooldown = cooldown;
            }
        }
    }
}
