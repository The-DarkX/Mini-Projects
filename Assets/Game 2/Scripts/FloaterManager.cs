using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloaterManager : MonoBehaviour
{
    public Text scoreText;

    public int totalFloaterAmount = 10;

    public Vector2 spawnArea;

    public GameObject[] floaterPrefabs;

    public List<GameObject> blueFloaters = new List<GameObject>();
    public List<GameObject> yellowFloaters = new List<GameObject>();

    Vector3 spawnPos;
    Quaternion spawnRotation;

	void Start()
    {
        Time.timeScale = 1;

        for (int i = 0; i < totalFloaterAmount; i++)
        {
            spawnPos = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y), transform.position.z);
            spawnRotation = Quaternion.Euler(0, 90, 0);

            Instantiate(floaterPrefabs[Random.Range(0, floaterPrefabs.Length)], spawnPos, spawnRotation, transform);
        }
    }

    void Update()
    {
        GameManager.DisplayScore(scoreText, yellowFloaters.Count);
    }

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnArea * 2);
	}
}
