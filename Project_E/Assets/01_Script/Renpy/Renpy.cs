using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Renpy : MonoBehaviour
{
    [SerializeField] Image BG;  // 배경
    [SerializeField] Image[] Character;   //캐릭터

    [SerializeField] TextMeshProUGUI Text_Name;    // 캐릭터 이름 : 도로롱
    [SerializeField] TextMeshProUGUI Text_NameTitle;   //캐릭터 타이틀 : 갓데스 스쿼드
    [SerializeField] TextMeshProUGUI Text_Dialogue;    // 대사 : 여기에 출력


    int id = 1; // 대사 ID, 1부터 시작

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
        int characterID = SData.GetDialogueData(id).Character; // 대사 테이블의 2번 ID의 캐릭터 ID를 가져옴
        Text_Name.text = SData.GetCharacterData(characterID).Name; // 캐릭터 테이블에서 이름을 가져옴
        Text_NameTitle.text = SData.GetCharacterData(characterID).Title; // 캐릭터 테이블에서 타이틀을 가져옴
        Text_Dialogue.text = SData.GetDialogueData(id).Dialogue;

        BG.sprite = Resources.Load<Sprite>("Img/BG/" + SData.GetDialogueData(id).BG); // 대사 테이블의 2번 ID의 배경을 가져옴

        for (int i = 0; i < Character.Length; i++)
        {
            Character[i].gameObject.SetActive(false);
        }

       
            for (int i = 0; i < Character.Length; i++)
            {

                if (i == SData.GetDialogueData(id).Position)
                {
                    Character[i].sprite = Resources.Load<Sprite>("Img/Char/" + SData.GetCharacterData(SData.GetDialogueData(id).Character).Image); // 캐릭터 테이블에서 이미지 이름을 가져옴
                    Character[i].gameObject.SetActive(true); // 캐릭터 이미지 활성화
                }
              
            }
        }
    
   

}
