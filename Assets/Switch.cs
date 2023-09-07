using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class Switch : MonoBehaviour, IInteractable
{
    [SerializeField] UnityEvent _onUsed;
    [SerializeField] AudioMixer _mixer;

    bool _isOpen;

    private void Start()
    {
        _mixer.SetFloat("cutoff", 400);
    }

    public void Use()
    {
        _onUsed.Invoke();
        if (_isOpen == false)
        {
            _mixer.SetFloat("cutoff", 22000);
            _isOpen = true;
        }
        else
        {
            _mixer.SetFloat("cutoff", 400);
            _isOpen = false;
        }

    }


}