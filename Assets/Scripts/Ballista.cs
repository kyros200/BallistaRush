using UnityEngine;
using UnityEngine.UI;

public class Ballista : MonoBehaviour
{
    [Header("Projectile Info")]
    [SerializeField] Vector2 direction;
    [SerializeField] GameObject arrowPrefab = null;
    [Header("Shoot Info")]
    [SerializeField] float attackSpeed = 1.5f;
    [SerializeField] float attackCD= 0f;
    [Header("Ammo Info")]
    [SerializeField] int ammo = 5;
    [SerializeField] Text ammoText = null;
    [Header("Reload Info")]
    [SerializeField] Slider ammoCDUI = null;
    [SerializeField] float ammoCD = 4f;
    [SerializeField] int maxAmmo = 5;
    [SerializeField] float reloadSpeed = 4f;

    private void Start()
    {
        //Prepare ammo text and reload slider
        ammoText.text = ammo.ToString();
        ammoCDUI.maxValue = ammoCD;
        ammoCDUI.value = ammoCDUI.maxValue;
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
            if (attackCD <= 0f && ammo > 0)
            {
                fire();
                ammo -= 1;
                ammoText.text = ammo.ToString();
                attackCD = attackSpeed;
            }
        }
    }

    private void tickTime()
    {
        if (attackCD > 0f)
        {
            attackCD -= Time.deltaTime;
        }
        if (ammo == 0)
        {
            ammoCD -= Time.deltaTime;
            ammoCDUI.value -= Time.deltaTime;
            if (ammoCD <= 0f)
            {
                ammo = maxAmmo;
                ammoText.text = ammo.ToString();
                ammoCD = reloadSpeed;
                ammoCDUI.value = ammoCDUI.maxValue;
            }
        }
    }

    private void fire()
    {
        GameObject arrow = Instantiate(
                        arrowPrefab,
                        transform.position,
                        Quaternion.Euler(0f, 0f, MathHelper.getAngle(direction) + 90f)) as GameObject;
        arrow.GetComponent<Rigidbody2D>().velocity = direction.normalized * 300f * Time.deltaTime;
    }

    void getDirection()
    {
        Vector3 mousePosition = MathHelper.getWorldMousePosition();
        direction = (mousePosition - gameObject.transform.position);
    }
}
