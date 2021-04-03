using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Obstacle : MonoBehaviour
{
	public GameObject particleFX;

    public int scoreDecrement = 20;

	AudioManager audioManager;

	private void Start()
	{
		audioManager = AudioManager.instance;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Projectile") && !collision.gameObject.GetComponent<CubeFloater>().isBlue) 
		{
			GameObject particles = Instantiate(particleFX, collision.transform.position, Quaternion.identity);
			audioManager.PlaySound("Obstacle");
			CameraShaker.Instance.ShakeOnce(4f, 4f, 0f, 0.5f);

			GameManager.instance.SubtractScore(scoreDecrement);
			GameManager.instance.DisplayScore();

			collision.gameObject.GetComponent<CubeFloater>().Destroy();

			Destroy(particles, 2f);
		}
	}
}
