using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Human, IDamagable
{
    public Collider body;
    public MovementStateMachine stateMachine;
    public Standing standing;
    public Running running;
    public Jumping jumping;
    public Ducking ducking;
    public Rigidbody playerRB;
    public PlayerControl controls;
    public static Player S;
    public GameObject projectile;
    public Transform projectileHolder;
    public AnimationClip OnDeathAnimation;



    [SerializeField] private Text _hpText;
    private InGameUI _ui;
    private int _currentHP;




    public int CurrentHP
    {
        get
        {
            return _currentHP;
        }
        set
        {
            _currentHP = value;
        }
    }


    private void Awake()
    {
        if (S == null)
        {
            S = this;
        } else
        {
            throw new System.NullReferenceException();
        }
        controls = new PlayerControl(S);
        playerRB = S.GetComponent<Rigidbody>();
        body = S.GetComponentInChildren<Collider>();
        _ui = new InGameUI(_hpText);
        CurrentHP = 100;
        _ui.UpdateUI();
    }
    private void Start()
    {
        stateMachine = new MovementStateMachine();

        standing = new Standing(S, stateMachine);
        running = new Running(S, stateMachine);
        jumping = new Jumping(S, stateMachine);
        ducking = new Ducking(S, stateMachine);

        stateMachine.Initialize(standing);

    }

    private void Update()
    {
        stateMachine.CurrentState.HandleInput();
        stateMachine.CurrentState.LogicUpdate();

    }

    private void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicsUpdate();
        Die();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Terrain>(out Terrain terrain))
        {
            Input.isJumping = false;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Terrain>(out Terrain terrain))
        {
            Input.isJumping = true;
        }
    }

    
    private void Die()
    {
        if (CurrentHP <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    public void ApplyDamage(int damage)
    {
        if (CurrentHP > _minHp)
        {
            CurrentHP -= damage;
        }
        _ui.UpdateUI();
    }

    public void AddHealth(int health, out bool isAdded)
    {
        if (CurrentHP < _maxHp)
        {
            if (CurrentHP + health >= 100)
            {
                CurrentHP = 100;
                
            } else
            {
                CurrentHP += health;
            }

            isAdded = true;
        } else
        {
            isAdded = false;
        }

        _ui.UpdateUI();
    }
}
