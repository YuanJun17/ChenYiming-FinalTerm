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
        // 监听用户输入，按下R键时重新加载场景
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }
    }
    void ReloadScene()
    {
        // 获取当前场景的索引
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // 重新加载当前场景
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1f;
        Physics2D.gravity = new Vector2(0f, -9.8f);
        CheckDeath.Instance.IsDeath = false;
    }
}
