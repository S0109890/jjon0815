using System;
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
        string userName = "ㄹㅔㅇㅗㄴㅏㄹㅡㄷㅗㄷㅏㅂㅣㄴㅊㅣ";
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
            Debug.Log("index: " + index);

            fontIndexArray[indexCount] = index;
            indexCount++;
        }
    }


    /*
    private string[] modelIndex =
    {
    "ㄱ", "ㄴ", "ㄷ", "ㄹ", "ㅁ", "ㅂ", "ㅅ", "ㅇ", "ㅈ", "ㅊ", "ㅋ", "ㅌ", "ㅍ",
    "ㅎ", "ㅃ", "ㅉ", "ㄸ", "ㄲ", "ㅆ", "ㅏ", "ㅑ", "ㅓ", "ㅕ", "ㅗ", "ㅛ", "ㅜ",
    "ㅠ", "ㅣ", "ㅡ", "ㅐ", "ㅒ","ㅔ","ㅖ","a"
};

    public string userName;
    private void OnEnable()
    {
        userName = "ㄹㅔㅇㅗㄴㅏㄹㅡㄷㅗㄷㅏㅂㅣㄴㅊㅣ";
        Debug.Log(userName + "%%%%JAMOSTART");

        fontIndexSize = userName.Length;
        Debug.Log("fontIndexSize  " + fontIndexSize);
        fontIndexArray = new int[fontIndexSize];
        createFontArray = new GameObject[fontIndexSize];

        int indexCount = 0;

        foreach (char c in userName)
        {
            int charCode = (int)c;

            switch (charCode)
            {
                case 0x1100:
                case 0x11A8:
                    fontIndexArray[indexCount++] = Array.IndexOf(modelIndex, "ㄱ");
                    break;
                case 0x1102:
                case 0x11AB:
                    fontIndexArray[indexCount++] = Array.IndexOf(modelIndex, "ㄴ");
                    break;
                case 0x1103:
                case 0x11AE:
                    fontIndexArray[indexCount++] = Array.IndexOf(modelIndex, "ㄷ");
                    break;
                case 0x1105:
                case 0x11AF:
                    fontIndexArray[indexCount++] = Array.IndexOf(modelIndex, "ㄹ");
                    break;
                case 0x1106:
                case 0x11B7:
                    fontIndexArray[indexCount++] = Array.IndexOf(modelIndex, "ㅁ");
                    break;
                case 0x1109:
                case 0x11BA:
                    fontIndexArray[indexCount++] = Array.IndexOf(modelIndex, "ㅅ");
                    break;
                case 0x110B:
                case 0x11BC:
                    fontIndexArray[indexCount++] = Array.IndexOf(modelIndex, "ㅇ");
                    break;
                case 0x110C:
                case 0x11BD:
                    fontIndexArray[indexCount++] = Array.IndexOf(modelIndex, "ㅈ");
                    break;
                case 0x110E:
                case 0x11BE:
                    fontIndexArray[indexCount++] = Array.IndexOf(modelIndex, "ㅊ");
                    break;
                case 0x110F:
                case 0x11BF:
                    fontIndexArray[indexCount++] = Array.IndexOf(modelIndex, "ㅋ");
                    break;
                case 0x1110:
                case 0x11C0:
                    fontIndexArray[indexCount++] = Array.IndexOf(modelIndex, "ㅌ");
                    break;
                case 0x1111:
                case 0x11C1:
                    fontIndexArray[indexCount++] = Array.IndexOf(modelIndex, "ㅍ");
                    break;
                case 0x1112:
                case 0x11C2:
                    fontIndexArray[indexCount++] = Array.IndexOf(modelIndex, "ㅎ");
                    break;
                default:
                    int index = Array.IndexOf(modelIndex, c.ToString());
                    if (index != -1)
                    {
                        fontIndexArray[indexCount++] = index;
                        Debug.Log("fontIndexArray[" + (indexCount - 1) + "]: " + index + "\nchar c in userName: " + c);
                    }
                    else
                    {
                        Debug.LogError("Invalid character in userName: " + c);
                    }
                    break;
            }
        }

    }*/



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
                }
            isSelect = false;
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
//}using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class JAMOSettings : MonoBehaviour
//{
//    public List<GameObject> JAMOArray = new List<GameObject>();

//    public int fontIndexSize;
//    public int[] fontIndexArray;
//    private int indexCount;

//    public GameObject[] createFontArray;
//    public List<GameObject> allFontArray = new List<GameObject>();

//    public float padding = 3f;
//    public float posY;

//    public bool isSelect = false;
//    public bool isSpringColor = false;
//    public bool isSummerColor = false;
//    public bool isFallColor = false;
//    public bool isWinterColor = false;
//    public bool isLateSummerColor = false;

//    //sm_singletone
//    public static JAMOSettings Instance { get; private set; }

//    private void Awake()
//    {
//        if (Instance == null)
//        {
//            Instance = this;
//        }
//        else
//        {
//            Destroy(gameObject);
//        }
//    }

//    /*
//    private void OnEnable()
//    {
//        //sm
//        //string userName = GameManager.Instance.GetBreakUserName();
//        //Debug.Log(userName + "%%%%JAMOSTART");
//        //이름 값 받아오기
//        string userName = "ㅉㅏㅇㄱㅗㅐ";
//        //ᄋㅣᄉㅡᆼᄆㅣᆫ  ᄋㅣᆸᄂㅣᄃㅏ. ᄂㅐ ᄋㅣᄅㅡᆷᄋㅡᆫ ᄋㅣᄉㅡᆼᄒㅜᆫ
//        string[] jamoList = { "ㄱ", "ㄴ", "ㄷ", "ㄹ", "ㅁ", "ㅂ", "ㅅ", "ㅇ", "ㅈ", "ㅊ", "ㅋ", "ㅌ",
//                "ㅍ", "ㅎ", "ㅃ", "ㅉ", "ㄸ", "ㄲ", "ㅆ", "ㅏ", "ㅑ", "ㅓ", "ㅕ", "ㅗ", "ㅛ", "ㅜ",
//                "ㅠ", "ㅣ", "ㅡ", "ㅐ", "ㅒ","ㅔ","ㅖ" };

