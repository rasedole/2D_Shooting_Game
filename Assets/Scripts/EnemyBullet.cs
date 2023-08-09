using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ : ����(�Ѿ���) ���� ���ư���.
//������ �ʿ��ϴ�.
//�ӵ��� �ʿ��ϴ�.
public class EnemyBullet : MonoBehaviour
{
    public float speed = 10.0f;
    public Vector3 dir = Vector3.down;
    public GameObject hit;
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
        if (player != null)
        {
            if (otherObject.gameObject.tag == "Player")
            {
                Destroy(gameObject);
                int playerHP = --player.GetComponent<PlayerMove>().hp;
                GameObject hitGO = Instantiate(hit);
                hitGO.transform.position = transform.position;

                GameObject soundManagerGO = GameObject.Find("SoundManager");
                AudioSource audioSource = soundManagerGO.GetComponent<SoundManager>().effAS;
                audioSource.clip = soundManagerGO.GetComponent<SoundManager>().explosionAC[0];
                audioSource.Play();

                if (playerHP <= 0)
                {
                    Destroy(otherObject.gameObject);
                    GameObject soundManagerGO2 = GameObject.Find("SoundManager");
                    AudioSource audioSource2 = soundManagerGO.GetComponent<SoundManager>().effAS;
                    audioSource.clip = soundManagerGO.GetComponent<SoundManager>().explosionAC[1];
                    audioSource.Play();
                    
                    GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

                        gameManager.bestScore = gameManager.score;
                        gameManager.BestScoreText.text = gameManager.bestScore.ToString();
                        PlayerPrefs.SetInt("Best Score", gameManager.bestScore);

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
