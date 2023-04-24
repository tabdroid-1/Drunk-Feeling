using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    [Header("Essentials")]
    [Space]
    [SerializeField] private GameObject questionUI;
    [SerializeField] private GameObject answerUI;
    [SerializeField] private TextMeshProUGUI guysText;
    [SerializeField] private TextMeshProUGUI[] drunksText;
    [SerializeField] private Slider[] timerBar;
    [Space]
    [Header("Properties")]
    [Space]
    public bool win = false;
    [SerializeField] private float waitAtStart = 3f;
    [SerializeField] private float waitBetweenQuestions = 5f;
    [SerializeField] private float waitBetweenQuestionsTimer = 5f;
    [SerializeField] private float questionDuration = 10f;
    public float questionDurationCounter = 10f;

   

    [SerializeField] private int wrongAnswer;
    [SerializeField] private bool answered = false;
    [SerializeField] private int answer;

    public bool failed = false;

    [SerializeField] bool drunksAnswered = false;
    [SerializeField] bool can = true;
    [SerializeField] bool canAskQuestion = false;
    [SerializeField] bool randomizedWrongAnswer = false;



    public bool drunk1Alive = true;
    public bool drunk2Alive = true;
    [SerializeField] private int drunk1Answer;
    [SerializeField] private int drunk2Answer;


    private float bubbleDuration = 1f;
    private float bubbleDurationTimer = 0f;
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        AskQuestion();

        if (!drunk1Alive && !drunk2Alive)
        {
            win = true;
        }

        if (answerUI.active)
        {
            bubbleDurationTimer -= Time.deltaTime;
        }else
        {
            bubbleDurationTimer = bubbleDuration;
        }

        if (bubbleDurationTimer <= 0)
        {
            answerUI.SetActive(false);
        }

        timerBar[0].value = questionDurationCounter;
        timerBar[1].value = questionDurationCounter;

    }

    [System.Obsolete]
    private void AskQuestion()
    {

        if (can && !win && !failed) {
            waitBetweenQuestionsTimer -= Time.deltaTime;
            if (waitBetweenQuestionsTimer <= 0)
            {
                can = false;
                canAskQuestion = true;
            }
        }

        if (canAskQuestion)
        {
            Question();
        }
    }

    private void QuestionDurationTimer()
    {
        questionDurationCounter -= Time.deltaTime;
    }

    [System.Obsolete]
    public void Question()
    {
        QuestionDurationTimer();
        if (!failed) questionUI.SetActive(true);
        else questionUI.SetActive(false);

        if (!randomizedWrongAnswer)
        {
            wrongAnswer = Random.Range(1, 7);
            randomizedWrongAnswer = true;
        }

        if (questionDurationCounter > 0 && answer == wrongAnswer && answered)
        {
            failed = true;
        } else if (questionDurationCounter > 0 && answer != wrongAnswer && answered)
        {
            if (!drunksAnswered)
            {
                if (drunk1Alive) drunk1Answer = Random.Range(1, 7);
                if (drunk2Alive) drunk2Answer = Random.Range(1, 7);

                if (drunk1Answer == wrongAnswer) drunk1Alive = false;
                if (drunk2Answer == wrongAnswer) drunk2Alive = false;
                drunksAnswered = true;

                drunksText[0].text = "" + drunk1Answer;
                drunksText[1].text = "" + drunk2Answer;
            }
        }

        if (questionDurationCounter <= 0) failed = true;

        else if (answered || failed || win)
        {
            canAskQuestion = false;
            randomizedWrongAnswer = false;
            answered = false;
            questionDurationCounter = questionDuration;
            waitBetweenQuestionsTimer = waitBetweenQuestions;
            drunksAnswered = false;
            questionUI.SetActive(false);
            can = true;
        }
    }

    public void Answer(int ans)
    {
        answer = ans;
        answered = true;
        answerUI.SetActive(true);
        guysText.text = "" + answer;


    }
}
