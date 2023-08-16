using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표 : BGM, 폭발, 아이템 사운드 재생
//필요속성 : BGM, 폭발, 아이템 사운드 오디오클립
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
