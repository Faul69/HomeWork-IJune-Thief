using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBehaiour : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool _isInvoke;

    private void OnEnable()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _audioSource.loop = true;
        _audioSource.volume = 0;
        _isInvoke = false;
    }

    public void SetVoulume()
    {
        if (_isInvoke)
        {
            StartCoroutine(routine: VolumeLower());
            _isInvoke = false;
        }
        else
        {
            _audioSource.volume = 1;
            _isInvoke = true;
        }
    }

    private IEnumerator VolumeLower()
    {
        while (_audioSource.volume > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0, 1 * Time.deltaTime);
        }

        yield return null;
    }
}
