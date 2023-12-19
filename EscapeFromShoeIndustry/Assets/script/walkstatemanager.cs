using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkstatemanager : MonoBehaviour
{
    public Animator anim;

    public nomalwalk script1;
    //public antigrav script3;
    public ironwalk script2;

    private void Start()
    {
        script1.enabled = true;
        script2.enabled = false;
    }
    void Update()
    {
        // 检测键盘输入，按下"1"键
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // 启用脚本1，禁用脚本2
            EnableScript1();
            anim.SetTrigger("normal");
        }

        // 检测键盘输入，按下"2"键
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // 启用脚本2，禁用脚本1
            EnableScript2();
            anim.SetTrigger("iron");
        }

        
    }

    void EnableScript1()
    {
        script1.enabled = true;
        script2.enabled = false;
    }

    void EnableScript2()
    {
        script1.enabled = false;
        script2.enabled = true;
    }
}
