using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//��ǥ: ����� �Է�(Space)�� �Է¹޾� �Ѿ��� �����Ѵ�

// ��ǥ : �Ҹ� Ǯ�� ���� �����ϰ� �ʹ�.
// �Ӽ� : �Ҹ��� ����, ������Ʈ Ǯ �迭
// ����1. �Ҹ��� ������ŭ�� �迭�� �����Ѵ�.
// ����2. �Ҹ� ���� ������Ʈ�� �����Ѵ�.
// ����3. ������ ���� ������Ʈ�� Ǯ�� �ִ´�.
// ����4. ���ӿ�����Ʈ�� ��Ȱ��ȭ ���ش�.

// ��ǥ : �Ҹ� ������Ʈ Ǯ���� �Ҹ��� ��Ȱ��ȭ �Ǿ��ִٸ� Ȱ��ȭ ��Ų��.

public class PlayerFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunPos;
    public int skillLevel = 0;
    public int poolSize = 100;
    public List<GameObject> bulletObjectPool;

    private void Start()
    {
        // ����1. �Ҹ��� ������ŭ�� �迭�� �����Ѵ�.
        bulletObjectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            // ����2. �Ҹ� ���� ������Ʈ�� �����Ѵ�.
            GameObject bulletGO = Instantiate(bullet);

            // ����3. ������ ���� ������Ʈ�� Ǯ�� �ִ´�.
            bulletObjectPool.Add(bulletGO);

            // ����4. ���ӿ�����Ʈ�� ��Ȱ��ȭ ���ش�.
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
