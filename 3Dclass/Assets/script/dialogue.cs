using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// �M�w���ܪ̪��W��, �h�q���e, ������ܪ��ϥܮĪG
/// </summary>

public class dialogue : MonoBehaviour
{
    #region ���
    [Header("��ܸ��")]
    public dialoguedata data;
    [Header("��ܶ��j"), Range(0, 3)]
    public float interval = 0.2f;
    [Header("��ܧ����ϥ�")]
    public GameObject gonFinishIcon;
    [Header("��r����:���ܪ̦W��, ��ܤ�r���e")]
    public Text textTalker;
    public Text textContent;

    /// <summary>
    /// ��ܨt�εe��: �s�դ���
    /// </summary>
    private CanvasGroup groupDialogue;

    [Header("�~���ܪ�����")]
    public KeyCode kcContinue = KeyCode.Space;
    [Header("���r����")]
    public AudioClip soundType;
    [Header("���r���q"), Range(0, 2)]
    public float volume = 1;
    #endregion

    private AudioSource aud;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
        groupDialogue = transform.GetChild(0).GetComponent<CanvasGroup>();
        StartDialogue();
    }

    private void StartDialogue()
    {
        StartCoroutine(ShowEveryDialogue());
    }

    private IEnumerator ShowEveryDialogue()
    {
        groupDialogue.alpha = 1;
        textTalker.text = data.dialogueTalkerName;
        textContent.text = "";

        //�j�����C�@�Ӭq��
        for(int i = 0; i < data.dialogueContents.Length; i++)
        {
            //�j�����C�Ӭq�������C�@��r
            for(int j = 0; j < data.dialogueContents[i].Length; j++)
            {
                textContent.text += data.dialogueContents[i][j];
                aud.PlayOneShot(soundType, volume);
                yield return new WaitForSeconds(interval);
            }

            gonFinishIcon.SetActive(true);

            //���ݪ��a���~����s, �ϥ� null ���C�����ɶ�
            while (!Input.GetKeyDown(kcContinue))
            {
                yield return null;
            }

            textContent.text = "";
            gonFinishIcon.SetActive(false);

            if(i == data.dialogueContents.Length - 1)
            {
                groupDialogue.alpha = 0;
            }
        }
    }
}
