using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountLeft : MonoBehaviour
{
    public Text transformCountText;  // ����UI Text ���
    public int transformCount;  // ��ʼ�任����
    private KeyCode lastPressedKey;   // ��һ�ΰ��µļ�

    public CanvasGroup reportCanvasGroup;  // ���� Canvas Group ���

    void Start()
    {
        // �ڿ�ʼʱ���� UI
        UpdateUIText();
        UpdateReportVisibility();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            // ��ȡ��ǰ���µļ�
            KeyCode pressedKey = KeyCode.None;
            if (Input.GetKeyDown(KeyCode.Alpha1))
                pressedKey = KeyCode.Alpha1;
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                pressedKey = KeyCode.Alpha2;
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                pressedKey = KeyCode.Alpha3;

            // ����Ƿ�����һ�ΰ��µļ���ͬ
            if (pressedKey != lastPressedKey)
            {
                // �����²�ͬ�ļ�ʱ�����ٱ任����
                ReduceTransformCount();

                // ������һ�ΰ��µļ�
                lastPressedKey = pressedKey;
            }
        }

        if (CheckDeath.Instance.IsDeath)
        {
            // ��Ϸ��ͣʱ��ʾ "report" Ԫ��
            reportCanvasGroup.alpha = 1f; // ����͸����Ϊ��͸��
            reportCanvasGroup.interactable = true; // ���û�����
        }
        else
        {
            // ��Ϸδ��ͣʱ���� "report" Ԫ��
            reportCanvasGroup.alpha = 0f; // ����͸����Ϊ͸��
            reportCanvasGroup.interactable = false; // ���û�����
        }
    }

    // ���ٱ任���������� UI
    void ReduceTransformCount()
    {
        if (transformCount >= 0)
        {
            transformCount--;

            // ������ִ�и��� UI ���߼�
            UpdateUIText();

            Debug.Log("Remaining transform count: " + transformCount);
            if (transformCount < 0)
            {
                // ���任����Ϊ 0 ʱ��ͣ��Ϸ
                PauseGame();
                CheckDeath.Instance.IsDeath = true;
            }
        }
    }

    // ���� UI Text ��ʾ
    void UpdateUIText()
    {
        // ���� UI Text ��ʾΪ "ʣ��任������X"
        transformCountText.text = transformCount.ToString();
    }
    void UpdateReportVisibility()
    {
        // ������Ϸ��ͣ״̬���� "report" Ԫ�صĿɼ���
        reportCanvasGroup.alpha = (Time.timeScale == 0f) ? 1f : 0f; // ����͸����
        reportCanvasGroup.interactable = (Time.timeScale == 0f); // ���û�����
    }
    void PauseGame()
    {
        Time.timeScale = 0f;
        Debug.Log("Game Paused");
        
        UpdateReportVisibility();
    }
}
