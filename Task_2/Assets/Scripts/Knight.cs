using UnityEngine;

public class Knight : Unit
{
    private void Awake()
    {
        movementDirectionFromX = 1f;

        currentHealth = maxHelth = 150f;

        UnitsOnScene.Knigts.Add(this);
    }

    private void Start()
    {
        EnemiesList = UnitsOnScene.Enemies;
    }

    protected override void Kill()
    {
        base.Kill();
        UnitsOnScene.Knigts.Remove(this);
    }
}
