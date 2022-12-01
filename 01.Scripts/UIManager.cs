using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

    public class UIManager : MonoBehaviour
{
    public static string selectLang = "JavaScript(JS)";
    public static int AnswerType = 1;

    public Text selectLangText;
        
    public GameObject MenuPanel;
    public GameObject ChangeLang;
    public GameObject OptionPanel;
    public GameObject AnswerOptionPanel;

    public void OnSelectAnswerType(Dropdown answerType)
    {
        AnswerType = answerType.value;
    }

    public void OnSelectLang(Dropdown langList)
    {
        selectLang = langList.options[langList.value].text;

        switch (langList.value)
        {
            case 0:
                print("언어를 선택해주세요.");
                break;
            case 1:
            case 2:
            case 3:
                print("언어를 " + selectLang + "로 변경되었습니다.");
                selectLangText.text = "선택한 언어 : " + selectLang;
                break;
        }
    }

    public void OnGameStart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnOptionShow()
    {
        MenuPanel.SetActive(false);
        OptionPanel.SetActive(true);
    }

    public void OnOptionClose()
    {
        MenuPanel.SetActive(true);
        ChangeLang.SetActive(false);
        OptionPanel.SetActive(false);
        AnswerOptionPanel.SetActive(false);
        print(selectLang);
        print(AnswerType);
    }

    public void OnLangOptionShow()
    {
        OptionPanel.SetActive(false);
        ChangeLang.SetActive(true);
    }

    public void OnAnswerOptionShow()
    {
        OptionPanel.SetActive(false);
        AnswerOptionPanel.SetActive(true);
    }

    public void OnExitGame()
    {
        Application.Quit();
    }
}
