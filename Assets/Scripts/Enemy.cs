using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

//목표 : 아래 방향으로 이동한다.
//목표2 : 다른 충돌체와 부딫혔으면 서로 파괴된다.
//목표3 : 생성시 30%의 확률로 플레이어를 따라간다.
public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;
    public int hp = 3;
    public Vector3 dir = Vector3.down;
    public GameObject explosion;
    protected GameObject player;
    int randValue = 0;
    // Update is called once per frame

    private void Start()
    {
        randValue = Random.Range(0, 10);
        player = GameObject.Find("Player");

        if (randValue < 5)
        {
            if (player != null)
            {
                dir = (player.transform.position - gameObject.transform.position).normalized;
            }
        }
    }

    void Update()
    {
        if (randValue > 5)
        {
            if (player != null)
            {
                dir = (player.transform.position - gameObject.transform.position).normalized;
            }
        }
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision otherObject)
    {
        hp--;
        GameManager.instance.SetAttackScore();

        if (otherObject.gameObject.tag == "Player")
        {
            int playerHP = player.GetComponent<PlayerMove>().hp--;

            if (player.GetComponent<PlayerMove>().hp <= 0)
            {
                otherObject.gameObject.SetActive(false);

                GameManager.instance.SetBestScore();
            }

            GameManager.instance.SetDestroyScore();
            this.gameObject.SetActive(false);
            GameObject explosionGO = Instantiate(explosion);
            explosionGO.transform.position = transform.position;
            AudioSource audioSource = SoundManager.instance.GetComponent<SoundManager>().effAS;
            audioSource.clip = SoundManager.instance.GetComponent<SoundManager>().explosionAC[1];
            audioSource.Play();
        }
        else if (hp <= 0)
        {
            GameManager.instance.SetDestroyScore();
            this.gameObject.SetActive(false);
            GameObject explosionGO = Instantiate(explosion);
            explosionGO.transform.position = transform.position;
            otherObject.gameObject.SetActive(false);
            PlayerFire playerFire = GameObject.Find("Player").GetComponent<PlayerFire>();
            otherObject.transform.parent = GameManager.instance.player.transform;
            playerFire.bulletObjectPool.Add(otherObject.gameObject);
            AudioSource audioSource = SoundManager.instance.GetComponent<SoundManager>().effAS;
            audioSource.clip = SoundManager.instance.GetComponent<SoundManager>().explosionAC[1];
            audioSource.Play();
        }
        else
        {
            otherObject.gameObject.SetActive(false);
            PlayerFire playerFire = GameObject.Find("Player").GetComponent<PlayerFire>();
            otherObject.transform.parent = GameManager.instance.player.transform;
            playerFire.bulletObjectPool.Add(otherObject.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {

    }
    private void OnCollisionExit(Collision collision)
    {

    }

}
