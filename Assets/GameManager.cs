using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //sm_singletone
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make this object persistent
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance is there
        }
    }

    //여기 이름 저장 !!!
    public string __BreakUserName;
    //gcsr 에서 BreakUserName받아온거를 
    //저장해놨다가
    //JAMOSettings에 보낸다.
    // Start is called before the first frame update
    public void SetBreakUserName(string name)
    {
        __BreakUserName = name;
    }

    public string GetBreakUserName()
    {
        return __BreakUserName;
    }
}

