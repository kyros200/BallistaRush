using UnityEngine;
using UnityEngine.UI;

public class Ballista : MonoBehaviour
{
    [Header("Projectile Info")]
    [SerializeField] Vector2 direction;
    [SerializeField] GameObject ArrowPrefab = null;
    [Header("Shoot Info")]
    [SerializeField] float AttackSpeed = 1.5f;
    [SerializeField] float AttackCD= 0f;
    [Header("Ammo Info")]
    [SerializeField] int Ammo = 5;
    [SerializeField] Text AmmoText = null;
    [Header("Reload Info")]
    [SerializeField] Slider AmmoCDUI = null;
    [SerializeField] float AmmoCD = 4f;
    [SerializeField] int MaxAmmo = 5;
    [SerializeField] float reloadSpeed = 4f;

    private void Start()
    {
        //Prepare Ammo text and reload slider
        AmmoText.text = Ammo.ToString();
        AmmoCDUI.maxValue = AmmoCD;
        AmmoCDUI.value = AmmoCDUI.maxValue;
    }

    void Update()
    {
        //Update time. Counts shoot and reload CD
        tickTime();
        //Check if the mouse is pressed. 
        if (Input.GetMouseButton(0))
        {
            DebugHelper.drawBallistaToMouseDistance(gameObject.transform.position);
            getDirection();
            if (AttackCD <= 0f && Ammo > 0)
            {
                fire();
                Ammo -= 1;
                AmmoText.text = Ammo.ToString();
                AttackCD = AttackSpeed;
            }
        }
    }

    private void tickTime()
    {
        if (AttackCD > 0f)
        {
            AttackCD -= Time.deltaTime;
        }
        if (Ammo == 0)
        {
            AmmoCD -= Time.deltaTime;
            AmmoCDUI.value -= Time.deltaTime;
            if (AmmoCD <= 0f)
            {
                Ammo = MaxAmmo;
                AmmoText.text = Ammo.ToString();
                AmmoCD = reloadSpeed;
                AmmoCDUI.value = AmmoCDUI.maxValue;
            }
        }
    }

    private void fire()
    {
        GameObject arrow = Instantiate(
            ArrowPrefab,
            transform.position,
            Quaternion.Euler(0f, 0f, MathHelper.getAngle(direction) + 90f)
        ) as GameObject;
        arrow.GetComponent<Rigidbody2D>().velocity = direction.normalized * 300f * Time.deltaTime;
    }

    void getDirection()
    {
        Vector3 mousePosition = MathHelper.getWorldMousePosition();
        direction = (mousePosition - gameObject.transform.position);
    }
}
