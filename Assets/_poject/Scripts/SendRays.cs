using UnityEngine;
using System.Collections.Generic;

public class SendRays : MonoBehaviour
{
	private const float RaySpacing = 0.001f;
	private const float PointScale = 0.25f;
	readonly Vector3 _scaleVec = new Vector3(PointScale, PointScale, PointScale);

	public static bool WriteToFile = false;
	public static bool CreateSpheres = true;
	public static bool CreateTrainingSet = false;

	public Transform Trees;

	private Camera _rayCam;

	void Awake()
	{
		_rayCam = GetComponent<Camera>();
	}

	void CastRays()
	{
		const float noiseAmount = 0.01f;
		MockPoint mp = new MockPoint(_scaleVec);
		Ray ray;
		RaycastHit hit;
		List<Vector3> pointsList = new List<Vector3>();
		Vector3 pos;
		for (float i = 0f; i <= 1f; i += RaySpacing)
		{
			for (float j = 0f; j <= 1f; j += RaySpacing)
			{
				ray = _rayCam.ViewportPointToRay(new Vector3(i, j, 0));
				if (Physics.Raycast(ray, out hit))
				{
					pos = MockPoint.AddNoise(hit.point, noiseAmount);
					if (CreateSpheres)
						mp.CreateSphereAtPos(pos);
					if (WriteToFile)
						pointsList.Add(pos);
				}
			}
		}
		if (WriteToFile)
		{
			pointsList = ProcessPoints.Process(pointsList);
			WritePoints.Write(pointsList, " ", 50);
		}
	}

	void CreatePointClouds()
	{
		if (CreateTrainingSet)
		{
			foreach (Transform tree in Trees)
			{
				tree.gameObject.SetActive(false);
				Debug.LogWarning(tree.name);
			}
			for (int i = 0; i < 25; i++)
			{
				foreach (Transform tree in Trees)
				{
					tree.gameObject.SetActive(true);
					tree.Manipulate(0.5f, 2f);
					CastRays();
					tree.gameObject.SetActive(false);
				}
			}
		}
		else
		{
			CastRays();
		}
	}

	void Start ()
	{
		CreatePointClouds();
	}
}
