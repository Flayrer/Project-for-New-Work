using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Persons : MonoBehaviour
{
    [SerializeField]private GameObject pointSeller;
    [SerializeField]private GameObject[] finishPoint;
    [SerializeField]private NavMeshAgent agent;
    [SerializeField]private Animator anim;
    [SerializeField]private GameObject ballonTalk;

    public bool buySandwich;
    public int numbersRandom;
    public int numberRandomSandwiches;

    public Sandwiches[] sandwiches;

    // Start is called before the first frame update
    void Start()
    {
        pointSeller = GameObject.Find("Seller");
        finishPoint[0] = GameObject.Find("Finish Point 1");
        finishPoint[1] = GameObject.Find("Finish Point 2");
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        numbersRandom = Random.Range(0, 2);

        numberRandomSandwiches = Random.Range(0, sandwiches.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Sandwiches()
    {
        
    }

    private void FixedUpdate()
    {
        SetMove();
    }

    void SetMove()
    {
        if (buySandwich == false)
        {
            agent.SetDestination(pointSeller.transform.position);
            SetAnimation();
        }
        else
        {
            numberRandomSandwiches = Random.Range(0, sandwiches.Length);

            if (numbersRandom == 0)
            {
                agent.SetDestination(finishPoint[0].transform.position);
                SetAnimation();
            }
            else
            {
                agent.SetDestination(finishPoint[1].transform.position);
                SetAnimation();
            }
        }
    }

    void SetAnimation()
    {
        anim.SetFloat("Horizontal", agent.velocity.x);
        anim.SetFloat("Vertical", 0.1f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        LeanTween.scale(ballonTalk, Vector2.one, 0.5f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        LeanTween.scale(ballonTalk, Vector2.zero, 0.5f);
    }
}
