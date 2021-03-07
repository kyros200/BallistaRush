using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Session ActualSession;

    public float GetDamage()
    {
        return ActualSession.GetDamage();
    }

    private void Start()
    {
        name = "Arrow";
        ActualSession = FindObjectOfType<Session>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
