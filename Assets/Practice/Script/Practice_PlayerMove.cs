using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice_PlayerMove : MonoBehaviour
{
    public float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        gameObject.transform.position += (Vector3.up * v + Vector3.right * h) * speed * Time.deltaTime;
    }
}
