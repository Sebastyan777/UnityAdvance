using UnityEngine;

public class Laser : MonoBehaviour 
{
    public Color hitColor = Color.red;
	[SerializeField] private float size = 100; // длинна луча
	[SerializeField] private Transform laser; // родительский объект модели луча
	[SerializeField] private Transform gunPoint; // точка откуда должен вылетать луч
	[SerializeField] private LayerMask ignoreMask; // фильтр по слоям
	private float dist;

	void Create() 
	{
		dist = size;
		Vector3 hit = gunPoint.position + (gunPoint.localPosition + gunPoint.forward * dist);
		Vector3 center = (gunPoint.position + hit)/2;

		RaycastHit line;
		if(Physics.Linecast(gunPoint.position, hit, out line, ~ignoreMask))
		{
			if(!line.collider.isTrigger)
			{
				dist = Vector3.Distance(gunPoint.position, line.point);
				center = (gunPoint.position + line.point)/2;
                if (line.collider.CompareTag("Cube"))
                {
                    Renderer cubeRenderer = line.collider.GetComponent<Renderer>();
                    if (cubeRenderer != null)
                        cubeRenderer.material.color = hitColor;
                }
			}
		}

		laser.localScale = new Vector3(1, 1, dist/2);
		laser.position = center;
		laser.localPosition = new Vector3(0, 0, laser.localPosition.y);
		laser.gameObject.SetActive(true);
	}

	void LateUpdate()
	{
		if(Input.GetMouseButton(0))
		{
			Create();
		}
		else
		{
			laser.gameObject.SetActive(false);
		}
	}
}