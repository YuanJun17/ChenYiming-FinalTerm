using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravity : MonoBehaviour
{
    // ��ǰ��������
    private Vector2 currentGravity;
  
    public bool gravitySwitched = false;

    void Start()
    {
        // ��ʼʱ��ȡ��ǰ��������
        currentGravity = Physics2D.gravity;
    }

    void Update()
    {
        // ���������룬����"3"��
        if (Input.GetKeyDown(KeyCode.Alpha3) && !gravitySwitched)
        {
            gravitySwitched = true;
            // �л���������
            SwitchGravity();


        }
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(gravitySwitched)
            {
                gravitySwitched = false;

                // �л���������
                SwitchGravity();
            }
        }
    }

    void SwitchGravity()
    {
        // �л���������
        currentGravity = -currentGravity;
        Physics2D.gravity = currentGravity;
        // ���µߵ���ҽ�ɫ
        transform.Rotate(0, 0, 180);
        
    }
}
