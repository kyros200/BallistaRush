using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session : MonoBehaviour
{
    void Start()
    {
        GameObject itExists = GameObject.Find("Session");

        if (FindObjectsOfType<Session>().Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
