using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ : BGM, ����, ������ ���� ���
//�ʿ�Ӽ� : BGM, ����, ������ ���� �����Ŭ��
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource bgmAS;
    public AudioSource effAS;

    public List<AudioClip> bgmAC = new List<AudioClip>();
    public List<AudioClip> explosionAC = new List<AudioClip>();
    public List<AudioClip> itemAC = new List<AudioClip>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
