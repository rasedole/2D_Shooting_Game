using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ: ���� �����Ѵ�.

// ��ǥ : ���׹� ������Ʈ Ǯ�� ���� �����ϰ� �ʹ�.
// �Ӽ� : ���׹� ������Ʈ�� ����, ������Ʈ Ǯ �迭
// ����1. ���׹� ������Ʈ�� ������ŭ�� �迭�� �����Ѵ�.
// ����2. ���׹� ���� ������Ʈ�� �����Ѵ�.
// ����3. ������ ���� ������Ʈ�� Ǯ�� �ִ´�.
// ����4. ���ӿ�����Ʈ�� ��Ȱ��ȭ ���ش�.

// ��ǥ : ���׹� ������Ʈ Ǯ���� ���׹̰� ��Ȱ��ȭ �Ǿ��ִٸ� Ȱ��ȭ ��Ų��.

public class EnemyManager : MonoBehaviour
{
    // �ʿ� �Ӽ�: Ư�� �ð�, ���� �ð�, �� GameObject 
    private float createTime = 1.0f;
    private float currentTime = 0;
    public float minTime = 0.5f;
    public float maxTime = 5.5f;
    public GameObject enemy;

    public int poolSize = 10;
    public List<GameObject> enemyObjectPool;

    void Start()
    {
        float randomCreateTime = Random.Range(minTime, maxTime);
        createTime = randomCreateTime;

        // ����1. ���׹� ������Ʈ�� ������ŭ�� �迭�� �����Ѵ�.
        enemyObjectPool = new List<GameObject>();

        // ����2. ���׹� ���� ������Ʈ�� �����Ѵ�.
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemyGO = Instantiate(enemy);
            // ����3. ������ ���� ������Ʈ�� Ǯ�� �ִ´�.
            enemyObjectPool.Add(enemyGO);

            // ����4. ���ӿ�����Ʈ�� ��Ȱ��ȭ ���ش�.
            enemyGO.SetActive(false);

            enemyGO.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= createTime)
        {
            if(enemyObjectPool.Count > 0)
            {
                GameObject enemyGO = enemyObjectPool[0];

                enemyGO.SetActive(true);
                enemyGO.transform.position = transform.position;

                enemyObjectPool.Remove(enemyGO);
            }

            currentTime = 0;
        }
    }
}
