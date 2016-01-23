using UnityEngine;
using System.Collections;

public class MockPoint
{
	public float scale = 0.1f;
	public Vector3 scaleVec;

	public MockPoint() 
	{
		scaleVec = new Vector3(scale, scale, scale);
	}

	public MockPoint(Vector3 sv)
	{
		scale = sv.x;
		scaleVec = sv;
	}

	public GameObject CreateSphere()
	{
		var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		go.transform.localScale = scaleVec;
		go.GetComponent<Collider>().enabled = false;
		return go;
	}

	public GameObject CreateSphereAtPos(Vector3 pos, float noiseAmount = 0f)
	{
		var go = CreateSphere();
		Vector3 randPos = Vector3.zero;
		if (noiseAmount > 0f)
		{
			randPos = Random.insideUnitSphere * noiseAmount;
		}
		go.transform.position = pos + randPos;

		return go;
	}


}
