using UnityEngine;

public class StoryController : MonoBehaviour
{
    public CanvasGroup[] images; // ��Inspector�н�����ͼƬ��CanvasGroup��ק������
    public float fadeInDuration; // ͼƬ�����ʱ��
    public float fadeOutDuration; // ͼƬ������ʱ��
    public float delayBetweenImages; // ÿ��ͼƬ֮����ӳ�ʱ��

    private void Start()
    {
        // ��ʼʱ��������ͼƬ
        foreach (var image in images)
        {
            image.alpha = 0f;
        }

        // ����Э���Կ���ͼƬ�ĳ��ֺ���ʧ
        StartCoroutine(ShowImagesSequence());
    }

    private System.Collections.IEnumerator ShowImagesSequence()
    {
        foreach (var image in images)
        {
            // ����
            yield return FadeIn(image, fadeInDuration);

            // �ӳ�һ��ʱ��
            yield return new WaitForSeconds(delayBetweenImages);

            // ����
            yield return FadeOut(image, fadeOutDuration);
        }
    }

    private System.Collections.IEnumerator FadeIn(CanvasGroup canvasGroup, float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1f;
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
