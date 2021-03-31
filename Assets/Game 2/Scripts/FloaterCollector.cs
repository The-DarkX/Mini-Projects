using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloaterCollector : MonoBehaviour
{
	public GameObject particleFX;

    public int minIncrement = 5;
    public int maxIncrement = 16;

	AudioManager audioManager;

	private void Start()
	{
		audioManager = AudioManager.instance;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Projectile"))
		{
			if(!other.gameObject.transform.parent.GetComponent<CubeFloater>().isBlue)
			{
				GameObject particles = Instantiate(particleFX, other.transform.position, Quaternion.identity);
				audioManager.PlaySound("Collected");

				GameManager.instance.AddScore(minIncrement, maxIncrement);
				GameManager.instance.DisplayScore();
				Destroy(other.gameObject);
				Destroy(particles, 2f);
			}
		}
	}
}
