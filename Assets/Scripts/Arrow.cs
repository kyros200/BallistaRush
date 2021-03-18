using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
