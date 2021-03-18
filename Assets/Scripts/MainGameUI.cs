using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainGameUI : MonoBehaviour
{
    [Header("Night UI")]
    [SerializeField] TextMeshProUGUI difficulty = null;
    [SerializeField] TextMeshProUGUI enemiesAlive = null;
    [Header("Player UI")]
    [SerializeField] TextMeshProUGUI ammo = null;
    [SerializeField] Slider AmmoCD = null;

    NightSession nightSession;
    PlayerSession playerSession;

    void Awake()
    {
        nightSession = FindObjectOfType<NightSession>();
        playerSession = FindObjectOfType<PlayerSession>();
        if (!nightSession || !playerSession)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void Start()
    {
        AmmoCD.maxValue = playerSession.GetTimeToReload();
    }

    // Update is called once per frame
    void Update()
    {
        //Night UI
        difficulty.text = nightSession.GetActualDifficulty().ToString();
        enemiesAlive.text = "Enemies Alive: " + nightSession.GetEnemiesAlive().ToString();
        //Player UI
        ammo.text = playerSession.GetAmmo().ToString();
        AmmoCD.value = playerSession.GetActualTimeToReload();
    }
}
