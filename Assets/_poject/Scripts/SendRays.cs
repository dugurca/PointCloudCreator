using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;

public class SendRays : MonoBehaviour
{
	private const float RaySpacing = 0.005f;
	private const float PointScale = 0.25f;
	readonly Vector3 _scaleVec = new Vector3(PointScale, PointScale, PointScale);

	public static bool WriteToFile = false;
	public static bool CreateSpheres = true;

	private Camera _rayCam;

	void Awake()
	{
		_rayCam = GetComponent<Camera>();
	}

	void Rays()
	{
		const float noiseAmount = 0.25f;
		MockPoint mp = new MockPoint(_scaleVec);
		Ray ray;
		RaycastHit hit;
		List<Vector3> pointsList = new List<Vector3>();
		for (float i = 0f; i <= 1f; i += RaySpacing)
		{
			for (float j = 0f; j <= 1f; j += RaySpacing)
			{
				ray = _rayCam.ViewportPointToRay(new Vector3(i, j, 0));
				if (Physics.Raycast(ray, out hit))
				{
					Vector3 pos = MockPoint.AddNoise(hit.point, noiseAmount);
					mp.CreateSphereAtPos(pos);
					pointsList.Add(pos);
				}
			}
		}
		WritePoints.Write(pointsList);
	}

	void Start ()
	{
		Rays();
	}
}
