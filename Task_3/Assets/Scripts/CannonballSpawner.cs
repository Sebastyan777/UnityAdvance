using UnityEngine;

public class CannonballSpawner : MonoBehaviour
{
    public GameObject Cannonball;
    public Transform Position;
    public float ShotForce = 250f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shot();
    }

    private void Shot()
    {
        var exCannonball = Instantiate(Cannonball, Position.position, Position.rotation);

        var rbExCannonball = exCannonball.AddComponent<Rigidbody>();
        rbExCannonball.AddForce(Position.forward * ShotForce, ForceMode.Impulse);
    }
}
