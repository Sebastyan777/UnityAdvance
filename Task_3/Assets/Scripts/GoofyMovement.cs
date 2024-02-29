using UnityEngine;

public class GoofyMovement : Movement
{
    private Animator _animator;

    protected override void Start()
    {
        base.Start();
        _animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        Move();
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _rb.transform.rotation = Quaternion.Euler(0,90,0);
            _animator.Play("PullStart");
        }
        else if (Input.GetKeyUp(KeyCode.A))
            _animator.Play("PullStop");
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _rb.transform.rotation = Quaternion.Euler(0,90,0);
            _animator.Play("PushStart");
        }
        else if (Input.GetKeyUp(KeyCode.D))
            _animator.Play("PushStop");
    }
}
