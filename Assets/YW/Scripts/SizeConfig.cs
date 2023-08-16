using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeConfig : MonoBehaviour
{
    public static SizeConfig Instance;
    
    [Header("Radius")]
    public float startRadius = 0.08f;
    public float changeRadius = 0.08f;
    public Vector2 radiusRange = new Vector2(0.08f, 0.18f);
    public int radiusInterval = 5;

    [Header("Height")]
    public float startHeight = 2.0f;
    public float changeHeight = 2.0f;

    public Vector2 heightRange = new Vector2(1.2f, 5f);
    public int heightInterval = 3;

    [Header("Segment")]
    public int segment = 8;

    public bool isRadiusChange;
    public bool isHeightChange;

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(Instance);
    }

    //private void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //    }
    //    else
    //        Destroy(Instance);
    //}

    private void Update()
    {
        if (isRadiusChange)
        {
            //Debug.Log("===> radius change");
            RadiusRighthand();
        }
            

        if (isHeightChange)
        {
            //Debug.Log("===> height change");
            HeightLefthand();
        }
    }

    // 오른손 레이 닿은 오브젝트의 radius 바뀜, 트리거 버튼으로 값 조절
    bool isIncreasing = true;
    public void RadiusRighthand()
    {
        if ((isIncreasing && changeRadius >= radiusRange.y) || (!isIncreasing && changeRadius <= radiusRange.x))
        {
            isIncreasing = !isIncreasing; // 방향을 바꿈
            changeRadius += isIncreasing ? SelectRadiusInterval() : -SelectRadiusInterval();
        }
        else
        {
            changeRadius += isIncreasing ? SelectRadiusInterval() : -SelectRadiusInterval();
        }
        isRadiusChange = false;
    }

    bool isHeightIncrease = true;
    public void HeightLefthand()
    {
        if ((isHeightIncrease && changeHeight >= heightRange.y))
        {
            changeHeight = heightRange.y;
            isHeightIncrease = !isHeightIncrease; // 방향을 바꿈
            changeHeight += isHeightIncrease ? SelectHeightInterval() : -SelectHeightInterval();
        }
        else if (!isHeightIncrease && changeHeight <= heightRange.x)
        {
            changeHeight = heightRange.x;
            isHeightIncrease = !isHeightIncrease; // 방향을 바꿈
            changeHeight += isHeightIncrease ? SelectHeightInterval() : -SelectHeightInterval();
        }
        else
        {
            changeHeight += isHeightIncrease ? SelectHeightInterval() : -SelectHeightInterval();
        }
        isHeightChange = false;
        Debug.Log("hedflsfsdf"+changeHeight);
    }

    float SelectRadiusInterval()
    {
        changeRadius = startRadius;
        float interval = radiusRange.y - radiusRange.x;
        interval /= radiusInterval;
        return interval;
    }

    float SelectHeightInterval()
    {
        changeHeight = startHeight;
        float interval = heightRange.y - heightRange.x;
        interval /= heightInterval;
        return interval;
    }
}
