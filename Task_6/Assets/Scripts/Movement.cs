using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed;
    protected Rigidbody _rb;
    protected Vector3 _moveVector;
    protected virtual void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        _moveVector.x = Input.GetAxisRaw("Horizontal");

        _rb.MovePosition(_rb.position + _moveVector * Speed * Time.deltaTime);
    }
}
