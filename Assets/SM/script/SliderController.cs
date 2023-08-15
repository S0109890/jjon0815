using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SliderController : MonoBehaviour
{
    public Slider slider; // Inspector에서 할당할 슬라이더
    public float duration = 50f; // 애니메이션 지속 시간 (초)
    private float elapsedTime = 0f;

    private void OnEnable()
    {
        StartCoroutine(CountDown());
        print("countdown_start");
    }

    public IEnumerator CountDown()
    {
        // Set the slider's value to its maximum at the start
        slider.value = slider.maxValue;

        while (elapsedTime < duration)
        {
            // update elapsed time
            elapsedTime += Time.deltaTime;

            // Calculate the slider value
            float newValue = Mathf.Lerp(slider.maxValue, slider.minValue, elapsedTime / duration);

            // set the slider value
            slider.value = newValue;

            yield return null; // wait for the next frame
        }
    }
}
