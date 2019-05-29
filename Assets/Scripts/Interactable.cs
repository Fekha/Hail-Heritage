using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    bool isFocused = false;
    Transform Player;
    bool hasInteracted = false;
    public Transform interactionTransform;
    public virtual void Interact()
    {
        //this method should be overridden;
        Debug.Log("Interacting with " + transform.name);
    }
    public void Update()
    {
        if (isFocused && !hasInteracted)
        {
            float distance = Vector2.Distance(Player.position, interactionTransform.position);
            if(distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }
    public void OnFocused (Transform playerTransform)
    {
        isFocused = true;
        Player = playerTransform;
    }

    public void OnDefocused()
    {
        isFocused = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
