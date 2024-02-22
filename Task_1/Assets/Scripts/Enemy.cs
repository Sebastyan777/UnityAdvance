using UnityEngine;

public class Enemy : Unit
{
    private void Awake()
    {
        movementDirectionFromX = -1f;

        currentHealth = maxHelth = 100f;
    }
}
