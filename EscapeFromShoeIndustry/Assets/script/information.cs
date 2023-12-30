using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class information : MonoBehaviour
{
    public CanvasGroup explanationCanvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        HideExplanation();
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        // ����ҽ��봥������ʱ��ʾ˵��
        if (other.CompareTag("Player"))
        {
            ShowExplanation();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // ������뿪��������ʱ����˵��
        if (other.CompareTag("Player"))
        {
            HideExplanation();
        }
    }

    void ShowExplanation()
    {
        // ��ʾ˵�������� CanvasGroup ��͸���Ⱥͻ�����
        explanationCanvasGroup.alpha = 1f;
        explanationCanvasGroup.interactable = true;
        explanationCanvasGroup.blocksRaycasts = true;
    }

    void HideExplanation()
    {
        // ����˵�������� CanvasGroup ��͸���Ⱥͻ�����
        explanationCanvasGroup.alpha = 0f;
        explanationCanvasGroup.interactable = false;
        explanationCanvasGroup.blocksRaycasts = false;
    }
}
