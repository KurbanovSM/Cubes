using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    private Vector3 DefaultPosition;
    private const float AUXILIARY_MULTIPLIER = 5;
    private void Awake()
    {
        DefaultPosition = transform.position;
    }

    public void ChangePosition(float number)
    {
        transform.position = DefaultPosition + transform.forward * number * AUXILIARY_MULTIPLIER;
    }
}
