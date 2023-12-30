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
            // 如果实例为空，创建一个新实例
            if (_instance == null)
            {
                _instance = new GameObject("CheckDeath").AddComponent<CheckDeath>();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        // 如果实例已存在，销毁新创建的实例
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // 如果实例为空，将其设置为当前实例
            _instance = this;
            // 在场景切换时不销毁该对象
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public bool IsDeath = false;

}
