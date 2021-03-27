using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;
using System;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] List<Wave> Waves = null;
    [SerializeField] float cooldown = 3f;

    List<Wave> avaiableWaves = new List<Wave>();

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
                    UnityEngine.Random.Range(-4.5f, 4.5f)),
                    Quaternion.identity
                );
        }
    }

    private void Start()
    {
        actualSession = FindObjectOfType<NightSession>();

        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                avaiableWaves = FilterWaves();
            });

        this.UpdateAsObservable()
            .Where(_ => avaiableWaves.Count > 0)
            .ThrottleFirst(TimeSpan.FromSeconds(cooldown))
            .Delay(TimeSpan.FromSeconds(cooldown))
            .Subscribe(_ =>
            {
                if (SceneManager.GetActiveScene().name == "MainGame")
                {
                    //Get random avaiable Wave to get the enemies from it
                    int selectedWave = UnityEngine.Random.Range(0, avaiableWaves.Count);
                    List<Enemy> enemies = avaiableWaves[selectedWave].getEnemies();

                    //Update Game Session
                    actualSession.AddEnemiesAlive(enemies.Count);
                    actualSession.AddActualDifficulty(Waves[selectedWave].getDifficulty() * -1);

                    //Spawn enemies
                    SpawnEnemies(enemies);
                }

            });
    }
}
