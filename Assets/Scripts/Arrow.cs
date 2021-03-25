using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;

public class Arrow : MonoBehaviour
{
    PlayerSession playerSession;

    public float GetDamage()
    {
        return playerSession.GetDamage();
    }

    private void Start()
    {
        name = "Arrow"; // This is for someday have different kind of arrows
        playerSession = FindObjectOfType<PlayerSession>();

        this.OnTriggerEnter2DAsObservable()
            .Subscribe(x =>
            {
                Destroy(gameObject);
            });
    }
}
