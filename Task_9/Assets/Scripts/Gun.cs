using UnityEngine;

public class Gun : MonoBehaviour
{
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                RaycastHit hit;

                if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
                    Debug.Log(hit.transform.name);
            }
        }
    }
}
