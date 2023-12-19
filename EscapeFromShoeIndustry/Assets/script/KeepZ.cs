using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepZ : MonoBehaviour
{
    // ��Ӧ��GravitySwitch�ű�
    public AntiGravity gravitySwitch;

    private float initialRotationZ;

    void Start()
    {
        // ��ȡ��ʼ��Z����תֵ
        initialRotationZ = transform.eulerAngles.z;
    }

    void Update()
    {
        KeepRotation();
    }

    void KeepRotation()
    {
        // ��ȡGravitySwitch�ű��е�gravitySwitchedֵ
        bool gravitySwitchedValue = gravitySwitch.gravitySwitched;
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // ����gravitySwitchedֵ����Player��Z����ת
        if (gravitySwitchedValue)
        {
            transform.rotation = Quaternion.Euler(0, currentRotation.y, 180);

        }
        else
        {
            transform.rotation = Quaternion.Euler(0, currentRotation.y, 0);

        }
    }
}
