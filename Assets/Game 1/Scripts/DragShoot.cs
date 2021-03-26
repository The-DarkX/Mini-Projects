using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragShoot : MonoBehaviour
{
    public float power = 10f;

    public Vector2 minPower;
    public Vector2 maxPower;

    Rigidbody rb;
    Camera cam;
    TrajectoryLine tl;

    Vector3 force;
    Vector3 startPoint;
    Vector3 endPoint;

	private void Start()
	{
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        tl = GetComponent<TrajectoryLine>();
	}

	private void Update()
	{
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            print(startPoint);
            startPoint.z = 15;
        }
        else if (Input.GetMouseButton(0)) 
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            print(currentPoint);
            currentPoint.z = 15;
            tl.RenderLine(startPoint, currentPoint);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            print(endPoint);
            endPoint.z = 15;

            tl.EndLine();

            float clampedXPos = Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x);
            float clampedYPos = Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y);

            force = new Vector2(clampedXPos, clampedYPos);
            rb.AddForce(force * power, ForceMode.Impulse);
        }
	}
}
