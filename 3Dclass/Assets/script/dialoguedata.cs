using UnityEngine;

/// <summary>
/// �x�s��ܸ��, ��ܪ̦W��, �h�q��ܤ��e
/// </summary>
//�~�����O�אּ ScriptableObject �}���ƪ���
//�N�����O���e�i�H�إߪ�����x�s��M�פ�
//���f�t CreateAssetMenu �إ߯����ӫإߦ�����
[CreateAssetMenu(menuName = "LID/��ܸ��", fileName = "��ܸ��")]
public class dialoguedata : ScriptableObject
{
    [Header("��ܪ̦W��")]
    public string dialogueTalkerName;
    [Header("��ܤ��e"), TextArea(2, 5)]
    public string[] dialogueContents;
}
