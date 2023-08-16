using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ : �� �Ǵ� �Ѿ��� �����Ǿ��� ���, �� ��ü�� ��Ȱ��ȭ�Ѵ�.
public class DestroyZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player"))
        {
            return;
        }

        if(other.gameObject.layer == 6)
        {
            PlayerFire playerFire = GameObject.Find("Player").GetComponent<PlayerFire>();
            other.gameObject.SetActive(false);
            other.transform.parent = GameManager.instance.player.transform;

            playerFire.bulletObjectPool.Add(other.gameObject);
        }

        if(other.gameObject.layer == 9)
        {
            EnemyBullet bullet = other.GetComponent<EnemyBullet>();
            
            other.gameObject.SetActive(false);
            other.transform.parent = GameManager.instance.player.transform;
        }
        if(other.gameObject.tag == "Item")
        {
            other.gameObject.SetActive(false);
            other.transform.parent = SkillManager.instance.transform;

            SkillManager.instance.itemObjectPool.Add(other.gameObject);
        }

    }
}
