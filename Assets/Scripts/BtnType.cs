using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BTNType currentType;                         //클릭한 버튼의 종류 변수
    public Transform buttonScale;                       //버튼의 크기 변수
    Vector3 defaultScale;                               //버튼의 원래 크기 변수
    bool isSound;                                       //사운드 ON/OFF 상태 변수
    public CanvasGroup mainGroup;                       //캔버스 - 메인메뉴그룹
    public CanvasGroup optionGroup;                     //캔버스 - 옵션메뉴그룹

    private void Start()
    {
        defaultScale = buttonScale.localScale;          //버튼의 크기 초기화
    }

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
            case BTNType.Option:                        //옵션 버튼
                Debug.Log("새 게임");
                CanvasGroupOn(optionGroup);             //옵션메뉴 띄우기
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
                CanvasGroupOff(optionGroup);            //옵션메뉴 끄기
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

    public void OnPointerEnter(PointerEventData eventData)      //커서가 버튼 위에 올려졌을때 실행
    {
        buttonScale.localScale = defaultScale * 1.2f;           //버튼 크기 약간 확대
    }

    public void OnPointerExit(PointerEventData eventData)       //커서가 버튼 위에서 네려갈때 실행
    {
        buttonScale.localScale = defaultScale;                  //버튼 크기 초기화
    }  
}
