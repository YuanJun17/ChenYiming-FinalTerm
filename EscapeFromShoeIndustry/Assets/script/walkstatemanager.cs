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
        // ���������룬����"1"��
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // ���ýű�1�����ýű�2
            EnableScript1();
            anim.SetTrigger("normal");
        }

        // ���������룬����"2"��
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // ���ýű�2�����ýű�1
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
