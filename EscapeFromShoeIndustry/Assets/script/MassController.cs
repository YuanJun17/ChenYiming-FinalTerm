using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassController : MonoBehaviour
{
    public walkstatemanager iron;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �����ײ�Ƿ������
        if (collision.gameObject.CompareTag("Player")&& iron.script2.enabled)
        {
            // ����ײ����ʱ���������������������Ϊ1
            GetComponent<Rigidbody2D>().mass = 1f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // �����ײ�Ƿ������
        if (collision.gameObject.CompareTag("Player"))
        {
            // ����ײ����ʱ���������������������Ϊ1000
            GetComponent<Rigidbody2D>().mass = 1000f;
        }
    }
}
