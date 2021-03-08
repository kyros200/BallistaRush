using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] string Name = "Enemy";
    [SerializeField] float Health = 20f;
    float ActualHealth;
    [SerializeField] float Velocity = 50f;
    [SerializeField] float Damage = 10f;
    [SerializeField] TextMeshProUGUI HealthText = null;

    Session ActualSession;

    void Die()
    {
        ActualSession.AddEnemiesAlive(-1);
        Destroy(gameObject);
    }

    void AddHealth(float amount)
    {
        Health += amount;
    }

    private void Start()
    {
        name = Name;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Velocity*-1, 0) * Time.deltaTime;
        ActualSession = FindObjectOfType<Session>();
        ActualHealth = Health;
    }

    private void Update()
    {
        HealthText.text = Health.ToString("F0");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Arrow arrow = collision.gameObject.GetComponent<Arrow>();
        if (arrow)
        {
            AddHealth(arrow.GetDamage() * -1); //Remove Health because is causing Damage to the enemy
            if(Health <= 0f)
                Die();

            Debug.LogFormat("{0} was hit by {1} with {2} Damage", gameObject.name, arrow.name, arrow.GetDamage().ToString());
        }
    }
}
