using UnityEngine;
using System.Collections;

public class Bush_Enemy : Enemy
{
    bool isHit = false;
    void Awake()
    {
        //ren = transform.Find("Bush_Enemy").GetComponent<SpriteRenderer>();
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
        if (collision.tag == "Bullet" && !isHit)
        {
            isHit = true;
            if(HP > 0)
            {
                Vector3 dropLocation = transform.position;
                dropLocation.x = dropLocation.x + 2f;
                dropLocation.y = 0;
                Instantiate(LootDrop, dropLocation, Quaternion.identity);
            }
            Hurt();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isHit = false;
    }
}
