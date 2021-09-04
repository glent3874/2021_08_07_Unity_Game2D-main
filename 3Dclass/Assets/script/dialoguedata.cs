using UnityEngine;

/// <summary>
/// 儲存對話資料, 對話者名稱, 多段對話內容
/// </summary>
//繼承類別改為 ScriptableObject 腳本化物件
//代表此類別內容可以建立物件並儲存於專案內
//須搭配 CreateAssetMenu 建立素材來建立此物件
[CreateAssetMenu(menuName = "LID/對話資料", fileName = "對話資料")]
public class dialoguedata : ScriptableObject
{
    [Header("對話者名稱")]
    public string dialogueTalkerName;
    [Header("對話內容"), TextArea(2, 5)]
    public string[] dialogueContents;
}
