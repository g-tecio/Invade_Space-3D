using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_player : MonoBehaviour
{
    public GameObject explosion;
    public GameObject player;
    public CanvasGroup uiElement;

    projectile proj;
    bool _fade;

    void Awake()
    {
        proj = GetComponent<projectile>();
    }

    void Update()
    {
        if (lives.vida2 <= 0 && !_fade )
        {
            FadeIn();
            player.SetActive(false);
            explosion.SetActive(true);
            _fade = true;
            proj.enabled = false;
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

        timeSinceStarted = Time.time - _timeStartedLerping;
        percentageComplete = timeSinceStarted / lerpTime;
        float currentValue = Mathf.Lerp(start, end, percentageComplete);

        cg.alpha = currentValue;

        print("aqui");

        yield return new WaitForSeconds(3f);

    }
}
