using UnityEngine;
using System.Collections;

public class Bush_Enemy : Enemy
{
    void Awake()
    {
        ren = transform.Find("Full_Bush").GetComponent<SpriteRenderer>();
        moveSpeed = 0f;
    }

    void FixedUpdate()
    {
        if (HP <= 0 && !dead)
        {
            Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            if(HP > 0)
            {
                Vector3 dropLocation = transform.position;
                dropLocation.x = dropLocation.x + 2f;
                Instantiate(LootDrop, dropLocation, Quaternion.identity);
            }
            Hurt();
        }
    }
}
