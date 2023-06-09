using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventHehlper : MonoBehaviour
{
    public UnityEvent OnAnimationEventTriggered, OnAttackPerfomed;

    public void TriggerEvent()
    {
        OnAnimationEventTriggered?.Invoke();
    }
    public void TriggerAttack()
    {
        OnAttackPerfomed?.Invoke();
    }
}
