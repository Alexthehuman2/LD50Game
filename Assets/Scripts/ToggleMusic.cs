using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMusic : MonoBehaviour
{
    [SerializeField] private AudioSource bgMusic;
    
    public void turnMusicOn()
    {
        bgMusic.volume = 0.15f;
    }
}
