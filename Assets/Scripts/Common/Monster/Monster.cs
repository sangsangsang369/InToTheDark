using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    SoundManager sound;
    RaycastHit2D hit;
    Player player;
    float rayLength = 15f;
    bool isHeadingLeft;
    bool isStanding = false;
    public GameObject gameOverPanel;
    [SerializeField] private float monsterSpeed = 4f;
    [HideInInspector] public bool areYouDied = false;
    
    // Start is called before the first frame update
    void Start()
    {
        sound = SoundManager.inst;
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
            isHeadingLeft = (Random.value > 0.5f);
        }
        else 
        { 
            isStanding = true; 
            this.GetComponent<Animator>().SetBool("IsWalking", false);
            isHeadingLeft = (Random.value > 0.5f);
        }
        StartCoroutine(RandomDirectionChange());
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
        }
        else if(!isStanding && !isHeadingLeft) // 서있지 않고 오른쪽으로 향하고 있을 경우
        {
            transform.Translate(Vector3.right * monsterSpeed * Time.deltaTime);
            ShootingRay(layerMask, Vector2.right);
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

    private void ScaredEffect()
    {
        if(hit && hit.transform.GetComponent<Player>())
        {
            //Debug.Log("ㄷㄷ");
        }
        else
        {
            if(sound.monsterAudioSource.clip != null)
            {
                sound.monsterAudioSource.Stop();
                sound.monsterAudioSource.clip = null;
            }  
        }
    }

    public void MonsterRandomPosition(float min, float max)
    {
        this.transform.position = new Vector2(Random.Range(min, max), this.transform.position.y);
    }
}
