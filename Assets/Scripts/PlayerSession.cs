using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSession : MonoBehaviour
{
    [Header("Shoot Info")]
    [SerializeField] float AttackSpeed = 0.5f;
    [SerializeField] float AttackCD = 0f;
    [Header("Ammo Info")]
    [SerializeField] int Ammo = 5;
    [Header("Reload Info")]
    [SerializeField] float AmmoCD = 2f;
    [SerializeField] int MaxAmmo = 5;
    [SerializeField] float reloadSpeed = 2f;

    public int GetAmmo()
    {
        return Ammo;
    }

    public void SetAmmo(int val)
    {
        Ammo = val;
    }

    public int GetMaxAmmo()
    {
        return MaxAmmo;
    }

    public void SetMaxAmmo(int val)
    {
        MaxAmmo = val;
    }

    public void AddAmmo(int val)
    {
        Ammo += val;
    }

    public float GetAttackSpeed()
    {
        return AttackSpeed;
    }

    public void SetAttackSpeed(float val)
    {
        AttackSpeed = val;
    }

    public float GetAttackCD()
    {
        return AttackCD;
    }

    public void SetAttackCD(float val)
    {
        AttackCD = val;
    }

    public float GetAmmoCD()
    {
        return AmmoCD;
    }

    public void SetAmmoCD(float val)
    {
        AmmoCD = val;
    }

    public float GetReloadSpeed()
    {
        return reloadSpeed;
    }
}
