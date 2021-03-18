using UnityEngine;
using UnityEngine.UI;

public class Ballista : MonoBehaviour
{
    [Header("Projectile Info")]
    Vector2 direction;
    [SerializeField] GameObject ArrowPrefab = null;

    PlayerSession playerSection = null;

    private void Start()
    {
        playerSection = FindObjectOfType<PlayerSession>();
        //Prepare Ammo text and reload slider
        //AmmoText.text = Ammo.ToString();
        //AmmoCDUI.maxValue = AmmoCD;
        //AmmoCDUI.value = AmmoCDUI.maxValue;
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
            if (playerSection.GetAttackCD() <= 0f && playerSection.GetAmmo() > 0)
            {
                fire();
                playerSection.AddAmmo(-1);
                playerSection.SetAttackCD(playerSection.GetAttackSpeed());
            }
        }
    }

    private void tickTime()
    {
        if (playerSection.GetAttackCD() > 0f)
        {
            playerSection.SetAttackCD(playerSection.GetAttackCD() - Time.deltaTime);
        }
        if (playerSection.GetAmmo() == 0)
        {
            playerSection.SetAmmoCD(playerSection.GetAmmoCD() - Time.deltaTime);
            if (playerSection.GetAmmoCD() <= 0f)
            {
                playerSection.SetAmmo(playerSection.GetMaxAmmo());
                playerSection.SetAmmoCD(playerSection.GetReloadSpeed());
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
