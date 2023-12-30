using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �����û����룬����R��ʱ���¼��س���
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }
    }
    void ReloadScene()
    {
        // ��ȡ��ǰ����������
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ���¼��ص�ǰ����
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1f;
        Physics2D.gravity = new Vector2(0f, -9.8f);
        CheckDeath.Instance.IsDeath = false;
    }
}
