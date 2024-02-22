using UnityEngine;

public class Knight : Unit
{
    private void Awake()
    {
        movementDirectionFromX = 1f;

        currentHealth = maxHelth = 150f;
    }
}
