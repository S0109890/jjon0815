using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoverable : MonoBehaviour
{
    public bool isHovered = false;

    public void SetHovered()
    {
        isHovered = true;
    }
    public void SetHovered_False()
    {
        isHovered = false ;
    }
}
