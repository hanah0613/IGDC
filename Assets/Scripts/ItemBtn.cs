using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBtn : MonoBehaviour
{
    public Text itemDisplayer;  

    public string itemName;

    public int level;

    public int currentCost; //아이템의 가격

    public int startCurrentCost = 1;    //아이템의 초기 가격

    public int goldPerSec;          //1초당 증가하는 골드의 양
 
    public int startGoldPerSec = 1; //1초당 증가하는 골드의 초기 양

    public float costPow = 3.14f;   //아이템의 가격 계산에 쓰이는 지수

    public float upgradePow = 1.57f;    //1초당 증가하는 골드의 양 계산에 쓰이는 지수

    public bool isPurchased = false;    //아이템 구매 여부 확인

    void Start()
    {
        DataController.GetInstance().LoadItemBtn(this); //아이템 버튼 로드

        StartCoroutine("AddGoldLoop");                  //아이템 활성화 시작

        UpdateUI();                                     //UI 업데이트
    }

    public void PurchaseItem()                          //아이템 구매
    {
        if(DataController.GetInstance().GetGold()>=currentCost)         //아이템 구매 가능한 경우
        {
            isPurchased = true;
            DataController.GetInstance().SubGold(currentCost);
            level++;

            UpdateItem();
            UpdateUI();

            DataController.GetInstance().SaveItemBtn(this);
        }
    }

    IEnumerator AddGoldLoop()                       //코루틴으로 1초당 일정한 양의 골드 획득
    {
        while(true)
        {
            if(isPurchased)
            {
                DataController.GetInstance().AddGold(goldPerSec);
            }

            yield return new WaitForSeconds(1.0f);

        }  
    }

    public void UpdateItem()                //아이템 구매 후 가격과 골드의 양 업데이트
    {
        goldPerSec = goldPerSec + startGoldPerSec * (int)Mathf.Pow(upgradePow, level);
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
    }

    public void UpdateUI()                  //아이템 구매 후 아이템의 정보 UI 업데이트
    {
        itemDisplayer.text = itemName + "\nLevel: " + level + "\nCost: " + currentCost + "\nGold Per Sec: " + goldPerSec + "\nisPurchased: " + isPurchased;
    }



}
