using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float maxHelth;
    public float currentHealth;
    public float speed = 2f;
    public float movementDirectionFromX;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position += Vector3.right * movementDirectionFromX * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var unit = other.collider.GetComponent<Unit>();
        StartCoroutine(AttackNumerator(unit));
    }

    IEnumerator AttackNumerator(Unit unit)
    {
        while(unit.gameObject)
        {
            unit.currentHealth -= 10f;

            if (unit.currentHealth <= 0)
                Destroy(unit.gameObject);

            yield return new WaitForSeconds(1f);
        }
    }
}
