using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    private QuestionManager questionManager;

    [SerializeField] private Sprite deadGuySprite;
    [SerializeField] private Sprite deadDrunkSprite;

    [SerializeField] private SpriteRenderer guySpriteRenderer;
    [SerializeField] private SpriteRenderer[] drunkSpriteRenderer;

    [SerializeField] private GameObject[] bubble;

    float timer1 = 1f;
    float timer2 = 1f;
    float timer3 = 1f;

    // Start is called before the first frame update
    void Start()
    {
        questionManager = GetComponent<QuestionManager>();
    }

    // Update is called once per frame
    void Update()
    {


        if (questionManager.failed) timer1 -= Time.deltaTime;

        if (!questionManager.drunk1Alive) timer2 -= Time.deltaTime;

        if (!questionManager.drunk2Alive) timer3 -= Time.deltaTime;


        if (timer1 <= 0)
        {
            guySpriteRenderer.sprite = deadGuySprite;
            bubble[2].SetActive(false);
        }


        if (timer2 <= 0)
        {
            drunkSpriteRenderer[0].sprite = deadDrunkSprite;
            bubble[0].SetActive(false);
        }

        if (timer3 <= 0)
        {
            drunkSpriteRenderer[1].sprite = deadDrunkSprite;
            bubble[1].SetActive(false);
        }

    }
}
