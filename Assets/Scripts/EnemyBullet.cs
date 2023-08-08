using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표 : 내가(총알이) 위로 날아간다.
//방향이 필요하다.
//속도가 필요하다.
public class EnemyBullet : MonoBehaviour
{
    public float speed = 10.0f;
    public Vector3 dir = Vector3.down;
    public GameObject hit;
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
        if (player != null)
        {
            if (otherObject.gameObject.tag == "Player")
            {
                Destroy(gameObject);
                int playerHP = --player.GetComponent<PlayerMove>().hp;
                GameObject hitGO = Instantiate(hit);
                hitGO.transform.position = transform.position;
                if(playerHP <= 0)
                {
                    Destroy(otherObject.gameObject);
                }
            }
        }

        else
        {
            Destroy(otherObject.gameObject);
            Destroy(gameObject);
            GameObject hitGO = Instantiate(hit);
            hitGO.transform.position = transform.position;
        }

    }


}
