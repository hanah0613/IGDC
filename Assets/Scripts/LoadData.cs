using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadData : MonoBehaviour
{
    [SerializeField]
    Text nickName;      //사용자의 닉네임을 보여주는 텍스트

    public void Load()  //사용자의 데이터를 로드하여 보여줌
    {
        nickName.text = PlayerPrefs.GetString("Nickname")+"님 환영합니다!";
    }

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
