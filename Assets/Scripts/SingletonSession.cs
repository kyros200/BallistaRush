using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonSession : MonoBehaviour
{
    void SetSingleton()
    {
        GameObject itExists = GameObject.Find("Session");

        if (FindObjectsOfType<SingletonSession>().Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        SetSingleton();        
    }
}
