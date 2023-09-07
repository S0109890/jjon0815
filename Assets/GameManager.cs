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
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public string __BreakUserName;
    //gcsr ���� BreakUserName�޾ƿ°Ÿ� 
    //�����س��ٰ�
    //JAMOSettings�� ������.
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

