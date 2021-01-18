﻿using UnityEngine;

public class Shredder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy")
            Destroy(collision.gameObject);
    }
}
