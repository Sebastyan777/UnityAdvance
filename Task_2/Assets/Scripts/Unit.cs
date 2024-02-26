using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float maxHelth;
    public float currentHealth;
    public float speed = 2f;
    public float movementDirectionFromX;
    public float distanceAttack;

    private Coroutine _attackCourotine;
    private Animator _animator => GetComponent<Animator>();

    protected List<Unit> EnemiesList;

    private void Start()
    {
        _animator.Play("Walk");
    }

    private void Update()
    {
        SearchEnemy();

        if (_attackCourotine == null)
            Move();
    }

    private void Move()
    {
        var currentPosition = transform.position;
        var targetPosition = currentPosition + Vector3.right * movementDirectionFromX;

        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, Time.deltaTime * speed);
    }

    private void SearchEnemy()
    {
        var enemiesInDistance = 
            EnemiesList.Where(x => Vector2.Distance(transform.position, x.transform.position) <= distanceAttack);

        if (enemiesInDistance.Any() && _attackCourotine == null)
        {
            var enemyInDistance = 
                EnemiesList.First(x => Vector2.Distance(transform.position, x.transform.position) <= distanceAttack);

            _attackCourotine = StartCoroutine(AttackNumerator(enemyInDistance));
        }

          
    }

    protected virtual void Kill()
    {
        StartCoroutine(KillNumerator());
    }

    IEnumerator KillNumerator()
    {        
        _animator.Play("Die");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    IEnumerator AttackNumerator(Unit unit)
    {
        _animator.Play("Attack");

        while(unit)
        {
            unit.currentHealth -= 10f;

            if (unit.currentHealth <= 0)
                unit.Kill();

            yield return new WaitForSeconds(0.5f);
        }

        _animator.Play("Walk");
        _attackCourotine = null;
    }
}
