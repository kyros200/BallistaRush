using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSession : MonoBehaviour
{
    [Header("Shot Info")]
    [SerializeField] float timeToNextShot = 0.5f;
    [Header("Ammo Info")]
    [SerializeField] int ammo = 5;
    [SerializeField] int maxAmmo = 5;
    [Header("Reload Info")]
    [SerializeField] float timeToReload = 2f;
    [SerializeField] float actualTimeToReload = 2f;
    [Header("Damage Info")]
    [SerializeField] float damage = 10f;

    public int GetAmmo()
    {
        return ammo;
    }

    public void SetAmmo(int val)
    {
        ammo = val;
    }

    public void AddAmmo(int val)
    {
        ammo += val;
    }

    public int GetMaxAmmo()
    {
        return maxAmmo;
    }

    public void SetMaxAmmo(int val)
    {
        maxAmmo = val;
    }

    public float GetTimeToNextShot()
    {
        return timeToNextShot;
    }

    public void SetTimeToNextShot(float val)
    {
        timeToNextShot = val;
    }

    public float GetActualTimeToReload()
    {
        return actualTimeToReload;
    }

    public void SetActualTimeToReload(float val)
    {
        actualTimeToReload = val;
    }

    public float GetTimeToReload()
    {
        return timeToReload;
    }

    public float GetDamage()
    {
        return damage;
    }
}
