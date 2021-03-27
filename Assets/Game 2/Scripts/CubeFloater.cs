using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFloater : MonoBehaviour
{
    public float movePower = 10f;

    public GameObject blueObj;
    public GameObject yellowObj;

    Vector3 moveDirection;

    bool isBlue = true;

    Rigidbody rb;
    FloaterManager manager;

    void Start()
    {
        manager = GetComponentInParent<FloaterManager>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isBlue) 
        {
            moveDirection = Vector3.up;

            if (manager.yellowFloaters.Contains(gameObject))
                manager.yellowFloaters.Remove(gameObject);

            if (!manager.blueFloaters.Contains(gameObject))
                manager.blueFloaters.Add(gameObject);
        }
        else 
        {
            moveDirection = Vector3.down;

            if (manager.blueFloaters.Contains(gameObject))
                manager.blueFloaters.Remove(gameObject);

            if (!manager.yellowFloaters.Contains(gameObject))
                manager.yellowFloaters.Add(gameObject);
        }

        rb.AddForce(moveDirection * movePower * Time.deltaTime, ForceMode.Force);
    }

    void SetBlue() 
    {
        blueObj.SetActive(true);
        yellowObj.SetActive(false);
    }

    void SetYellow() 
    {
        blueObj.SetActive(false);
        yellowObj.SetActive(true);
    }

	private void OnMouseDown()
	{
        isBlue = !isBlue;

        if (isBlue)
        {
            SetBlue();
        }
        else
        {
            SetYellow();
        }
    }

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.transform.CompareTag("Ground") && !isBlue) 
        {
            Destroy(gameObject);
            GameManager.Restart();
        }
	}
}
