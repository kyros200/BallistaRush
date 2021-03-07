using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] string Name = "Enemy";
    [SerializeField] float Health = 20f;
    float ActualHealth;
    [SerializeField] float Velocity = 50f;
    [SerializeField] float Damage = 10f;

    Session actualSession;

    void Die()
    {
        actualSession.AddEnemiesAlive(-1);
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
        actualSession = FindObjectOfType<Session>();
        ActualHealth = Health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Arrow tmp = collision.gameObject.GetComponent<Arrow>();
        if (tmp)
        {
            AddHealth(tmp.GetDamage() * -1); //Remove Health because is causing Damage to the enemy
            if(Health <= 0f)
                Die();

            Debug.LogFormat("{0} was hit by {1} with {2} Damage! Ouch!", gameObject.name, tmp.name, tmp.GetDamage().ToString());
        }
    }
}
