using UnityEngine;
using System.Collections;

public class SendRays : MonoBehaviour
{
	private const float RaySpacing = 0.005f;
	private const float Sc = 0.25f;
	readonly Vector3 _scaleVec = new Vector3(Sc, Sc, Sc);

	private Camera _rayCam;
	void Awake()
	{
		_rayCam = GetComponent<Camera>();
	}

	void Rays()
	{
		MockPoint mp = new MockPoint(Sc, _scaleVec);
		Ray ray;
		RaycastHit hit;
		for (float i = 0f; i <= 1f; i += RaySpacing)
		{
			for (float j = 0f; j <= 1; j += RaySpacing)
			{
				ray = _rayCam.ViewportPointToRay(new Vector3(i, j, 0));
				if (Physics.Raycast(ray, out hit))
				{
					mp.CreateSphereAtPos(hit.point);
				}
			}
		}
	}
	
	void Start ()
	{
		Rays();
	}
}
