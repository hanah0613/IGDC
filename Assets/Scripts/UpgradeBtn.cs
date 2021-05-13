using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBtn : MonoBehaviour
{
    public Text upgradeDisplayer;
    public string upgradeName;

    public int goldByUpgrade;           //버튼 클릭 시 획득하는 골드의 양

    public int startGoldByUpgrade = 1;  //버튼 클릭 시 획득하는 골드의 초기 양

    public int currentCost = 1;         //현재 레벨에서의 업그레이트 버튼의 가격

    public int startCurrentCost = 1;    //업그레이트 버튼의 초기 가격

    public int level = 1;               //업그레이드 버튼의 가격

    public float upgradePow = 1.57f;    //업그레이드 될 골드의 양 계산에 쓰이는 지수

    public float costPow = 3.14f;       //업그레이드 버튼 가격 계산에 쓰이는 지수

    void Start()
    {
        DataController.GetInstance().LoadUpgradeBtn(this);  //버튼을 로드
        UpdateUI();                                         //버튼의 정보 표시
    }

    public void PurchaseUpgrade()                           //업그레이드 버튼 구매
    {
        if(DataController.GetInstance().GetGold()>=currentCost)                 //업그레이드 버튼의 가격보다 돈이 많음 - 업그레이드 가능
        {
            DataController.GetInstance().SubGold(currentCost);
            level++;
            DataController.GetInstance().AddGoldPerClick(goldByUpgrade);

            UpdateUpgrade();
            UpdateUI();
            DataController.GetInstance().SaveUpgradeBtn(this);
        }

    }

    public void UpdateUpgrade()                             //구매 후 업그레이드 버튼의 가격 업데이트
    {
        goldByUpgrade = goldByUpgrade + startGoldByUpgrade * (int)Mathf.Pow(upgradePow, level);

        currentCost = startCurrentCost * (int) Mathf.Pow(costPow,level);
    }

    public void UpdateUI()                                  //구매 후 업그레이드 버튼의 정보 업데이트
    {
        upgradeDisplayer.text = upgradeName + "\nCost: " + currentCost + "\nLevel: " + level + "\nNext New GoldPerClick:" + goldByUpgrade;
    }
}