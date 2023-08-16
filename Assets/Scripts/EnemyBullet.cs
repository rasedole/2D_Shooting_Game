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
    public int parantID;

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
                gameObject.SetActive(false);
                int playerHP = --player.GetComponent<PlayerMove>().hp;
                GameObject hitGO = Instantiate(hit);
                hitGO.transform.position = transform.position;

                AudioSource audioSource = SoundManager.instance.GetComponent<SoundManager>().effAS;
                audioSource.clip = SoundManager.instance.GetComponent<SoundManager>().explosionAC[0];
                audioSource.Play();

                if (playerHP <= 0)
                {
                    otherObject.gameObject.SetActive(false);
                    AudioSource audioSource2 = SoundManager.instance.GetComponent<SoundManager>().effAS;
                    audioSource.clip = SoundManager.instance.GetComponent<SoundManager>().explosionAC[1];
                    audioSource.Play();

                    GameManager.instance.SetBestScore();

                }
            }
        }

        else
        {
            otherObject.gameObject.SetActive(false);
            gameObject.SetActive(false);
            GameObject hitGO = Instantiate(hit);
            hitGO.transform.position = transform.position;
        }

    }


}
