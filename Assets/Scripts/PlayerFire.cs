using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//목표: 사용자 입력(Space)를 입력받아 총알을 생성한다

// 목표 : 불릿 풀을 만들어서 관리하고 싶다.
// 속성 : 불릿의 개수, 오브젝트 풀 배열
// 순서1. 불릿의 개수만큼의 배열을 생성한다.
// 순서2. 불릿 게임 오브젝트를 생성한다.
// 순서3. 생성한 게임 오브젝트를 풀에 넣는다.
// 순서4. 게임오브젝트를 비활성화 해준다.

// 목표 : 불릿 오브젝트 풀에서 불릿이 비활성화 되어있다면 활성화 시킨다.

public class PlayerFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunPos;
    public int skillLevel = 0;
    public int poolSize = 100;
    public List<GameObject> bulletObjectPool;

    private void Start()
    {
        // 순서1. 불릿의 개수만큼의 배열을 생성한다.
        bulletObjectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            // 순서2. 불릿 게임 오브젝트를 생성한다.
            GameObject bulletGO = Instantiate(bullet);

            // 순서3. 생성한 게임 오브젝트를 풀에 넣는다.
            bulletObjectPool.Add(bulletGO);

            // 순서4. 게임오브젝트를 비활성화 해준다.
            bulletGO.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExcuteSkill(skillLevel);

            AudioSource audioSource = SoundManager.instance.GetComponent<SoundManager>().effAS;
            audioSource.clip = SoundManager.instance.GetComponent<SoundManager>().explosionAC[2];
            audioSource.Play();
        }
    }

    private void ExcuteSkill(int _skillLevel)
    {
        switch (_skillLevel)
        {
            case 0:
                ExcuteSkill1();
                break;
            case 1:
                ExcuteSkill2();
                break;
            case 2:
                ExcuteSkill3();
                break;
            case 3:
                ExcuteSkill4();
                break;

        }
    }

    void ExcuteSkill1()
    {
        if(bulletObjectPool.Count > 0)
        {
            GameObject bulletGO = bulletObjectPool[0];

            bulletGO.SetActive(true);

            bulletGO.transform.position = gunPos.transform.position;

            bulletObjectPool.Remove(bulletGO);
        }
    }

    void ExcuteSkill2()
    {
        if (bulletObjectPool.Count > 0)
        {
            GameObject bulletGO = bulletObjectPool[0];

            bulletGO.SetActive(true);

            bulletGO.transform.position = gunPos.transform.position + new Vector3(-0.3f, 0, 0);

            bulletObjectPool.Remove(bulletGO);
        }

        if (bulletObjectPool.Count > 0)
        {
            GameObject bulletGO = bulletObjectPool[0];

            bulletGO.SetActive(true);

            bulletGO.transform.position = gunPos.transform.position + new Vector3(0.3f, 0, 0);

            bulletObjectPool.Remove(bulletGO);
        }
    }

    void ExcuteSkill3()
    {
        if (bulletObjectPool.Count > 0)
        {
            GameObject bulletGO = bulletObjectPool[0];

            bulletGO.SetActive(true);

            bulletGO.transform.position = gunPos.transform.position + new Vector3(-0.3f, 0, 0);
            bulletGO.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 30));
            bulletGO.GetComponent<Bullet>().dir = bulletGO.transform.up;

            bulletObjectPool.Remove(bulletGO);
        }

        if (bulletObjectPool.Count > 0)
        {
            GameObject bulletGO = bulletObjectPool[0];

            bulletGO.SetActive(true);

            bulletGO.transform.position = gunPos.transform.position + new Vector3(0.3f, 0, 0);
            bulletGO.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -30));
            bulletGO.GetComponent<Bullet>().dir = bulletGO.transform.up;

            bulletObjectPool.Remove(bulletGO);
        }

        if (bulletObjectPool.Count > 0)
        {
            GameObject bulletGO = bulletObjectPool[0];

            bulletGO.SetActive(true);

            bulletGO.transform.position = gunPos.transform.position;

            bulletObjectPool.Remove(bulletGO);
        }
    }

    public static int degree = 15;
    private int bulletNum = 360 / degree;

    void ExcuteSkill4()
    {
        for (int i = 0; i < bulletNum; i++)
        {
            if (bulletObjectPool.Count > 0)
            {
                GameObject bulletGO = bulletObjectPool[0];

                bulletGO.SetActive(true);
                bulletGO.transform.position = gunPos.transform.position;
                bulletGO.transform.rotation = Quaternion.Euler(new Vector3(0, 0, degree * i));
                bulletGO.GetComponent<Bullet>().dir = bulletGO.transform.up;

                bulletObjectPool.Remove(bulletGO);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            if (skillLevel < 3)
            {
                skillLevel++;
            }
            other.gameObject.SetActive(false);

        }
    }
}
