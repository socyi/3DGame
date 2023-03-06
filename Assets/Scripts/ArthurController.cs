using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class ArthurController : MonoBehaviour
{
    private float moveSpeed = 0;
    private float walkSpeed = 5f;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 velocity;
    
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    private float jumpPower = 2;

    private int superJumpRemaining;
    private int superSpeedRemaining;
    private int AttackSkills;

    private bool dragonslayer = false;
    public static bool gameIsPaused;

    private CharacterController controller;
    public Animator anim;
    public CharacterStats targetStats;

    public GameObject swordSound;

    public GameObject swordSound2;
    public GameObject Music;
    public GameObject Music2;
    public GameObject FloatingTextPrefab;
    public GameObject FloatingTextPrefab2;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
       
        if (Input.GetKey("escape"))
        {

            UnityEditor.EditorApplication.isPlaying = false;
        }
        if (Input.GetKeyDown("p"))
        {

            gameIsPaused = !gameIsPaused;
            PauseGame();
        }

        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*swordSound.SetActive(true);*/
            StartCoroutine(Attack());
        }
        else if (Input.GetKeyDown(KeyCode.F) && AttackSkills > 0)
        {
            StartCoroutine(SkillAttack());
            AttackSkills--;
        }
        else if (Input.GetKeyDown(KeyCode.E) && dragonslayer==true)
        {
            StartCoroutine(Attack());
          
        }
      /*  else if (Input.GetKeyDown(KeyCode.Space)==false){
            swordSound.SetActive(false);
        }*/
    }


    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    private void Move()
    {
        
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded) 
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                //Walk
                Walk();
            }
            else if (moveDirection == Vector3.zero)
            {
                //Idle
                Idle();
            }
            moveDirection *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Jump();
            }
        }
       
        controller.Move(moveDirection * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void Idle()
    {
        anim.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }
  
    private void Walk()
    {
        if (superSpeedRemaining > 0)
        {
            walkSpeed = 16f;
            moveSpeed = walkSpeed;
            anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
        }
        else
        {
            walkSpeed = 9.5f;
            moveSpeed = walkSpeed;
            anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
        }
    }

    private void Jump()
    {
        float superJump = 1;
        if (superJumpRemaining > 0)
        {
            superJump = jumpPower*3;
            velocity.y = Mathf.Sqrt(superJump * -2 * gravity);
            superJumpRemaining--;
        }
        else
            velocity.y = Mathf.Sqrt(jumpPower * -2 * gravity);
    }
    public IEnumerator SkillAttack()
    {
        swordSound2.SetActive(true);
        anim.SetLayerWeight(anim.GetLayerIndex("SkillAttack Layer"), 1);
        anim.SetTrigger("SkillAttack");

        yield return new WaitForSeconds(3f);
        anim.SetLayerWeight(anim.GetLayerIndex("SkillAttack Layer"), 0);
        swordSound2.SetActive(false);
    }


    private IEnumerator Attack()
    {
        swordSound.SetActive(true);
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 1);
        anim.SetTrigger("Attack");

        yield return new WaitForSeconds(6);
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 0);

        swordSound.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 15)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (other.gameObject.layer == 12)
        {
            var go = Instantiate(FloatingTextPrefab2, transform.position, Quaternion.identity, transform);
           
            if (other.CompareTag("Speed"))
            {

                go.GetComponent<TextMesh>().text = "Double Speed!!!";

                Destroy(other.gameObject);
                Destroy(go, 3);
                superSpeedRemaining++;
            }
            else if (other.CompareTag("Skill"))
            {
               
                go.GetComponent<TextMesh>().text = "New skill - Press F (2x damage)!!!";

                Destroy(other.gameObject);
                Destroy(go, 3);
                AttackSkills++;
            }
            else if (other.CompareTag("Jump"))
            {
                
                go.GetComponent<TextMesh>().text = "Double Jump Power!!!";
                
                Destroy(other.gameObject);
                Destroy(go, 3);
                superJumpRemaining+=5;
            }
            else if (other.CompareTag("MaxHP"))
            {
                
                go.GetComponent<TextMesh>().text = "Max HP increased!!!";

                Destroy(other.gameObject);
                targetStats.maxHealth *= 2;
                targetStats.health = targetStats.health+200;
                Destroy(go, 3);
            }


            else if (other.CompareTag("HP"))
            {

                go.GetComponent<TextMesh>().text = "Health restored!!!";

                Destroy(other.gameObject);
                targetStats.health = targetStats.maxHealth;
                Destroy(go, 3);
            }


            else if (other.CompareTag("DragonBlade"))
            {
              
         

                go.GetComponent<TextMesh>().text = "Obtained the Dragon Slayer!\n Press E to deal (4x) damage to dragons!";
                dragonslayer = true;
                Destroy(other.gameObject);
                Destroy(go, 3);
            }

            else if (other.CompareTag("Ice"))
            {
                Destroy(other.gameObject);
            }
        }
        else if (other.CompareTag("Gates"))
        {
            var go = Instantiate(FloatingTextPrefab2, transform.position, Quaternion.identity, transform);

            go.GetComponent<TextMesh>().text = "Gates are Open!!!";
            Music.SetActive(false);
            Music2.SetActive(true);
            Destroy(other.gameObject);
            Destroy(go, 3);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 11)
        {
            Destroy(collision.gameObject);
            targetStats.TakeDamageB(30, null);
            if(superSpeedRemaining > 0)
                superSpeedRemaining--;
        }
    }


}
    
