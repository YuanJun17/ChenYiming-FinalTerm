using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextScene : MonoBehaviour
{

    // ��ǰ������Build Settings�е�����
    private int currentSceneIndex;

    // ���ڼ�����һ��������������ƫ����
    public int sceneIndexOffset = 1;

    // �����������ײʱ���õķ���
    private void OnTriggerEnter2D(Collider2D other)
    {
        // �����ײ�������Ƿ������
        if (other.CompareTag("Player"))
        {
            // ��ȡ��ǰ��������Ϣ
            Scene currentScene = SceneManager.GetActiveScene();
            currentSceneIndex = currentScene.buildIndex;

            // ������һ������������
            int nextSceneIndex = currentSceneIndex + sceneIndexOffset;

            // ������һ������
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}

