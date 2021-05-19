using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnType : MonoBehaviour
{
    public BTNType currentType;                         //클릭한 버튼의 종류 변수
    bool isSound;                                       //사운드 ON/OFF 상태 변수
    public CanvasGroup mainGroup;                       //캔버스 - 메인메뉴그룹
    public CanvasGroup settingGroup;                     //캔버스 - 옵션메뉴그룹


    public void OnBtnClick()                            //버튼을 클릭했을때 실행됨
    {
        switch (currentType)
        {
            case BTNType.New:                           //새게임 버튼
                Debug.Log("새 게임");
                break;
            case BTNType.Continue:                      //새게임 버튼
                Debug.Log("새 게임");
                Debug.Log("불러오기");
                break;
            case BTNType.Setting:                        //옵션 버튼
                Debug.Log("새 게임");
                CanvasGroupOn(settingGroup);             //옵션메뉴 띄우기
                CanvasGroupOff(mainGroup);              //메인메뉴 끄기
                Debug.Log("옵션");
                break;
            case BTNType.Sound:                         //사운드 버튼
                if(isSound)
                {
                    Debug.Log("사운드ON");
                }
                else
                {
                    Debug.Log("사운드OFF");
                }
                isSound = !isSound;
                break;
            case BTNType.Back:                          //뒤로가기 버튼
                CanvasGroupOn(mainGroup);               //메인메뉴 띄우기
                CanvasGroupOff(settingGroup);            //옵션메뉴 끄기
                Debug.Log("뒤로가기");
                break;
            case BTNType.Quit:                          //게임종료 버튼
                Application.Quit();
                Debug.Log("게임종료");
                break;
        }
    }

    public void CanvasGroupOn(CanvasGroup cg)           //캔버스그룹 띄우기
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    public void CanvasGroupOff(CanvasGroup cg)          //캔버스그룹 끄기
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
}
