using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{
    #region Champs
    [Header("Sources")]
    [SerializeField] AudioSource _source;
    [Header("Clips Audio")]
    [SerializeField] AudioClip[] _audioFight;
    [SerializeField] AudioClip _audioJump;

    public AudioClip AudioJump { get => _audioJump; }
    public AudioClip[] AudioFight { get => _audioFight; }
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    // Update is called once per frame
    #endregion
    #region Methods
    internal void Jump()
    {
        _source.PlayOneShot(_audioJump);
    }

    internal void Attack(int number)
    {
        _source.PlayOneShot(AudioFight[number-1]);
    }
    #endregion
    #region Coroutines
    #endregion
}
