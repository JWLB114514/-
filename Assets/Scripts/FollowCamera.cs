using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public float smooth = 5f;
    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 pos = target.position;
            pos.z = transform.position.z; // z轴不动
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * smooth);
        }
    }
}