using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    int AnswerType = UIManager.AnswerType;
    string QuestLang = UIManager.selectLang;
    public InputField inputField;
    QuestData questDatas;

    public Text panelText;
    public Text AnswerText;
    public Text Answer;

    public Text[] ClickAnswer3;
    public Text[] ClickAnswer4;

    public Text[] QuestTitle;
    /*
    0 : QuestNumber
    1 : TotalQuestNumber
    2 : Quest Title
    3 : Quest Answer
    4 : Quest LangText
     */

    public GameObject OptionPanel;
    public GameObject[] AnswerOption;
    /*
     0 : InputAnswer
     1 : ClickAnswer 3
     2 : ClickAnswer 4
     3 : TrueOrFalse
     4 : Random 
     */

    int QuestLangID = 1000;
    int QuestIndex = 0;

    private string questText;
    private string questAnswer;

    void Awake()
    {
        questDatas = GetComponent<QuestData>();
    }

    public void Start()
    {
        //AnswerOption[AnswerType - 1].SetActive(true);

        //Random AnswerType
        if ((AnswerType - 1) == 4)
        {
            AnswerOption[Random.Range(0, AnswerOption.Length - 1)].SetActive(true);
        }
        else AnswerOption[AnswerType - 1].SetActive(true);

        //"JavaScript" -> 1000
        convertQuestID();

        //reset
        Reset();

    }

    private void Update()
    {
        //Option 
        if(Input.GetButtonDown("Cancel"))
        {
            OptionPanel.SetActive(!OptionPanel.activeSelf);
            //SceneManager.LoadScene("MenuScene");
        }
    }

    void RandomAnswer()
    {
        //random answer
        foreach (Text item in ClickAnswer3)
        {
            item.text = Random.Range(0, 101).ToString();
        }
        foreach (Text item in ClickAnswer4)
        {
            item.text = Random.Range(0, 101).ToString();
        }

        //answer insert to random index
        ClickAnswer3[Random.Range(0, ClickAnswer3.Length)].text = questAnswer;
        ClickAnswer4[Random.Range(0, ClickAnswer4.Length)].text = questAnswer;
    }

    void printQuest(int id, int index)
    {
        //Answer.text = "정답 : ???";

        //AnswerType == O/X
        if (AnswerOption[3].activeSelf)
        {
            print(questDatas.getTFquestListLength(id) + " " + index);
            //clear codition
            if (questDatas.getTFquestListLength(id) == index)
            {
                panelText.text = "클리어!";
                return;
            }
            //split
            string[] Quest2 = questDatas.getTFquestList(id, index).Split(":");

            //quest contents
            questText = Quest2[0];
            //quest asnwer
            questAnswer = Quest2[1];

            QuestTitle[2].text = "다음 문제를 보고 맞다면 O 틀리면 X를 눌러주세요.";
            panelText.text = questText;
        }
        else
        {
            //clear condition
            if (questDatas.getQuestListLength(id) == index)
            {
                panelText.text = "클리어!";
                return;
            }

            string[] Quest = questDatas.getQuestList(id, index).Split(":");
            questText = Quest[0];
            questAnswer = Quest[1];

            QuestTitle[2].text = questDatas.getQuestTitleList(id, index);
            panelText.text = questText;
            //inputField.contentType = InputField.ContentType.IntegerNumber;

            //Set Random Answer
            RandomAnswer();
        }
    }

    private void Reset()
    {
        QuestIndex = 0;
        questText = "";
        questAnswer = "";
        QuestTitle[4].text = QuestLang;

        //Answer Type == true TotalQuestNum = TFquestListLength
        QuestTitle[1].text = AnswerOption[3].activeSelf ? questDatas.getTFquestListLength(QuestLangID).ToString()
            : questDatas.getQuestListLength(QuestLangID).ToString();
        printQuest(QuestLangID, QuestIndex);
    }

    private void convertQuestID()
    {
        //string -> int
        switch(QuestLang)
        {
            case "JavaScript(JS)":
                QuestLangID = 1000;
            break;
            case "C#":
                QuestLangID = 2000;
            break;
            case "Python":
                QuestLangID = 3000;
            break;
        }
    }

    public void OnAnswerCheck(string input)
    {
        //Answer Check
        if(input.Equals(questAnswer)) {
            Answer.text = questAnswer;
            QuestIndex++;

            //panelText.text = "정답입니다.";
            QuestTitle[0].text = QuestIndex.ToString();
            printQuest(QuestLangID, QuestIndex);
        }
    }

    public void OnInputSubmit(InputField input)
    {
        //Typing Input
        OnAnswerCheck(input.text);
        input.text = "";
        AnswerText.text = "";
    }

    public void OnClickAnswer(Text answerText)
    {
        //Click Input
        OnAnswerCheck(answerText.text);
    }

    public void OnShowAnswer()
    {
        AnswerText.text = "정답은 : " + questAnswer + "이였습니다!!!";
    }

    public void OnOptionClose()
    {
        OptionPanel.SetActive(false);
    }

    public void OnMain()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void OnGameOff()
    {
        Application.Quit();
    }

    IEnumerable TimeDelay()
    {
        yield return new WaitForSecondsRealtime(3.0f);
    }
}
