using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int scoreDecrement = 20;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Projectile") && !collision.gameObject.GetComponent<CubeFloater>().isBlue) 
		{
			GameManager.instance.SubtractScore(scoreDecrement);
			GameManager.instance.DisplayScore();
			Destroy(collision.gameObject);
		}
	}
}
