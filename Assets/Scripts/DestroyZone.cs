using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ : �� �Ǵ� �Ѿ��� �����Ǿ��� ���, �� ��ü�� �ı��Ѵ�.
public class DestroyZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if((other.gameObject.tag == "Player"))
        {
            return;
        }
        Destroy(other.gameObject);
    }
}
