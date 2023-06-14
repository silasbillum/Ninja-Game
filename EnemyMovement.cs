using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform Player;
    
    
    public float MaxDist = 1f;
    public float MinDist = 1f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Player != null)
        {
            Vector2 direction = Player.position - transform.position;

            if (direction.magnitude <= MaxDist && direction.magnitude >= MinDist)
            {
                direction.Normalize();
                transform.position += (Vector3)direction * Time.deltaTime;

                // Flip the enemy sprite if the player is behind
                if (direction.x < 0)
                    spriteRenderer.flipX = true;
                else
                    spriteRenderer.flipX = false;
            }
        }
        if (Player != null)
        {
            Vector2 direction = Player.position - transform.position;

            if (direction.magnitude <= MaxDist && direction.magnitude >= MinDist)
            {
                direction.Normalize();
                transform.position += (Vector3)direction *  Time.deltaTime;

              
            }
        }
    }
}



