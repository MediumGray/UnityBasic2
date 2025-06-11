using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Renpy : MonoBehaviour
{
    [SerializeField] Image BG;  // ���
    [SerializeField] Image[] Character;   //ĳ����

    [SerializeField] TextMeshProUGUI Text_Name;    // ĳ���� �̸� : ���η�
    [SerializeField] TextMeshProUGUI Text_NameTitle;   //ĳ���� Ÿ��Ʋ : ������ ������
    [SerializeField] TextMeshProUGUI Text_Dialogue;    // ��� : ���⿡ ���


    int id = 1; // ��� ID, 1���� ����

    void Start()
    {
        RefreshUI();

    }

    public void OnClickButton()
    {
        id++; //2
        RefreshUI();

    }

    void RefreshUI()
    {
        int characterID = SData.GetDialogueData(id).Character; // ��� ���̺��� 2�� ID�� ĳ���� ID�� ������
        Text_Name.text = SData.GetCharacterData(characterID).Name; // ĳ���� ���̺��� �̸��� ������
        Text_NameTitle.text = SData.GetCharacterData(characterID).Title; // ĳ���� ���̺��� Ÿ��Ʋ�� ������
        Text_Dialogue.text = SData.GetDialogueData(id).Dialogue;

        BG.sprite = Resources.Load<Sprite>("Img/BG/" + SData.GetDialogueData(id).BG); // ��� ���̺��� 2�� ID�� ����� ������

        for (int i = 0; i < Character.Length; i++)
        {
            Character[i].gameObject.SetActive(false);
        }

       
            for (int i = 0; i < Character.Length; i++)
            {

                if (i == SData.GetDialogueData(id).Position)
                {
                    Character[i].sprite = Resources.Load<Sprite>("Img/Char/" + SData.GetCharacterData(SData.GetDialogueData(id).Character).Image); // ĳ���� ���̺��� �̹��� �̸��� ������
                    Character[i].gameObject.SetActive(true); // ĳ���� �̹��� Ȱ��ȭ
                }
              
            }
        }
    
   

}
