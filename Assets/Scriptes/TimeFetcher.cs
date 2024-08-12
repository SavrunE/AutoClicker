using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class TimeFetcher : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(CheckGlobalTime());
	}

	private IEnumerator CheckGlobalTime()
	{
		using (UnityWebRequest request = UnityWebRequest.Head("https://www.google.com"))
		{
			yield return request.SendWebRequest();

			if (request.result != UnityWebRequest.Result.Success)
			{
				Debug.LogError("Error fetching time: " + request.error);
				yield break;
			}

			string dateHeader;
			if (request.GetResponseHeaders().TryGetValue("Date", out dateHeader))
			{
				DateTime dateTime;
				if (DateTime.TryParse(dateHeader, out dateTime))
				{
					Debug.Log("Global UTC time: " + dateTime.ToUniversalTime());
				}
				else
				{
					Debug.LogError("Failed to parse the date.");
				}
			}
			else
			{
				Debug.LogError("Date header not found in the response.");
			}
		}
	}
}