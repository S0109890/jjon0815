using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JAMOSettings : MonoBehaviour
{
    public List<GameObject> JAMOArray = new List<GameObject>();

    public int fontIndexSize;
    public int[] fontIndexArray;
    private int indexCount;
    
    public GameObject[] createFontArray;
    public List<GameObject> allFontArray = new List<GameObject>();

    public float padding = 3f;
    public float posY;

    public bool isSelect = false;
    public bool isSpringColor = false;
    public bool isSummerColor = false;
    public bool isFallColor = false;
    public bool isWinterColor = false;
    public bool isLateSummerColor = false;

    //sm_singletone
    public static JAMOSettings Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        //sm
        //string userName = GameManager.Instance.GetBreakUserName();
        //Debug.Log(userName + "%%%%JAMOSTART");
        //이름 값 받아오기
        string userName = "ㅇㅣㅅㅡㅇㅁㅣㄴ";
        //ᄋㅣᄉㅡᆼᄆㅣᆫ  ᄋㅣᆸᄂㅣᄃㅏ. ᄂㅐ ᄋㅣᄅㅡᆷᄋㅡᆫ ᄋㅣᄉㅡᆼᄒㅜᆫ
        string[] jamoList = { "ㄱ", "ㄴ", "ㄷ", "ㄹ", "ㅁ", "ㅂ", "ㅅ", "ㅇ", "ㅈ", "ㅊ", "ㅋ", "ㅌ",
                "ㅍ", "ㅎ", "ㅃ", "ㅉ", "ㄸ", "ㄲ", "ㅆ", "ㅏ", "ㅑ", "ㅓ", "ㅕ", "ㅗ", "ㅛ", "ㅜ",
                "ㅠ", "ㅣ", "ㅡ", "ㅐ", "ㅒ","ㅔ","ㅖ" };

        fontIndexSize = userName.Length; // 이름의 글자 수
        fontIndexArray = new int[fontIndexSize]; // 글자저장
        createFontArray = new GameObject[fontIndexSize];

        foreach (char c in userName) // 유저네임 받아온거 비교. jamoKeyNumbers 저장
        {
            // jamoList의 몇번째인지.
            int index = System.Array.IndexOf(jamoList, c.ToString());
            Debug.Log("index: "+index);

            fontIndexArray[indexCount] = index;
            indexCount++;
        }
    }

    void Update()
    {
        if (isSelect)
        {
            for (int i = 0; i < fontIndexArray.Length; i++)
            {
                int index = fontIndexArray[i];
                createFontArray[i] = Instantiate(JAMOArray[index]);
                createFontArray[i].transform.position = new Vector3(i * padding, posY, 0);
                allFontArray.Add(createFontArray[i]);
                isSelect = false;
            }
        }
    }

    public enum SeasonColor
    {
        None,
        Spring,
        Summer,
        Fall,
        Winter,
        LateSummer
    }

    public SeasonColor currentSeasonColor = SeasonColor.None;

    public void SetColor(SeasonColor color)
    {
        foreach (var font in allFontArray)
        {
            MeshRenderer mr = font.GetComponent<MeshRenderer>();

            switch (color)
            {
                case SeasonColor.Spring:
                    ColorConfig.Instance.SetSpringColor(mr);
                    break;
                case SeasonColor.Summer:
                    ColorConfig.Instance.SetSummerColor(mr);
                    break;
                case SeasonColor.Fall:
                    ColorConfig.Instance.SetFallColor(mr);
                    break;
                case SeasonColor.Winter:
                    ColorConfig.Instance.SetWinterColor(mr);
                    break;
                case SeasonColor.LateSummer:
                    ColorConfig.Instance.SetLateSummerColor(mr);
                    break;
                default:
                    break;
            }
        }

        currentSeasonColor = SeasonColor.None; // Reset the current color after setting it
    }

}