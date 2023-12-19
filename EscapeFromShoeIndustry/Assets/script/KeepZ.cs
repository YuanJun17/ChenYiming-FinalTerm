using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepZ : MonoBehaviour
{
    // 对应的GravitySwitch脚本
    public AntiGravity gravitySwitch;

    private float initialRotationZ;

    void Start()
    {
        // 获取初始的Z轴旋转值
        initialRotationZ = transform.eulerAngles.z;
    }

    void Update()
    {
        KeepRotation();
    }

    void KeepRotation()
    {
        // 获取GravitySwitch脚本中的gravitySwitched值
        bool gravitySwitchedValue = gravitySwitch.gravitySwitched;
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // 根据gravitySwitched值设置Player的Z轴旋转
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
