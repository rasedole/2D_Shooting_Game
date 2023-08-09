using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표 : 내가(총알이) 위로 날아간다.
//방향이 필요하다.
//속도가 필요하다.

public class Bullet : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 dir = Vector3.up;
    protected GameObject player;

    //매 프레임마다 총알이 위로 날아간다.
    // Update is called once per frame

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision otherObject)
    {
        Destroy(gameObject);
    }
}
