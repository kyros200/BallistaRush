using UnityEngine;
using UnityEngine.UI;

public class Ballista : MonoBehaviour
{
    [SerializeField] GameObject ArrowPrefab = null;
    
    Vector2 direction;

    PlayerSession playerSession = null;

    private void Start()
    {
        playerSession = FindObjectOfType<PlayerSession>();
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
            if (playerSession.GetActualTimeToNextShot() <= 0f && playerSession.GetAmmo() > 0)
            {
                fire();
                playerSession.AddAmmo(-1);
                playerSession.SetActualTimeToNextShot(playerSession.GetTimeToNextShot());
            }
        }
    }

    private void tickTime()
    {
        if (playerSession.GetActualTimeToNextShot() > 0f)
        {
            playerSession.SetActualTimeToNextShot(playerSession.GetActualTimeToNextShot() - Time.deltaTime);
        }
        if (playerSession.GetAmmo() == 0)
        {
            playerSession.SetActualTimeToReload(playerSession.GetActualTimeToReload() - Time.deltaTime);
            if (playerSession.GetActualTimeToReload() <= 0f)
            {
                playerSession.SetAmmo(playerSession.GetMaxAmmo());
                playerSession.SetActualTimeToReload(playerSession.GetTimeToReload());
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
