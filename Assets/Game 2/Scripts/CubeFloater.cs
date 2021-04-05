using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFloater : MonoBehaviour
{
    public float movePower = 10f;

    public GameObject blueObj;
    public GameObject yellowObj;

    Vector3 moveDirection;

    public bool isBlue = true;

    Rigidbody rb;
    FloaterManager manager;
    AudioManager audioManager;

    void Start()
    {
        manager = GetComponentInParent<FloaterManager>();
        audioManager = AudioManager.instance;
        rb = GetComponent<Rigidbody>();

        manager.floaters.Add(this);
    }

    void Update()
    {
        if (isBlue) 
        {
            moveDirection = Vector3.up;
        }
        else 
        {
            moveDirection = Vector3.down;
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
        if (GameManager.instance.isGameRunning)
        {
            isBlue = !isBlue;

            audioManager.PlaySound("Select");

            if (isBlue)
            {
                SetBlue();
            }
            else
            {
                SetYellow();
            }
        }
    }

    public void DestroyFloater() 
    {
        Destroy(gameObject);
    }
}
