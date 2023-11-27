using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class FirstPersonController : MonoBehaviour,IDamageable
{
    public CharacterController controller;

    private float speed;
    public float gravity = -9.81f;
    public float startingHealth;
    protected float health;
    protected bool dead;
    public Camera Camera;
    

    public event System.Action OnDeath;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;

    [SerializeField] private AudioClip[] m_FootstepSounds;


    
    public AudioSource m_AudioSource;

    Vector3 velocity;
    bool isGrounded;

    public float runSpeed = 30f;
    public float walkSpeed = 20f;

    protected virtual void Start()
    {
        health = startingHealth;
        m_AudioSource = GetComponent<AudioSource>();
        
    }




    

    private void PlayFootStepAudio()
    {
        if (controller.isGrounded)
        {
            return;
        }
        // pick & play a random footstep sound from the array,
        // excluding sound at index 0
        int n = Random.Range(1, m_FootstepSounds.Length);
        m_AudioSource.clip = m_FootstepSounds[n];
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        m_FootstepSounds[n] = m_FootstepSounds[0];
        m_FootstepSounds[0] = m_AudioSource.clip;
        m_AudioSource.Play();
    }

    void Update()
    {
        if (Input.GetKey("left shift"))
        { speed = runSpeed; }
        else { speed = walkSpeed; }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown("w"))
        {
            PlayFootStepAudio();
        }
        if (Input.GetKeyDown("s"))
        {
            PlayFootStepAudio();
        }
        if (Input.GetKeyDown("a"))
        {
            PlayFootStepAudio();
        }
        if (Input.GetKeyDown("d"))
        {
            PlayFootStepAudio();
        }
        if (Input.GetKeyUp("w"))
        {
            m_AudioSource.Stop();
        }
        if (Input.GetKeyUp("s"))
        {
            m_AudioSource.Stop();
        }
        if (Input.GetKeyUp("a"))
        {
            m_AudioSource.Stop();
        }
        if (Input.GetKeyUp("d"))
        {
            m_AudioSource.Stop();
        }


    }
    public virtual void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0 && !dead)
        {
            Die();

        }
    }


    [ContextMenu("Self Destruct")]
    protected void Die()
    {
        dead = true;
        if (OnDeath != null)
        {
            OnDeath();
        }

        Destroy(gameObject);
        Instantiate(Camera);
        

        
    }

}

   
