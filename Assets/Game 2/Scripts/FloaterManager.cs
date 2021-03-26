using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloaterManager : MonoBehaviour
{
    public GameObject floaterPrefab;
    public int totalFloaterAmount = 10;

    public Vector2 spawnArea;

    Vector3 spawnPos;
    Quaternion spawnRotation;

    int orangeCount;

    void Start()
    {
        Time.timeScale = 1;

        for (int i = 0; i < totalFloaterAmount; i++)
        {
            spawnPos = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y), transform.position.z);
            spawnRotation = Quaternion.Euler(0, 0, Random.Range(0, 180));

            Instantiate(floaterPrefab, spawnPos, spawnRotation, transform);
        }
    }

    void Update()
    {
        if (transform.childCount < totalFloaterAmount) 
        {
            Time.timeScale = 0.5f;
            Invoke("Restart", 0.5f);
        }
    }

    void Restart() 
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnArea * 2);
	}
}
