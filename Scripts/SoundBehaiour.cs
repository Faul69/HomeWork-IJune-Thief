using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBehaiour : MonoBehaviour
{
    private const int MinVolume = 0;
    private const int MaxVolume = 1;

    private AudioSource _audioSource;
    private bool _isInvoke;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = true;
        _audioSource.volume = MinVolume;
        _isInvoke = false;
    }

    public void SetVoulume()
    {
        if (_isInvoke)
        {
            StartCoroutine(routine: ChangeVolumeTo(MinVolume));
            _isInvoke = false;
        }
        else
        {
            StartCoroutine(routine: ChangeVolumeTo(MaxVolume));
            _isInvoke = true;
        }
    }

    private IEnumerator ChangeVolumeTo(int targetVolum)
    {
        while (_audioSource.volume != targetVolum)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolum, 1 * Time.deltaTime);
        }

        yield return null;
    }
}
