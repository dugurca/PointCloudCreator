using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

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
		go.GetComponent<MeshRenderer>().receiveShadows = false;
		go.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
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

	public static Vector3 AddNoise(Vector3 pos, float noiseAmount)
	{
		Vector3 randPos = Vector3.zero;
		if (Math.Abs(noiseAmount) > float.Epsilon)
		{
			randPos = Random.insideUnitSphere * noiseAmount;
		}
		return pos + randPos;
	}
}
