using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표 : Background의 Material의 Offset의 Y를 일정 속도로 증가시킨다
public class BackgroundRoller : MonoBehaviour
{

    public float speed = 1.0f;
    private float currentTime;
    public Material material;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += speed * Time.deltaTime;
        material.mainTextureOffset = (Vector3.up * currentTime);
    }
}
