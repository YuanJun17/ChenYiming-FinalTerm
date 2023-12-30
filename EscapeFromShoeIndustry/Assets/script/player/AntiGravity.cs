using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravity : MonoBehaviour
{
    // 当前重力方向
    private Vector2 currentGravity;
  
    public bool gravitySwitched = false;

    void Start()
    {
        // 初始时获取当前重力方向
        currentGravity = Physics2D.gravity;
    }

    void Update()
    {
        // 检测键盘输入，按下"3"键
        if (Input.GetKeyDown(KeyCode.Alpha3) && !gravitySwitched)
        {
            gravitySwitched = true;
            // 切换重力方向
            SwitchGravity();


        }
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(gravitySwitched)
            {
                gravitySwitched = false;

                // 切换重力方向
                SwitchGravity();
            }
        }
    }

    void SwitchGravity()
    {
        // 切换重力方向
        currentGravity = -currentGravity;
        Physics2D.gravity = currentGravity;
        // 上下颠倒玩家角色
        transform.Rotate(0, 0, 180);
        
    }
}
