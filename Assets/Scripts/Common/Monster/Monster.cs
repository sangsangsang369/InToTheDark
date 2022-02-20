using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    RaycastHit2D hit;
    Player player;
    private float rayLength = 15f;
    [SerializeField] private float monsterSpeed = 4f;
    [SerializeField] private bool isGoingLeft;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMonsterDirection();
        CheckFlip();
        MonsterMoving();
        //ScaredEffect();
    }

    private void CheckMonsterDirection()
    {
        //왼쪽으로 가는 중에 왼쪽 끝에 닿으면
        if(isGoingLeft && this.transform.position.x < -player.limit)
        {
            isGoingLeft = false;
        }
        //오른쪽으로 가는 중에 오른쪽 끝에 닿으면
        else if(!isGoingLeft && this.transform.position.x > player.limit)
        {
            isGoingLeft = true;
        }
    }

    private void CheckFlip()
    {
        //왼쪽으로 가고 있을 때 오른쪽을 바라보고 있으면
        if(isGoingLeft && this.GetComponent<SpriteRenderer>().flipX == true)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        //오른쪽으로 가고 있을 때 왼쪽을 바라보고 있으면
        else if(!isGoingLeft && this.GetComponent<SpriteRenderer>().flipX == false)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void MonsterMoving()
    {
        int layerMask = (1 << LayerMask.NameToLayer("Player"));
        if(isGoingLeft)
        {
            transform.Translate(Vector3.left * monsterSpeed * Time.deltaTime);
            Debug.DrawRay(this.transform.position, Vector3.left * rayLength, Color.red, 0.1f); 
            hit = Physics2D.Raycast(this.transform.position, Vector3.left, rayLength, layerMask);
        }
        else
        {
            transform.Translate(Vector3.right * monsterSpeed * Time.deltaTime);
            Debug.DrawRay(this.transform.position, Vector3.right * rayLength, Color.red, 0.1f); 
            hit = Physics2D.Raycast(this.transform.position, Vector3.right, rayLength, layerMask);
        }
    }

    private void ScaredEffect()
    {
        if(hit && hit.transform.GetComponent<Player>())
        {
            Debug.Log("ㄷㄷ");
        }
    }
}
