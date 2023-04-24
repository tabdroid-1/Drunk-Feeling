using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MidGameUI : MonoBehaviour
{
    [Header("Essentials")]
    [Space]
    //[SerializeField] private GameObject questionUI;
    [SerializeField] private GameObject deadUI;
    [SerializeField] private GameObject winUI;

    private QuestionManager questionManager;
    [Space]
    [Header("Properties")]
    bool a;

    private void Start()
    {
        questionManager = GameObject.Find("QuestionManager").GetComponent<QuestionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Dead();
        Win();
    }

    private void Win()
    {
        if (questionManager.win)
        {
            winUI.SetActive(true);
        }
    }

    private void Dead()
    {
        if (questionManager.failed)
        {
            deadUI.SetActive(true);
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
