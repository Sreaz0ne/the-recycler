using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlash : MonoBehaviour {

	public Color flashColor;
	public float flashDuration;

	Material mat;

    private IEnumerator flashCoroutine;
    private IEnumerator blinkCoroutine;

	private void Awake() {
		mat = GetComponent<SpriteRenderer>().material;
	}

	private void Start()
	{
		mat.SetColor("_FlashColor", flashColor);
	}

	public void Flash(){
		if (flashCoroutine != null)
		    StopCoroutine(flashCoroutine);
		
		flashCoroutine = DoFlash(flashDuration);
        StartCoroutine(flashCoroutine);
    }

    public void Blink(int numberOfFlash, float blinkDuration) {
        
        if (blinkCoroutine != null)
		    StopCoroutine(blinkCoroutine);
		
		blinkCoroutine = DoBlink(numberOfFlash, blinkDuration);
        StartCoroutine(blinkCoroutine);
    }

    private IEnumerator DoBlink(int numberOfFlash, float blinkDuration)
    {   
        float duration = blinkDuration / numberOfFlash;

        for(int i = 0; i < numberOfFlash; i++) {
            float lerpTime = 0;

            while (lerpTime < duration)
            {
                lerpTime += Time.deltaTime;
                float perc = lerpTime / duration;

                SetFlashAmount(1f - perc);
                yield return null;
            }
            SetFlashAmount(0);
        }
    }

    private IEnumerator DoFlash(float duration)
    {
        float lerpTime = 0;

        while (lerpTime < duration)
        {
            lerpTime += Time.deltaTime;
            float perc = lerpTime / duration;

            SetFlashAmount(1f - perc);
            yield return null;
        }
        SetFlashAmount(0);
    }
	
    private void SetFlashAmount(float flashAmount)
    {
        mat.SetFloat("_FlashAmount", flashAmount);
    }

}