using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Session : MonoBehaviour
{
    [SerializeField] int difficulty = 100;
    [SerializeField] int actualDifficulty = 100;
    [SerializeField] int enemiesAlive = 0;

    [SerializeField] float Damage = 10f;

    void SetSingleton()
    {
        GameObject itExists = GameObject.Find("Session");

        if (FindObjectsOfType<Session>().Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public int GetDifficulty()
    {
        return difficulty;
    }
    public int GetActualDifficulty()
    {
        return actualDifficulty;
    }

    public float GetDamage()
    {
        return Damage;
    }

    public void AddDifficulty(int amount)
    {
        difficulty += amount;
    }

    public void AddActualDifficulty(int amount)
    {
        actualDifficulty += amount;
        ItsOver();
    }

    public void RestartDifficulty()
    {
        actualDifficulty = difficulty;
    }

    void ItsOver()
    {
        if (actualDifficulty <= 0 && enemiesAlive <= 0)
        {
            AddDifficulty(Mathf.FloorToInt(GetDifficulty() * 0.05f));
            RestartDifficulty();
            SceneManager.LoadScene("UpgradeMenu");
        }
    }

    public int GetEnemiesAlive()
    {
        return enemiesAlive;
    }

    public void AddEnemiesAlive(int amount)
    {
        enemiesAlive += amount;
        ItsOver();
    }

    void Start()
    {
        SetSingleton();
    }
}