//        fontIndexSize = userName.Length; // 이름의 글자 수
//        fontIndexArray = new int[fontIndexSize]; // 글자저장
//        createFontArray = new GameObject[fontIndexSize];

//        foreach (var c in userName) // 유저네임 받아온거 비교. jamoKeyNumbers 저장
//        {
//            // jamoList의 몇번째인지.
//            int index = System.Array.IndexOf(jamoList, c.ToString());
//            Debug.Log("index: "+index);

//            fontIndexArray[indexCount] = index;
//            indexCount++;
//        }
//    }*/

//    private const int ChosungBase = 0x1100; // 초성 시작 위치
//    private const int JungsungBase = 0x1161; // 중성 시작 위치
//    private const int JongsungBase = 0x11A7; // 종성 시작 위치 (종성이 없는 경우를 포함하므로 실제 종성의 시작은 0x11A8)

//    private const int ChosungCount = 19;
//    private const int JungsungCount = 21;
//    private const int JongsungCount = 28;

//    private string[] modelIndex =
//    {
//    "ㄱ", "ㄴ", "ㄷ", "ㄹ", "ㅁ", "ㅂ", "ㅅ", "ㅇ", "ㅈ", "ㅊ", "ㅋ", "ㅌ", "ㅍ",
//    "ㅎ", "ㅃ", "ㅉ", "ㄸ", "ㄲ", "ㅆ", "ㅏ", "ㅑ", "ㅓ", "ㅕ", "ㅗ", "ㅛ", "ㅜ",
//    "ㅠ", "ㅣ", "ㅡ", "ㅐ", "ㅒ","ㅔ","ㅖ"
//};

//    private void OnEnable()
//    {
//        string userName = GameManager.Instance.GetBreakUserName();
//        Debug.Log(userName + "%%%%JAMOSTART");


//        fontIndexSize = userName.Length;
//        fontIndexArray = new int[fontIndexSize];
//        createFontArray = new GameObject[fontIndexSize];

//        int indexCount = 0;

//        foreach (char c in userName)
//        {
//            int charCode = c;
//            int adjustedIndex = -1;

//            if (charCode >= ChosungBase && charCode < ChosungBase + 19) // 초성 범위
//            {
//                adjustedIndex = charCode - ChosungBase;
//            }
//            else if (charCode >= JungsungBase && charCode <= JungsungBase + 20) // 중성 범위
//            {
//                adjustedIndex = charCode - JungsungBase + 19;
//            }
//            else if (charCode > JongsungBase && charCode < JongsungBase + 28) // 종성 범위 (실제 종성 시작은 0x11A8)
//            {
//                int jongseongOffset = charCode - (JongsungBase + 1);

//                // 첫 19개의 종성은 초성과 같으므로 같은 adjustedIndex 값을 가집니다.
//                if (jongseongOffset < ChosungCount)
//                {
//                    adjustedIndex = jongseongOffset;
//                }
//                else
//                {
//                    adjustedIndex = jongseongOffset + 21;
//                }
//            }
//            else
//            {
//                Debug.LogError("Invalid character in userName: " + c);
//                continue;
//            }

//            if (indexCount >= fontIndexArray.Length)
//            {
//                Debug.LogError("IndexCount exceeds fontIndexArray length.");
//                break;
//            }

//            fontIndexArray[indexCount++] = adjustedIndex;
//            Debug.Log("fontIndexArray[" + (indexCount - 1) + "]: " + adjustedIndex + "\nchar c in userName: " + c);
//        }
//    }

//    void Update()
//    {
//        if (isSelect)
//        {
//            for (int i = 0; i < fontIndexArray.Length; i++)
//            {
//                int index = fontIndexArray[i];
//                createFontArray[i] = Instantiate(JAMOArray[index]);
//                createFontArray[i].transform.position = new Vector3(i * padding, posY, 0);
//                allFontArray.Add(createFontArray[i]);
//                isSelect = false;
//            }
//        }
//    }

//    public enum SeasonColor
//    {
//        None,
//        Spring,
//        Summer,
//        Fall,
//        Winter,
//        LateSummer
//    }

//    public SeasonColor currentSeasonColor = SeasonColor.None;

//    public void SetColor(SeasonColor color)
//    {
//        foreach (var font in allFontArray)
//        {
//            MeshRenderer mr = font.GetComponent<MeshRenderer>();

//            switch (color)
//            {
//                case SeasonColor.Spring:
//                    ColorConfig.Instance.SetSpringColor(mr);
//                    break;
//                case SeasonColor.Summer:
//                    ColorConfig.Instance.SetSummerColor(mr);
//                    break;
//                case SeasonColor.Fall:
//                    ColorConfig.Instance.SetFallColor(mr);
//                    break;
//                case SeasonColor.Winter:
//                    ColorConfig.Instance.SetWinterColor(mr);
//                    break;
//                case SeasonColor.LateSummer:
//                    ColorConfig.Instance.SetLateSummerColor(mr);
//                    break;
//                default:
//                    break;
//            }
//        }

//        currentSeasonColor = SeasonColor.None; // Reset the current color after setting it
//    }

//}