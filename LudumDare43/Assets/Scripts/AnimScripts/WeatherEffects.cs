using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherEffects : MonoBehaviour
{
    Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();

        if (anim == null)
        {
            Debug.LogError("Animator not Found! " + this);
        }
    }

    public void activateWeather()
    {
        Debug.Log("Weather activated!" + gameObject.tag);
        StartCoroutine(WeatherEffect());
    }


    void SetWeatherActive(bool active)
    {
        if (anim != null)
        {
            anim.SetBool("effectActive", active);
        }
    }

    IEnumerator WeatherEffect()
    {
        SetWeatherActive(true);
        float delay = 4f;

        if (this.gameObject.tag.Equals("effectRain"))
        {
            delay = 4f;
            AudioManager.instance.Play("Rain");

        }
        else if (this.gameObject.tag.Equals("effectSun"))
        {
            delay = 3f;
            AudioManager.instance.Play("Sunshine");

        }
        else if (this.gameObject.tag.Equals("effectLove"))
        {
            delay = 4.7f;
            AudioManager.instance.Play("Love");

        }
        else if (this.gameObject.tag.Equals("effectFruit"))
        {
            delay = 2.5f;
            AudioManager.instance.Play("Fruit");

        }
        else if (this.gameObject.tag.Equals("effectMist"))
        {
            delay = 5f;
            AudioManager.instance.Play("Wind");

        }



        yield return new WaitForSeconds(delay);


        SetWeatherActive(false);
        yield break;
    }
}
