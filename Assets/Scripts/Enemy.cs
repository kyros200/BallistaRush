using UnityEngine;

public class Enemy : MonoBehaviour
{
    Session actualSession;
    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-50, 0) * Time.deltaTime;
        actualSession = FindObjectOfType<Session>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Shredder" && collision.tag != "Enemy")
        {
            actualSession.AddEnemiesAlive(-1);
            Destroy(gameObject);
        }
    }
}
