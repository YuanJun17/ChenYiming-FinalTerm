using UnityEngine;

public class ImageDisappear : MonoBehaviour
{
    public CanvasGroup imageCanvasGroup; // ��Inspector�н�ͼƬ��CanvasGroup��ק������
    public float customDisappearTime;
    void Start()
    {
        // ��ʼʱ����ͼƬ
        imageCanvasGroup.alpha = 1f;

        // �Զ������ʧʱ�䣬����3��
        

        // ����Э�������Զ����ʱ��󵭳�ͼƬ
        StartCoroutine(DisappearAfterDelay(customDisappearTime));
    }

    private System.Collections.IEnumerator DisappearAfterDelay(float delay)
    {
        // �ȴ�ָ�����ӳ�ʱ��
        yield return new WaitForSeconds(delay);

        // ����ͼƬ
        yield return FadeOut(imageCanvasGroup, 1f);
    }

    private System.Collections.IEnumerator FadeOut(CanvasGroup canvasGroup, float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0f;
    }
}
