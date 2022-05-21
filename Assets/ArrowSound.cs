using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSound : MonoBehaviour
{
    private new AudioSource audio;
    void Awake()
    {
        audio = gameObject.GetComponent<AudioSource>();
        audio.Play();
        StartCoroutine(Wait(audio.clip.length));
    }

    IEnumerator Wait(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
