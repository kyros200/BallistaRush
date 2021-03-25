using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UniRx;

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

        //Night UI
        this.ObserveEveryValueChanged(x => x.nightSession.GetActualDifficulty())
            .Subscribe(x =>
            {
                difficulty.text = nightSession.GetActualDifficulty().ToString();
            });

        this.ObserveEveryValueChanged(x => x.nightSession.GetEnemiesAlive())
            .Subscribe(x =>
            {
                enemiesAlive.text = "Enemies Alive: " + nightSession.GetEnemiesAlive().ToString();
            });

        //Player UI
        AmmoCD.maxValue = playerSession.GetTimeToReload();

        this.ObserveEveryValueChanged(x => x.playerSession.GetAmmo())
            .Subscribe(x =>
            {
                ammo.text = playerSession.GetAmmo().ToString();
            });

        this.ObserveEveryValueChanged(x => x.playerSession.GetActualTimeToReload())
            .Subscribe(x =>
            {
                AmmoCD.value = playerSession.GetActualTimeToReload();
            });
    }
}
