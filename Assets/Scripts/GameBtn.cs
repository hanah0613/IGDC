using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameBtn : MonoBehaviour
{
    public BTNType currentType;                         //클릭한 버튼의 종류 변수
    bool isSound = true;                                       //사운드 ON/OFF 상태 변수
    public CanvasGroup mainGameGroup;  
    public CanvasGroup settingGroup;
    public CanvasGroup millGroup;
    public CanvasGroup shopGroup;

    public void OnBtnClick()                            //버튼을 클릭했을때 실행됨
    {
        switch (currentType)
        {
            case BTNType.Setting:                   //설정 버튼 클릭 시
                CanvasGroupOn(settingGroup);
                CanvasGroupOff(mainGameGroup);
                break;
            case BTNType.Back:                      //닫기 버튼 클릭 시
                CanvasGroupOn(mainGameGroup);
                CanvasGroupOff(settingGroup);
                CanvasGroupOff(millGroup);
                CanvasGroupOff(shopGroup);
                break;
            case BTNType.Mill:                      //방앗간 버튼 클릭 시
                Debug.Log("Mill");
                CanvasGroupOn(millGroup);
                CanvasGroupOff(mainGameGroup);
                break;
            case BTNType.Sound:                     //소리 ON/OFF
                if (isSound)
                {
                    Debug.Log("사운드ON");
                }
                else
                {
                    Debug.Log("사운드OFF");
                }
                isSound = !isSound;
                break;
            case BTNType.Shop:                      //판매 버튼 클릭 시
                CanvasGroupOn(shopGroup);
                CanvasGroupOff(mainGameGroup);
                Debug.Log("Shop");
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
        if (cg == mainGameGroup)
        {
            cg.alpha = 1;
            cg.interactable = true;
            cg.blocksRaycasts = false;
        }
        else
        {
            cg.alpha = 0;
            cg.interactable = false;
            cg.blocksRaycasts = false;
        }
    }
}
