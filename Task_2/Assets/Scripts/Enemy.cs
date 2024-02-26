using UnityEngine;

public class Enemy : Unit
{
    private void Awake()
    {
        movementDirectionFromX = -1f;

        currentHealth = maxHelth = 100f;

        UnitsOnScene.Enemies.Add(this);
    }

    private void Start()
    {
        EnemiesList = UnitsOnScene.Knigts;
    }

    protected override void Kill()
    {
        base.Kill();
        UnitsOnScene.Enemies.Remove(this);
    }
}
