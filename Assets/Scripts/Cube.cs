using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Transform target;
    public static float speed = 1;

    public void AddTarget(Transform target)
    {
        this.target = target;
    }

    void Update()
    {
        if (target != null)
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if ((transform.position - target.position).sqrMagnitude < .1f) gameObject.SetActive(false);
    }
}
