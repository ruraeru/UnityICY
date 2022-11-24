using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : MonoBehaviour
{
    public string questLang = UIManager.selectLang;
    public Dictionary<int, string[]> questList;
    public Dictionary<int, string[]> questTitleList;
    public Dictionary<int, string[]> TFquestList;
    public string[] QuestDataTxT;


    void Awake()
    {
        QuestDataTxT = System.IO.File.ReadAllText("/Users/xodn_ghkd/ICY(InputYourCode)/Assets/QuestFile/QuestData.txt").Split("|");

        questList = new Dictionary<int, string[]>();
        questTitleList = new Dictionary<int, string[]>();
        TFquestList = new Dictionary<int, string[]>();

        //JavaScript : 1000
        questTitleList.Add(1000, new string[]
        {
            "#1. 코드의 실행 결과를 입력해주세요.",
            "#2. 코드의 실행 결과를 입력해주세요.",
            "#3. 다음 코드는 몇초 후에 실행될까요?"
        });
        questList.Add(1000, new string[]
        {
            QuestDataTxT[0],
            QuestDataTxT[1],
            QuestDataTxT[2]
            //"let sum = 0;\n\nfor(let i = 1; i <= 10; i++) {\n\tsum+=i;\n}:55",
            //"let arr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];\narr.map((num) => {\n\tnum+1;\n}):65",
            //"setTimeout(() => {\n\tconsole.log('Hello');\n}, 3000);:3"
        });
        //OX
        TFquestList.Add(1000, new string[]
        {
            "자바스크립트는 변수 타입이 존재한다.:X",
            "화살표 함수는 재사용 가능하다.:X"
        });

        //C# : 2000
        questTitleList.Add(2000, new string[]
        {
            "#1. 배열 a의 값은?",
            "#2. 코드의 출력 결과는?"
        });
        questList.Add(2000, new string[]
        {
            "int[] a = new int[]{1, 2, 3};\na[0] = 2;:223",
            "Console.WriteLine('Hello World'):Hello World"
        });;
        TFquestList.Add(2000, new string[]
        {
            "C#은 .NET 프레임워크를 지원한다.:O",
            "C#은 저급언어다.:X",
            "C#은 클래스 다중상속이 가능하다.:X",
            "C#은 인터페이스 다중 상속이 가능하다.:O"
        });

        //Python : 3000
        questTitleList.Add(3000, new string[]
        {
            "#1. phone_number의 값은?",
            "#2. 다음 출력 결과는?"
        });
        questList.Add(3000, new string[]
        {
            "phone_number = '010-1111-2222'\nprint(phone_number.replace('-', ''):01011112222",
            "print('naver', 'kakao', 'samsung', sep=';'):naver;kakao;samsung"
        });
        TFquestList.Add(3000, new string[]
        {
            "파이썬 소스파일 확장자 명은 .py다:O",
            "파이썬은 컴파일러 언어이다.:X"
        });
    }

    public int getQuestListLength(int key)
    {
        return questList[key].Length;
    }

    public string getTFquestList(int key, int index)
    {
        return TFquestList[key][index];
    }

    public int getTFquestListLength(int key)
    {
        return TFquestList[key].Length;
    }

    public string getQuestList(int key, int index)
    {
        return questList[key][index];
    }

    public string getQuestTitleList(int key, int index)
    {
        return questTitleList[key][index];
    }

}
