using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session : MonoBehaviour
{
    [SerializeField] int difficulty = 100;
    [SerializeField] int actualDifficulty = 100;

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

    bool ItsOver()
    {
        if (actualDifficulty <= 0)
        {
            Debug.Log("Acabou!!! Venceu a Wave!!!");
            return (true);
        }
        else
        {
            Debug.Log("Ainda tem mais!!!");
            return (false);
        }
    }

    void Start()
    {
        SetSingleton();
    }
}
