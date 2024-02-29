using UnityEngine;

public class CannonRotate : Movement
{
    protected override void Update()
    {
        _moveVector.z = Input.GetAxisRaw("Vertical");
        _rb.transform.Rotate(_moveVector * Speed * Time.deltaTime);
    }
}
