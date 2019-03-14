using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public CanvasGroup uiElement;
    public Animator anim;
    public bool muerte=false;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (lives.vida2 <= 0 && muerte== false)
        {
            updateState("FadeIn");
            muerte = true;


        }


    }
    public void FadeIn()
    {
        StartCoroutine(FadePanel(uiElement, uiElement.alpha, 1));
    }
    public IEnumerator FadePanel(CanvasGroup cg, float start, float end, float lerpTime = 0.2f)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;
        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;
            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;
            if (percentageComplete >= 1) break;

            print("aqui");

            yield return new WaitForEndOfFrame();
        }

    }

    public void updateState(string state = null)
    {
        if (state != null)
        {
            anim.Play(state);
        }
    }
}
