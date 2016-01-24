using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Random = UnityEngine.Random;

public static class WritePoints
{
	public static void Write(List<Vector3> lst, string split = " ", int maxEntires = -1)
	{
		string fileName = "pointClouds/pcObj_" + RandomString(25) + ".txt";
		int numEntries = 0;
		using (StreamWriter file = new StreamWriter(fileName))
		{
			foreach (Vector3 v3 in lst)
			{
				var str = v3.x + " " + v3.y + " " + v3.z;
				file.WriteLine(str);
				numEntries++;
				if (maxEntires > 0 && numEntries >= maxEntires)
					break;
			}
		}
	}

	public static string RandomString(int length)
	{
		const string chars = "abcdefghijklmnopqrstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < length; i++)
		{
			sb.Append(chars[Random.Range(0, chars.Length)]);
		}
		return sb.ToString();
	}
}