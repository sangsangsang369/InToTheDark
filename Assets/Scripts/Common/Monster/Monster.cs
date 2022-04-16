﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private AudioSource monsterAudio;
    [SerializeField] private AudioSource monsterWalkingAudio;
    [SerializeField] private AudioClip monsterRoaring;
    [SerializeField] private AudioClip monsterBreathing;
    RaycastHit2D hit;
    RaycastHit2D hit1;
    RaycastHit2D hit2;
    Player player;
    float rayLength = 15f;
    bool isHeadingLeft;
    bool isStanding = false;
    public GameObject gameOverPanel;
    public float monsterSpeed = 4f;
    [HideInInspector] public bool areYouDied = false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        StartCoroutine(RandomDirectionChange());
    }

    public IEnumerator RandomDirectionChange()
    {
        // 방에서 나왔을 때 멈춰있던 상태였던지 아닌지 확인
        if(isStanding)
        {
            this.GetComponent<Animator>().SetBool("IsWalking", false);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("IsWalking", true);
        }
        float randomTimer = Random.Range(3f, 10f);

        while(randomTimer > 0)
        {
            yield return null;
            randomTimer -= Time.deltaTime;
        }

        if(isStanding) 
        { 
            isStanding = false; 
            this.GetComponent<Animator>().SetBool("IsWalking", true);
        }
        else 
        { 
            isStanding = true; 
            this.GetComponent<Animator>().SetBool("IsWalking", false);
        }
        isHeadingLeft = (Random.value > 0.5f);
        StartCoroutine(RandomDirectionChange());
    }

    // Update is called once per frame
    void Update()
    {
        CheckMonsterDirection();
        CheckFlip();
        MonsterMoving();
        ScaredEffect();
        WalkingEffect();
    }

    private void CheckMonsterDirection()
    {
        //왼쪽으로 가는 중에 왼쪽 끝에 닿으면
        if(isHeadingLeft && this.transform.position.x < -player.limit)
        {
            isHeadingLeft = false;
        }
        //오른쪽으로 가는 중에 오른쪽 끝에 닿으면
        else if(!isHeadingLeft && this.transform.position.x > player.limit)
        {
            isHeadingLeft = true;
        }
    }

    private void CheckFlip()
    {
        //왼쪽으로 가고 있을 때 오른쪽을 바라보고 있으면
        if(isHeadingLeft && this.GetComponent<SpriteRenderer>().flipX == true)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        //오른쪽으로 가고 있을 때 왼쪽을 바라보고 있으면
        else if(!isHeadingLeft && this.GetComponent<SpriteRenderer>().flipX == false)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void MonsterMoving()
    {
        int layerMask = (1 << LayerMask.NameToLayer("Player"));
        if(areYouDied)
        {
            gameOverPanel.SetActive(true);
            return;
        }
        else if(!isStanding && isHeadingLeft) // 서있지 않고 왼쪽으로 향하고 있을 경우
        {
            transform.Translate(Vector3.left * monsterSpeed * Time.deltaTime);
            ShootingRay(layerMask, Vector2.left);
            WalkingSoundRay(layerMask);
        }
        else if(!isStanding && !isHeadingLeft) // 서있지 않고 오른쪽으로 향하고 있을 경우
        {
            transform.Translate(Vector3.right * monsterSpeed * Time.deltaTime);
            ShootingRay(layerMask, Vector2.right);
            WalkingSoundRay(layerMask);
        }
        else // 서있을 경우
        {
            if(isHeadingLeft) { ShootingRay(layerMask, Vector2.left); }
            else { ShootingRay(layerMask, Vector2.right); }
        }
    }

    private void ShootingRay(int layerMask, Vector2 direction)
    {
        Debug.DrawRay(this.transform.position, direction * rayLength, Color.red, 0.1f); 
        hit = Physics2D.Raycast(this.transform.position, direction, rayLength, layerMask);
    }

    private void WalkingSoundRay(int layerMask)
    {
        Debug.DrawRay(this.transform.position, Vector2.right * rayLength, Color.green, 0.1f);
        Debug.DrawRay(this.transform.position, Vector2.left * rayLength, Color.green, 0.1f);
        hit1 = Physics2D.Raycast(this.transform.position, Vector2.right, rayLength, layerMask);
        hit2 = Physics2D.Raycast(this.transform.position, Vector2.left, rayLength, layerMask);
    }

    private void ScaredEffect()
    {
        if(hit.collider != null)
        {
            if(monsterAudio.clip == monsterRoaring)
            {
                return;
            }
            monsterAudio.clip = monsterRoaring;
            monsterAudio.Play();
        }
        else
        {
            if(monsterAudio.clip != null)
            {
                monsterAudio.Stop();
                monsterAudio.clip = null;
            }
        }
    }

    private void WalkingEffect()
    {
        if(hit1.collider != null || hit2.collider != null)
        {
            if(monsterWalkingAudio.clip == monsterBreathing)
            {
                return;
            }
            monsterWalkingAudio.clip = monsterBreathing;
            monsterWalkingAudio.Play();
        }
        else if(hit1.collider == null && hit2.collider == null)
        {
            if(monsterWalkingAudio.clip != null)
            {
                monsterWalkingAudio.Stop();
                monsterWalkingAudio.clip = null;
            }
        }
    }

    public void MonsterRandomPosition(float min, float max)
    {
        this.transform.position = new Vector2(Random.Range(min, max), this.transform.position.y);
    }
}
