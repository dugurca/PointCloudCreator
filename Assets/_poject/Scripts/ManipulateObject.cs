using UnityEngine;
public static class ManipulateObject
{
	public static void Manipulate(this Transform tr, float scaleMin, float scaleMax)
	{
		tr.localScale = RandScale(scaleMin, scaleMax);
		tr.rotation = RandRotation();
	}

	public static Vector3 RandScale(float scaleMin, float scaleMax)
	{
		float sc = Random.Range(scaleMin, scaleMax);
		return new Vector3(sc, sc, sc);
	}

	public static Quaternion RandRotation()
	{
		Vector3 rot = new Vector3(0, Random.Range(0f, 360f));
		return Quaternion.Euler(rot);
	}
}
