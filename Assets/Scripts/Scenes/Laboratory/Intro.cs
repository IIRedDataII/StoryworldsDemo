using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    #region DebugBools

    public bool FadeImageOne;
    public bool FadeImageTwo;
    public bool FadeImageThree;

    #endregion

    #region Variables

    [SerializeField][Tooltip("Blackscreen")] private Image imageZero;
    
    [SerializeField] private Image imageOne;
    [SerializeField] private Image imageTwo;
    [SerializeField] private Image imageThree;

    [SerializeField][Tooltip("If smaller than 2, Image 2 wont fade out properly")] private int time;

    [SerializeField] private bool imageZeroDone;
    [SerializeField] private bool imageOneDone;
    [SerializeField] private bool imageTwoDone;
    [SerializeField] private bool imageThreeDone;

    //AllDone, Supposed to end the intro scene, set true if everything is over. Will start Blackscreen fade in and reset to beginn Gameplay
    private bool _allDone;
    
    private bool _coroutineImageOneRunning;
    private bool _coroutineImageTwoRunning;
    private bool _coroutineImageThreeRunning;
    
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        //Transparency of Images
        Color c = new Color(imageOne.color.r, imageOne.color.g, imageOne.color.b,0);
        imageOne.color = c;
        c = new Color(imageTwo.color.r, imageTwo.color.g, imageTwo.color.b,0);
        imageTwo.color = c;
        c = new Color(imageThree.color.r, imageThree.color.g, imageThree.color.b,0);
        imageThree.color = c;
    }

    // Update is called once per frame
    void Update()
    {
        //fade out ImageZero (Blackscreen)
        if (!imageZeroDone && imageZero.color.a > 0)
        {
            float a = imageZero.color.a - Time.deltaTime;
            imageZero.color = new Color(1, 1, 1, a);
            if (a <= 0)
            {
                StartCoroutine(Wait());
                imageZeroDone = true;
            }
        }

        #region ImageOne
        //Fade In
        if (FadeImageOne && imageOne.color.a < 1)
        {
            imageOne.color = new Color(imageOne.color.r, imageOne.color.g, imageOne.color.b, imageOne.color.a + 0.5f * Time.deltaTime);
        }
        
        //Hold Image
        if (!_coroutineImageOneRunning && imageOne.color.a >= 1)
        {
            _coroutineImageOneRunning = true;
            StartCoroutine(HoldImageOne());
        } 
        
        //Fade Out 
        if (imageOneDone && imageOne.color.a > 0)
        {
            imageOne.color = new Color(imageOne.color.r, imageOne.color.g, imageOne.color.b, imageOne.color.a - Time.deltaTime);
        }
        #endregion

        #region ImageTwo
        //Fade In
        if (!imageTwoDone && imageOne.color.a > 0.75f && imageTwo.color.a < 1)
        {
            imageTwo.color = new Color(imageTwo.color.r, imageTwo.color.g, imageTwo.color.b, imageTwo.color.a + 0.5f * Time.deltaTime);
        }
    
        //Hold Image
        if (!_coroutineImageTwoRunning && imageTwo.color.a >= 1)
        {
            _coroutineImageTwoRunning = true;
            StartCoroutine(HoldImageTwo());
        } 
        
        //Fade Out
        if (imageTwoDone && imageTwo.color.a > 0)
        {
            imageTwo.color = new Color(imageTwo.color.r, imageTwo.color.g, imageTwo.color.b, imageTwo.color.a - Time.deltaTime);
        }
        
        #endregion

        #region ImageThree
        //Fade In
        if (!imageThreeDone && imageTwo.color.a > 0.75f && imageThree.color.a < 1)
        {
            imageThree.color = new Color(imageThree.color.r, imageThree.color.g, imageThree.color.b, imageThree.color.a + 0.5f * Time.deltaTime);
        }
    
        //Hold Image
        if (!_coroutineImageThreeRunning && imageThree.color.a >= 1)
        {
            _coroutineImageThreeRunning = true;
            StartCoroutine(HoldImageThree());
        } 
        
        //Fade Out
        if (imageThreeDone && imageThree.color.a > 0)
        {
            imageThree.color = new Color(imageThree.color.r, imageThree.color.g, imageThree.color.b, imageThree.color.a - Time.deltaTime);
            if (imageThree.color.a <= 0)
            {
                _allDone = true;
            }
        }
        #endregion

        if (_allDone)
        {
            //Fade in Blackscreen, Reset Player, activate Player etc
        }
    }

    #region Coroutines

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(time * 2);
        FadeImageOne = true;
    }
    
    IEnumerator HoldImageOne()
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Image One Done");
        imageOneDone= true;
        FadeImageOne = false;
    }
    
    IEnumerator HoldImageTwo()
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Image Two Done");
        imageTwoDone = true;
    }
    
    IEnumerator HoldImageThree()
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Image Three Done");
        imageThreeDone = true;
    }

    #endregion
}