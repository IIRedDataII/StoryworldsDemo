using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    
    #region DebugBools

    public bool fadeImageOne;
    public bool fadeImageTwo;
    public bool fadeImageThree;

    #endregion
    
    #region Variables

    [SerializeField] private GameObject player;

    private PlayerLabPos _playerLabPos;
    
    #region Images

    [SerializeField][Tooltip("Blackscreen")] private Image imageZero;
    [SerializeField] private Image imageOne;
    [SerializeField] private Image imageTwo;
    [SerializeField] private Image imageThree;

    #endregion

    #region boolean

    [SerializeField] private bool imageZeroDone;
    [SerializeField] private bool imageOneDone;
    [SerializeField] private bool imageTwoDone;
    [SerializeField] private bool imageThreeDone;

    //AllDone, Supposed to end the intro scene, set true if everything is over. Will start Blackscreen fade in and reset to beginn Gameplay
    private bool _allDone;
    private bool _fadeInZero;
    
    private bool _coroutineImageOneRunning;
    private bool _coroutineImageTwoRunning;
    private bool _coroutineImageThreeRunning;

    #endregion

    [SerializeField][Tooltip("If smaller than 2, Image 2 wont fade out properly")] private int time;
    
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        imageZero.enabled = true;
        player.transform.position = transform.position;
        _playerLabPos = player.GetComponent<PlayerLabPos>();
        //Transparency of Images

        var color = imageOne.color;
        color = new Color(color.r, color.g, color.b,0);
        imageOne.color = color;
        color = imageTwo.color;
        color = new Color(color.r, color.g, color.b,0);
        imageTwo.color = color;
        color = imageThree.color;
        color = new Color(color.r, color.g, color.b,0);
        imageThree.color = color;
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
        if (fadeImageOne && imageOne.color.a < 1)
        {
            var color = imageOne.color;
            color = new Color(color.r, color.g, color.b, color.a + 0.5f * Time.deltaTime);
            imageOne.color = color;
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
            var color = imageOne.color;
            color = new Color(color.r, color.g, color.b, color.a - Time.deltaTime);
            imageOne.color = color;
        }
        #endregion

        #region ImageTwo
        //Fade In
        if (!imageTwoDone && imageOne.color.a > 0.75f && imageTwo.color.a < 1)
        {
            var color = imageTwo.color;
            color = new Color(color.r, color.g, color.b, color.a + 0.5f * Time.deltaTime);
            imageTwo.color = color;
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
            var color = imageTwo.color;
            color = new Color(color.r, color.g, color.b, color.a - Time.deltaTime);
            imageTwo.color = color;
        }
        
        #endregion

        #region ImageThree
        //Fade In
        if (!imageThreeDone && imageTwo.color.a > 0.75f && imageThree.color.a < 1)
        {
            var color = imageThree.color;
            color = new Color(color.r, color.g, color.b, color.a + 0.5f * Time.deltaTime);
            imageThree.color = color;
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
            var color = imageThree.color;
            color = new Color(color.r, color.g, color.b, color.a - Time.deltaTime);
            imageThree.color = color;
            if (imageThree.color.a <= 0)
            {
                _allDone = true;
            }
        }
        #endregion

        if (_allDone)
        {
            //Reset Player Pos;
            _playerLabPos.enabled = true;
            //Start Blackscreen Fade in;
            _fadeInZero = true;
        }

        if (imageZeroDone && _fadeInZero && imageZero.color.a <= 1)
        {
            
        }
    }

    #region Coroutines

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(time * 2);
        StartCoroutine(Test());
        Debug.Log("Wait: "+Time.time);
        fadeImageOne = true;
    }
    
    IEnumerator HoldImageOne()
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Image One Done");
        imageOneDone= true;
        fadeImageOne = false;
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

    IEnumerator Test()
    {
        Debug.Log("Test: "+ Time.time);
        yield return this;
    }
    #endregion
}