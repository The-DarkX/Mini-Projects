using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public float coinRotationSpeed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(1, 0, 0) * coinRotationSpeed * Time.deltaTime);
    }
}
