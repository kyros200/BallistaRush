using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-50, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if(collision.tag != "Shredder")
            Destroy(gameObject);
    }
}
