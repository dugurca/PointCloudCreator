using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Random = UnityEngine.Random;

public static class WritePoints
{
	public static void Write(List<Vector3> lst, string split = " ")
	{
		string fileName = "pcObj_" + RandomString(25) + ".txt";
		using (StreamWriter file = new StreamWriter(fileName))
		{
			foreach (Vector3 v3 in lst)
			{
				string str = v3.x + " " + v3.y + " " + v3.z;
				file.WriteLine(str);
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