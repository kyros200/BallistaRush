using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainGameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI difficulty = null;
    [SerializeField] TextMeshProUGUI enemiesAlive = null;
    Session actualSession;

    // Start is called before the first frame update
    void Awake()
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
