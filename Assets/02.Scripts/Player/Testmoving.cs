using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Testmoving : MonoBehaviour
{
    float speed = 3f;

    static public Testmoving Instance;
    public string currentMapName;

    private Animator animator;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    private BoxCollider2D box;

    Vector2 moveDirection;
    Vector3 targetPos;
    public bool isMoving = false;

    public bool isAlreadyTalking = false; //오브젝트 설명, 대화, 메뉴창 등이 켜져 있는가

    void Start()
    {
        if (Instance == null)
        {
            //DontDestroyOnLoad(this.gameObject);
            targetPos = transform.position;
            animator = GetComponent<Animator>();
            sr = GetComponent<SpriteRenderer>();
            box = GetComponent<BoxCollider2D>();
            rb = this.GetComponent<Rigidbody2D>();
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAlreadyTalking && !InventoryManager.Instance.isMouseCarryingObj)
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0f;
            RaycastHit2D hit = Physics2D.Raycast(targetPos, Vector2.zero, 1f);

            moveDirection = targetPos - transform.position; //방향벡터를 구한다.
            moveDirection.Normalize(); //정규화
            // sr.flipX = transform.position.x < MoveDirection.x;
            // isMoving = true;

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
                switch (hit.collider.tag)
                {
                    case "Box": //오브젝트
                        MyObjects myObjects = hit.collider.GetComponent<MyObjects>();
                        myObjects?.Execute();
                        break;
                    case "Point": //바닥의 지점
                        //Debug.Log(targetPos + "~" + moveDirection);
                        isMoving = true;
                        break;
                }
            }
        }

        sr.flipX = transform.position.x < targetPos.x;
        if (isMoving)
        {
            rb.MovePosition((Vector2)transform.position + moveDirection * speed * Time.deltaTime);
            float test = Vector3.Distance(transform.position, targetPos);
            animator.SetBool("Walking", true);
            
            if (Vector3.Distance(transform.position, targetPos) < 0.1f) //타겟과의 거리가 0.1이하 일때 멈춘다.
            {
                isMoving = false;
                animator.SetBool("Walking", false);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Box")
        {
            isMoving = false;
            animator.SetBool("Walking", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            isMoving = false;
            animator.SetBool("Walking", false);
        }
    }

}
