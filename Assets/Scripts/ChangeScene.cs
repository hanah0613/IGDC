using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneBtn()    //버튼을 눌렀을때 씬을 전환하는 함수
    {
        switch(this.gameObject.name)    //버튼의 이름을 사용하여 씬 전환
        {
            case "NewBtn":  //유저를 만드는 씬으로 이동
                SceneManager.LoadScene("MakeUser");
                break;
            case "StartBtn":    //게임을 플레이 하는 씬으로 이동
            case "ContinueBtn": //게임을 플레이 하는 씬으로 이동
                SceneManager.LoadScene("PlayGame");
                break;
            case "BackBtn":     //메인씬으로 이동
                SceneManager.LoadScene("Main");
                break;
        }
    }
}
