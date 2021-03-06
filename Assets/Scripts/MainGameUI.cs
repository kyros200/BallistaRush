using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGameUI : MonoBehaviour
{
    [SerializeField] Text difficulty = null;
    [SerializeField] Text enemiesAlive = null;
    Session actualSession;

    // Start is called before the first frame update
    void Start()
    {
        actualSession = FindObjectOfType<Session>();
        if (!actualSession)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    // Update is called once per frame
    void Update()
    {
        difficulty.text = actualSession.GetActualDifficulty().ToString();
        enemiesAlive.text = "Enemies Alive: " + actualSession.GetEnemiesAlive().ToString();
    }
}
