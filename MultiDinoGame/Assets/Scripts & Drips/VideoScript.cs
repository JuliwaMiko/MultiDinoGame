using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoScript : MonoBehaviour
{
    private IntroVideo BoeBiden2;
    // Start is called before the first frame update
    void Start()
    {
        IntroVideo = GetComponent < BoeBiden2 >
                      BoeBiden2.Play();
        StartCorutine("WaitForMovieEnd");
    }

    public IEnumerator WaitForMovieEnd()
    {
        while (IntroVideo.IsPlaying)
        {
            yield return new WaitForEndOfFrame();
        }

        OnMovieEnded();
    }
   void OnMovieEnded()
   {
       SceneManager.LoadScene(1);
   }
}
