using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBehavior : MonoBehaviour
{
    private const string IsTrigger = "isTrigger";
    private Animator _animator;

    private void OnEnable()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void ChangeBool()
    {
        if (_animator.GetBool(IsTrigger))
        {
            _animator.SetBool(IsTrigger, false);
        }
        else
        {
            _animator.SetBool(IsTrigger, true);
        }
    }
}
