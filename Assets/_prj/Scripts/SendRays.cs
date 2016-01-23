using UnityEngine;
using System.Collections;

public class SendRays : MonoBehaviour
{
	private const float RaySpacing = 0.005f;
	private const float PointScale = 0.25f;
	readonly Vector3 _scaleVec = new Vector3(PointScale, PointScale, PointScale);

	private Camera _rayCam;

	void Awake()
	{
		_rayCam = GetComponent<Camera>();
	}

	void Rays()
	{
		MockPoint mp = new MockPoint(_scaleVec);
		Ray ray;
		RaycastHit hit;
		for (float i = 0f; i <= 1f; i += RaySpacing)
		{
			for (float j = 0f; j <= 1f; j += RaySpacing)
			{
				ray = _rayCam.ViewportPointToRay(new Vector3(i, j, 0));
				if (Physics.Raycast(ray, out hit))
				{
					mp.CreateSphereAtPos(hit.point, 0.25f);
				}
			}
		}
	}

	void Start ()
	{
		Rays();
	}
}
