using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeUser : MonoBehaviour
{
    [SerializeField]
    InputField inputField;  //닉네임을 입력받는 인풋 필드

    public void Save()      //닉네임 저장
    {
        PlayerPrefs.SetString("Nickname", inputField.text);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
