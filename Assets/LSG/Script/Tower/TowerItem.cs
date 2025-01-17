using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerItem : MonoBehaviour
{
   
   //이거는 담기는 아이템에 넣을 데이터로 쳐야하나
    public string ID { get; set; }
    protected int Lv = 0;  //레벨
    protected int MaxLv = 100;  //레벨
    public double effect { get; set; }//착용효과
    public double increase  { get; set; }
    public double RetentionEffect { get; set; } //보유효과
    public double RetentionIncrease { get; set; }
    public int ItemCount { get; set; }
    public bool Ative { get; set; }
    public bool ChoiceItem { get; set; }

    Text LvText;
    //Text Count;
    //int Maxnum = 4;

    private Button MyButton;
    private Button[] InfoButton;
    protected void initData()
    {
        Lv = 1;
        // 아이디, 증가값, 효과는 인스펙터창에서
        //StartCoroutine()

        LvText = GetComponentInChildren<Text>();
        LvText.text = "ID : " + ID;
        //this.transform.SetAsLastSibling(); //이미지 먼저
        Info = InfoPlane.transform.GetChild(1).GetComponent<Text>(); //2번째 자식

        MyButton = this.GetComponent<Button>();
        if (Ative && Lv != 100) //info버튼 활성화기능
        {
            MyButton.interactable = true;
        }
        else
        {
            MyButton.interactable = false; //버튼 비활성화 상태
        }
        InfoPlane.SetActive(false);
        InfoButton = InfoPlane.transform.GetChild(2).GetComponentsInChildren<Button>();
    }

    public void Print()
    {
        print(ID+" "+ Lv+" "+ effect+" "+ increase+" "+ RetentionEffect+" "+ RetentionIncrease);
    }

    private void Start()
    {
        //처음이라면
        initData();
        //아니라면 유저 데이터 불러오기
        //Print();
        //info버튼 연결해주기
        MyButton.onClick.AddListener(ClickInfoButton);
    }
    public void LevelUP()
    {
        if(Lv < MaxLv)
        {
            Lv++;
            print(ID +" 레벌업 1회");
            effect += increase;
            RetentionEffect += RetentionIncrease;
            
            LvText.text = Lv.ToString();
        }
        else
        {
            effect *= 2;
            RetentionEffect *= 2;
            //모든 효과 두배로 만들고 현재 레벨업 버튼 비활성화 다음 레벨업 버튼 생성
            InfoButton[0].onClick.RemoveListener(LevelUP);
        }
        SetInfo();
    }

    [SerializeField] GameObject InfoPlane;
    Text Info;

    //Test Effect2;
    public void ClickInfoButton()
    {
        InfoPlane.SetActive(true);
        SetInfo();
        InfoButton[0].onClick.AddListener(LevelUP); //레벨업 버튼 연결
        //착용도 작업해야함
    }

    void SetInfo()
    {
        if (ID[0] == 'C')
        {
            //캐논
            Info.text = "Lv : " + Lv + '\n' + " 착용 공격력 : " + effect + '\n' + " 보유 공격력 : " + RetentionEffect;
        }
        else
        {
            //수리공
            Info.text = "Lv : " + Lv + '\n' + "체력 : " + effect + '\n' + " 보유 체력 : " + RetentionEffect;
        }
    }
    
}
