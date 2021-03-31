using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloaterCollector : MonoBehaviour
{
    public int minIncrement = 5;
    public int maxIncrement = 16;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Projectile"))
		{
			if(!other.gameObject.transform.parent.GetComponent<CubeFloater>().isBlue)
			{
				GameManager.instance.AddScore(minIncrement, maxIncrement);
				GameManager.instance.DisplayScore();
				Destroy(other.gameObject);
			}
		}
	}
}
