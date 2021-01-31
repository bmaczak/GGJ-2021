using UnityEngine;

public class ActivateSingleChild : MonoBehaviour
{
	void Start()
	{
		int activeChildIndex = Random.Range(0, transform.childCount);
		for (int i = 0; i< transform.childCount; ++i)
			transform.GetChild(i).gameObject.SetActive(i == activeChildIndex);
	}
}
