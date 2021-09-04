using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// 決定說話者的名稱, 多段內容, 完成對話的圖示效果
/// </summary>

public class dialogue : MonoBehaviour
{
    #region 欄位
    [Header("對話資料")]
    public dialoguedata data;
    [Header("對話間隔"), Range(0, 3)]
    public float interval = 0.2f;
    [Header("對話完成圖示")]
    public GameObject gonFinishIcon;
    [Header("文字介面:說話者名稱, 對話文字內容")]
    public Text textTalker;
    public Text textContent;

    /// <summary>
    /// 對話系統畫布: 群組元件
    /// </summary>
    private CanvasGroup groupDialogue;

    [Header("繼續對話的按鍵")]
    public KeyCode kcContinue = KeyCode.Space;
    [Header("打字音效")]
    public AudioClip soundType;
    [Header("打字音量"), Range(0, 2)]
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

        //迴圈執行每一個段落
        for(int i = 0; i < data.dialogueContents.Length; i++)
        {
            //迴圈執行每個段落內的每一單字
            for(int j = 0; j < data.dialogueContents[i].Length; j++)
            {
                textContent.text += data.dialogueContents[i][j];
                aud.PlayOneShot(soundType, volume);
                yield return new WaitForSeconds(interval);
            }

            gonFinishIcon.SetActive(true);

            //等待玩家按繼續按鈕, 使用 null 為每偵的時間
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
