using System.Collections;
using TMPro;
using UnityEngine;

public class ClickEffect : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI textMeshPro;
	[SerializeField] private float sideSpeed = 8f;
	[SerializeField] private float heightSpeed = 4f;
	[SerializeField] private float lifeTime = 1f;
	[SerializeField] private float radius = 0.3f;
	private float angle;
	private Vector3 startPosition;

	public void Init(string text)
	{
		textMeshPro.text = text;
		Vector3 mousePosition = Input.mousePosition;
		transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
		StartCoroutine(ShowEffect());
	}

	private IEnumerator ShowEffect()
	{
		float time = 0f;
		while (time <= lifeTime)
		{
			time += Time.deltaTime;
			yield return null;
			MoveUp();
		}
		Destroy(gameObject);
	}

	private void MoveUp()
	{
		angle += sideSpeed * Time.deltaTime;
		float x = startPosition.x + Mathf.Sin(angle) * radius;
		float y = transform.position.y + heightSpeed * Time.deltaTime;
		float z = 0f;
		transform.position = new Vector3(x, y, z);
	}
}
