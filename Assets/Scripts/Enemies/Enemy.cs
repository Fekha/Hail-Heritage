using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;        // The speed the enemy moves at.
    public int HP = 2;                  // How many times the enemy can be hit before it dies.
    public GameObject LootDrop; // A prefab of 100 that appears when the enemy dies.
    public Sprite deadEnemy;            // A sprite of the enemy when it's dead.
    public Sprite damagedEnemy;			// An optional sprite of the enemy when it's damaged.
    public SpriteRenderer ren;         // Reference to the sprite renderer.
    public bool dead = false;          // Whether or not the enemy is dead.

    public virtual void Death()
    {
        // Find all of the sprite renderers on this object and it's children.
        SpriteRenderer[] otherRenderers = GetComponentsInChildren<SpriteRenderer>();
        // Disable all of them sprite renderers.
        foreach (SpriteRenderer s in otherRenderers)
        {
            s.enabled = false;
        }

        // Re-enable the main sprite renderer and set it's sprite to the deadEnemy sprite.
        ren.enabled = true;
        ren.sprite = deadEnemy;
        
        // Set dead to true.
        dead = true;

        // Find all of the colliders on the gameobject and set them all to be triggers.
        Collider2D[] cols = GetComponents<Collider2D>();
        foreach (Collider2D c in cols)
        {
            c.isTrigger = true;
        }
    }

    public void Flip()
    {
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }

    public void Hurt()
    {
        HP--;
    }
}
