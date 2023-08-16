using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//��ǥ: �÷��̾ ����� �Է¿� ���� �����̰� �ʹ�.
public class PlayerMove : MonoBehaviour
{
    public float speed = 5;
    public int hp = 10;
    
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Vector3 dir = Vector3.right * 5;

        Vector3 dir = Vector3.right * h + Vector3.up * v;

        //transform.Translate(dir * speed * Time.deltaTime);
        //transform.position = transform.position + dir * speed * Time.deltaTime;
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnDisable()
    {
        GameManager.instance.GameOver();
    }
}   
