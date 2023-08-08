using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackTime = 5.0f;
    private float currentTime = 0;
    public GameObject bullet;
    public GameObject gunPos;
    protected GameObject player;
    protected Vector3 playerDir;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            currentTime += Time.deltaTime;

            if (currentTime > attackTime)
            {
                GameObject bulletGO = Instantiate(bullet);

                bulletGO.transform.position = gunPos.transform.position;

                playerDir = (player.transform.position - gameObject.transform.position).normalized;
                bulletGO.GetComponent<EnemyBullet>().dir = playerDir;

                bulletGO.transform.rotation = Quaternion.FromToRotation(Vector3.down, playerDir);
                bulletGO.transform.rotation *= Quaternion.Euler(0, 0, -90);

                currentTime = 0;
            }
        }
    }
}   
