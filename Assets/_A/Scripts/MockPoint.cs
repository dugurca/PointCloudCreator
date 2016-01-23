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

	public MockPoint(float s, Vector3 sv)
	{
		scale = s;
		scaleVec = sv;
	}

	public GameObject CreateSphere()
	{
		var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		go.transform.localScale = scaleVec;
		go.GetComponent<Collider>().enabled = false;
		return go;
	}

	public GameObject CreateSphereAtPos(Vector3 pos)
	{
		var go = CreateSphere();
		go.transform.position = pos;
		return go;
	}
}
