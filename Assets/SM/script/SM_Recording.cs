using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrostweepGames.Plugins.GoogleCloud.SpeechRecognition.Examples
{
    public class SM_Recording : MonoBehaviour
    {
        private bool isRecording = false;
        private float stopRecordingDelay = 3f;
        public int __deviceNum = 1;
        public float __delayTime = 50f;


        private void OnEnable()
        {
            StartRecording();
            print("____onenable");

        }
        private void StartRecording()
        {
            if (!isRecording)
            {
                GCSR_Example.Instance.deviceNum = __deviceNum;
                GCSR_Example.Instance.StartRecordButtonOnClickHandler(); // Assuming this is the method to start recording
                StartCoroutine(StopRecordingAfterDelay(__delayTime));
                isRecording = true;
                print("____-__1start"+isRecording);
                print(GCSR_Example.Instance.deviceNum);

            }
        }

        private void StopRecording()
        {
            if (isRecording)
            {
                GCSR_Example.Instance.StopRecordButtonOnClickHandler(); // Assuming this is the method to stop recording
            }
        }
        private IEnumerator StopRecordingAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            StopRecording();
            isRecording = false;
            print("_______2stop"+isRecording);
            print("_______&&&&&&&" + GCSR_Example.Instance.BreakUserName);
        }

    }
}