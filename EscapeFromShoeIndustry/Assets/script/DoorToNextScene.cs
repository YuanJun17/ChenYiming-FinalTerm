using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextScene : MonoBehaviour
{

    // 当前场景在Build Settings中的索引
    private int currentSceneIndex;

    // 用于计算下一个场景的索引的偏移量
    public int sceneIndexOffset = 1;

    // 当玩家与门碰撞时调用的方法
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查碰撞的物体是否是玩家
        if (other.CompareTag("Player"))
        {
            // 获取当前场景的信息
            Scene currentScene = SceneManager.GetActiveScene();
            currentSceneIndex = currentScene.buildIndex;

            // 计算下一个场景的索引
            int nextSceneIndex = currentSceneIndex + sceneIndexOffset;

            // 加载下一个场景
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}

