using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutines : MonoBehaviour
{
    WaitForSeconds delayTime;

    Coroutine coLogAfterDelay;
    Coroutine coRun;
    // Start is called before the first frame update
    void Start()
    {
        //coRun = StartCoroutine(RenEveryHundredFrames());
        coLogAfterDelay = StartCoroutine(LogAfterDelay(3f));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(coRun);
        }
    }
    IEnumerator Countdown()
    {
        int time = 5;
        while (time > 0)
        {
            Debug.Log(time);
            time--;
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator CoUpdate()
    {
        while (true)
        {
            yield return null;
        }
    }

    IEnumerator LogAfterDelay(float time)
    {
        Debug.Log("Before");
        yield return delayTime;
        Debug.Log("After");
        yield return StartCoroutine(Countdown());
        Debug.Log("End Countdown");
    }

    IEnumerator RenEveryHundredFrames()
    {
        int frameCount = 0;
        while(true)
        {
            yield return null;
            frameCount++;
            if(frameCount % 100 == 0)
            {
                Debug.Log("Frame: " + frameCount);
            }
        }
    }


}
