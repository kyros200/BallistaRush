using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System;

public class Ballista : MonoBehaviour
{
    [SerializeField] GameObject ArrowPrefab = null;
    
    Vector2 direction;

    PlayerSession playerSession = null;

    DateTimeOffset timeToNextShot;

    private void Start()
    {
        playerSession = FindObjectOfType<PlayerSession>();

        this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButton(0))
            .Timestamp()
            .Where(x => x.Timestamp > timeToNextShot.AddSeconds(playerSession.GetTimeToNextShot()) && playerSession.GetAmmo() > 0)
            .Subscribe(x =>
            {
                timeToNextShot = x.Timestamp;
                fire();
            });

        this.UpdateAsObservable()
            .Where(_ => playerSession.GetAmmo() == 0)
            .ThrottleFirst(TimeSpan.FromSeconds(playerSession.GetTimeToReload()))
            .Delay(TimeSpan.FromSeconds(playerSession.GetTimeToReload()))
            .Subscribe(_ =>
            {
                playerSession.SetAmmo(playerSession.GetMaxAmmo());
            });
    }

    private void fire()
    {
        playerSession.AddAmmo(-1);

        getDirection();

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
