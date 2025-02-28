using System;
using Unity.VisualScripting;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    [SerializeField] PLayerStats myStats;
    int health;

    // Need a script that has the collisions (getComponent and isTrigger) to write in myStats to decrease the player's HP

    // We will write a subtraction and an If statement, and figure out how to switch scenes when HP is 0.

    // same as shooter game, we need to have an overlay when things end. Also a button that returns to main menu

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
        {
            if (collision.GetComponent<characterMovement>() != null)
            {
                health = myStats.health;
                myStats.health -= 1;
            }
        }
}
