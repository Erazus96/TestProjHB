using System;
using UnityEngine.UI;
using UnityEngine;


public class mixer : MonoBehaviour
{
    [SerializeField]
    private GameObject winLog;

    [SerializeField]
    private GameObject loseLog;

    public Text textShow;

    public Color startColor = Color.clear;

    public Color resultColor = Color.clear;
    
    [SerializeField]
    private Animator animator;

    private int fruitCount;

    [SerializeField]
    private ColorLerp lerp;

    [SerializeField]
    private GameObject SP;

    [SerializeField]
    private GameObject activate;

    public Color mainColor;



    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.gameObject.TryGetComponent<Fruit>(out var fruit))
                {
                    Mix(fruit);
                    Create(hit.transform.gameObject, SP);
                }

                else if (hit.transform.gameObject.CompareTag("Button"))
                {
                    
                    activate.SetActive(true);
                    PlayAnimMix();
                    Match(mainColor, resultColor);
                }
            }
        }
    }

    private void Create(GameObject go, GameObject SP)
    {
        Instantiate(go, SP.transform);
    }

    public void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Fruit")
        {
            PlayAnimWiggle();
        }
    }


    private void Mix(Fruit fruit)
    {
        fruitCount++;
        float fraction = 1f / fruitCount;
        resultColor = Color.Lerp(resultColor, fruit.Color, fraction);
    }

    private void Visualise()
    {
        StopCoroutine(lerp.Lerp(startColor, resultColor));
        StartCoroutine(lerp.Lerp(startColor, resultColor));
        startColor = resultColor;
    }


    private void PlayAnimWiggle()
    {
        animator.SetTrigger("Play");
    }

    private void PlayAnimMix()
    {
        animator.SetTrigger("Mix");
        Visualise();

    }

    private void Match(Color colorOne, Color colorTwo)
    {
       

        var r = 100 * (1f - (Mathf.Abs(colorOne.r - colorTwo.r)));
        var g = 100 * (1f - (Mathf.Abs(colorOne.g - colorTwo.g)));
        var b = 100 * (1f - (Mathf.Abs(colorOne.b - colorTwo.b)));

        var result = (r + g + b) / 3f;

        textShow.GetComponent<Text>().text = result.ToString("F0")+"%";

        if (result < 90f)
        {
            Invoke("CompleteLevelLose", 2f);
           
        }

        else if (result >= 90f)
        {
            Invoke("CompleteLevelWin", 2f);
           
        }

        
    }

    private void CompleteLevelWin()
    {
        winLog.SetActive(true);
    }  
    private void CompleteLevelLose()
    {
        loseLog.SetActive(true);
    }
}
