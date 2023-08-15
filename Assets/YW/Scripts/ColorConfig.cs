using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorConfig : MonoBehaviour
{
    public static ColorConfig Instance;

    public Color[] springColors = new Color[5];
    public Color[] summerColors = new Color[5];
    public Color[] fallColors = new Color[5];
    public Color[] winterColors = new Color[5];
    public Color[] lateSummerColors = new Color[5];

    public float emissionIntensity = 1;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            DestroyImmediate(Instance);

    }

    private void Update()
    {

    }
    

    public void SetSpringColor(MeshRenderer renderer)
    {
        int springNum = Random.Range(0, 4);
        renderer.material.SetColor("_Color", springColors[springNum]* emissionIntensity);
        Debug.Log(springNum);
    }

    public void SetSummerColor(MeshRenderer renderer)
    {
        int springNum = Random.Range(0, 4);
        renderer.material.SetColor("_Color", summerColors[springNum]* emissionIntensity);
    }

    public void SetFallColor(MeshRenderer renderer)
    {
        int springNum = Random.Range(0, 4);
        renderer.material.SetColor("_Color", fallColors[springNum]* emissionIntensity);
    }

    public void SetWinterColor(MeshRenderer renderer)
    {
        int springNum = Random.Range(0, 4);
        renderer.material.SetColor("_Color", winterColors[springNum]* emissionIntensity);
    }

    public void SetLateSummerColor(MeshRenderer renderer)
    {
        int springNum = Random.Range(0, 4);
        renderer.material.SetColor("_Color", lateSummerColors[springNum]* emissionIntensity);
    }
}
