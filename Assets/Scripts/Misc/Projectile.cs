using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    SpriteRenderer sr;
    // Start is called before the first frame update

    void Start()
    {
      sr = GetComponent<SpriteRenderer>();
        if (lifetime <= 0)
            lifetime = 2.0f;

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, lifetime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Map")
        {
            Destroy(gameObject);
        }
        if (speed < 0)
            sr.flipX = true;
    }
    
}

