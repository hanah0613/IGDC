//주석달기
//코드 최적화
//리셋 방식 - 배열로 바꾸기


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    private static DataController instance;

    public static DataController GetInstance()      //DataController 싱글톤
    {
        if(instance == null)
        {
            instance = FindObjectOfType<DataController>();

            if(instance == null)
            {
                GameObject container = new GameObject("DataController");

                instance = container.AddComponent<DataController>();
            }
        }
        return instance;
    }

    private int m_gold = 0;             //사용자가 보유한 골드 양

    private int m_goldPerClick = 0;     //사용자가 클릭 시 획득하는 골드의 양

    void Awake()
    {
        m_gold = PlayerPrefs.GetInt("Gold");        //보유한 골드의 양 불러오기
        m_goldPerClick = PlayerPrefs.GetInt("GoldPerClick",1);  //클릭 시 획득하는 골드의 양 불러오기
    }

    public void SetGold (int newGold)       //골드 Set
    {
        m_gold = newGold;
        PlayerPrefs.SetInt("Gold", m_gold);
    }
       
    public void AddGold(int newGold)        //골드 추가
    {
        m_gold += newGold;
        SetGold(m_gold);
    }

    public void SubGold(int newGold)        //골드 감소
    {
        m_gold -= newGold;
        SetGold(m_gold);
    }

    public int GetGold()                    //골드의 양 확인
    {
        return m_gold;
    }

    public int GetGoldPerClick()            //클릭-획득 골드의 양 확인
    {
        return m_goldPerClick;
    }

    public void SetGoldPerClick(int newGoldPerClick)    //클릭-획득 골드의 양 Set
    {
        m_goldPerClick = newGoldPerClick;
        PlayerPrefs.SetInt("GoldPerClick", m_goldPerClick);
    }

    public void AddGoldPerClick(int newGoldPerClick)    //클릭-획득 골드의 양 추가
    {
        m_goldPerClick += newGoldPerClick;
        SetGoldPerClick(m_goldPerClick);
    }

    public void LoadUpgradeBtn(UpgradeBtn upgradeBtn)   //업그레이드 버튼 로드
    {
        string key = upgradeBtn.upgradeName;

        upgradeBtn.level = PlayerPrefs.GetInt(key + "_level",1);
        upgradeBtn.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradeBtn.startGoldByUpgrade);
        upgradeBtn.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradeBtn.startCurrentCost);

    }

    public void SaveUpgradeBtn(UpgradeBtn upgradeBtn)   //업그레이드 버튼 저장
    {
        string key = upgradeBtn.upgradeName;

        PlayerPrefs.SetInt(key + "_level", upgradeBtn.level);
        PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradeBtn.goldByUpgrade);
        PlayerPrefs.SetInt(key + "_cost", upgradeBtn.currentCost);
    }

    public void LoadItemBtn(ItemBtn itemBtn)            //아이템 버튼 로드
    {
        string key = itemBtn.itemName;

        itemBtn.level = PlayerPrefs.GetInt(key + "_level", 1);
        itemBtn.goldPerSec = PlayerPrefs.GetInt(key + "_goldPerSec");
        itemBtn.currentCost = PlayerPrefs.GetInt(key + "_cost", itemBtn.startCurrentCost);

        if(PlayerPrefs.GetInt(key+"_isPurchased")==1)   //아이템 버튼 구매 여부
        {
            itemBtn.isPurchased = true;
        }
        else
        {
            itemBtn.isPurchased = false;
        }
    }

    public void SaveItemBtn(ItemBtn itemBtn)        //아이템 버튼 저장
    {
        string key = itemBtn.itemName;

        PlayerPrefs.SetInt(key + "_level", itemBtn.level);
        PlayerPrefs.SetInt(key + "_goldPerSec", itemBtn.goldPerSec);
        PlayerPrefs.SetInt(key + "_cost", itemBtn.currentCost);

        if (itemBtn.isPurchased == true)
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 1);
        }
        else
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 0);
        }
    }

    public void ResetAll()  //유저를 새로 만들때 리셋하는 부분
    {
        SetGold(0);
        SetGoldPerClick(1);

        string key = "Head";

        PlayerPrefs.SetInt(key + "_level", 1);
        PlayerPrefs.SetInt(key + "_goldByUpgrade", 1);
        PlayerPrefs.SetInt(key + "_cost", 1);


        key = "Auto Gold Miner";

        PlayerPrefs.SetInt(key + "_level", 1);
        PlayerPrefs.SetInt(key + "_goldPerSec", 1);
        PlayerPrefs.SetInt(key + "_cost", 1);
        PlayerPrefs.SetInt(key + "_isPurchased", 0);
    }

}

