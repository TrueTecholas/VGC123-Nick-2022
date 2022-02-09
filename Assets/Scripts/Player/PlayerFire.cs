using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    SpriteRenderer sr;
    Animator anim;

    public Transform spawnPointLeft;
    public Transform spawnPointRight;


    public float projectileSpeed;
    public Projectile projectPrefab;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (projectileSpeed <= 0)
            projectileSpeed = 7.0f;

    }

    void Update()
    {
       
    }

    public void FireProjectile()
    {
        if (sr.flipX)
        {
            Projectile temp = Instantiate(projectPrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            temp.speed = -projectileSpeed;
        }
        else
        {
            Projectile temp = Instantiate(projectPrefab, spawnPointRight.position, spawnPointRight.rotation);
            temp.speed = projectileSpeed;
        }

    } 
}
