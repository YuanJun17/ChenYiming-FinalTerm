using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDeath : MonoBehaviour
{
    private static CheckDeath _instance;

    public static CheckDeath Instance
    {
        get
        {
            // ���ʵ��Ϊ�գ�����һ����ʵ��
            if (_instance == null)
            {
                _instance = new GameObject("CheckDeath").AddComponent<CheckDeath>();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        // ���ʵ���Ѵ��ڣ������´�����ʵ��
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // ���ʵ��Ϊ�գ���������Ϊ��ǰʵ��
            _instance = this;
            // �ڳ����л�ʱ�����ٸö���
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public bool IsDeath = false;

}
