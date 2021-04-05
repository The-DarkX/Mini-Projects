using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloaterManager : MonoBehaviour
{
    public int totalFloaterAmount = 10;

    public Vector2 spawnArea;

    public GameObject[] floaterPrefabs;

    public List<CubeFloater> floaters = new List<CubeFloater>();

    Vector3 spawnPos;
    Quaternion spawnRotation;

    bool allSpawned = false;

	void Start()
    {
        Time.timeScale = 1;

        for (int i = 0; i < totalFloaterAmount; i++)
        {
            spawnPos = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y), transform.position.z);
            if (Physics.OverlapSphere(spawnPos, 2) != null) 
            {
                spawnPos = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y), transform.position.z);
            }

            spawnRotation = Quaternion.Euler(0, 90, 0);

            Instantiate(floaterPrefabs[Random.Range(0, floaterPrefabs.Length)], spawnPos + transform.position, spawnRotation, transform);
        }

        allSpawned = true;
    }

	private void Update()
	{
		for (int i = 0; i < floaters.Count; i++)
		{
            if (floaters[i] == null)
                floaters.RemoveAt(i);
		}

        if (allSpawned && floaters.Count <= 0) 
        {
            GameManager.instance.GameOver();
        }
	}

	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnArea * 2);
	}
}
