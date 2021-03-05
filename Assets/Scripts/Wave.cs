using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Normal Wave", order = 1)]
public class Wave : ScriptableObject
{
    [SerializeField] int difficulty = 30;
    [SerializeField] List<Enemy> enemies = null;

    public List<Enemy> getEnemies()
    {
        return enemies;
    }

    public int getDifficulty()
    {
        return difficulty;
    }
}
