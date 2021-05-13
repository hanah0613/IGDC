using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour  //게임 화면 속 UI 매니저
{
    public Text goldDisplayer;
    public Text goldPerClickDisplayer;
    public Text nickname;

    void Start()
    {
        nickname.text = PlayerPrefs.GetString("Nickname") + "님 환영합니다!"; //사용자 닉네임 표시
    }

    void Update()
    {
        goldDisplayer.text = "GOLD: " + DataController.GetInstance().GetGold();   //사용자의 골드양 표시
        goldPerClickDisplayer.text = "GOLD PER CLICK: " + DataController.GetInstance().GetGoldPerClick(); //사용자가 클릭 시 획득 할 수 있는 골드의 양 표시
    }
}
