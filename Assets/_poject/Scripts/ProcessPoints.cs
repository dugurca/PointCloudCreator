using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class ProcessPoints
{
	public static List<Vector3> Process(List<Vector3> lst)
	{
		float minX = float.MaxValue;
		float minZ = float.MaxValue; 
		float minY = float.MaxValue;

		foreach (var v3 in lst)
		{
			if (v3.x < minX) minX = v3.x;
			if (v3.y < minY) minY = v3.y;
			if (v3.z < minZ) minZ = v3.z;
		}

		float xAdd = 0f, yAdd = 0f, zAdd = 0f;
		if (minX < 0) xAdd = minX * -1f;
		if (minY < 0) yAdd = minY * -1f;
		if (minZ < 0) zAdd = minZ * -1f;
		Vector3 addVec = new Vector3(xAdd, yAdd, zAdd);
		Debug.LogWarning(addVec);
		for (int i = 0; i < lst.Count; i++)
			lst[i] += addVec;

		return lst.OrderByDescending(k => k.y).ToList();
	}
}
