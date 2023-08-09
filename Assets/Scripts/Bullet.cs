using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ : ����(�Ѿ���) ���� ���ư���.
//������ �ʿ��ϴ�.
//�ӵ��� �ʿ��ϴ�.

public class Bullet : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 dir = Vector3.up;
    protected GameObject player;

    //�� �����Ӹ��� �Ѿ��� ���� ���ư���.
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
