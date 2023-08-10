using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 14f, assel = 6f;
    [SerializeField]
    private Transform attackPoint;
    [SerializeField]
    private float attackRange = 0.5f;
    [SerializeField]
    private LayerMask enemyLayers;
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private Transform point;
    [SerializeField]
    private int attackDamage = 20;

    private Vector2 _input;
    private Rigidbody2D _rb;
    private Animator _animator;
    private float attackRate = 2.0f;
    private float nextAttackTime = 0f;
    private int upgradeDamage = 0;


    private void Awake()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        DamageUpdate();
    }

    public void DamageUpdate()
    {
        upgradeDamage = PlayerPrefs.GetInt("Player damage") * 10;
    }

    void Update()
    {
        _input.x = Input.GetAxis("Horizontal");
        _input.y = Input.GetAxis("Vertical");
        HandleAttacks();
        Flip();
    }

    private void HandleAttacks()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                PerformAttack("Attack");
                nextAttackTime = Time.time + 0.5f / attackRate;
            }
        }
    }

    private void PerformAttack(string attackType)
    {
        _animator.SetTrigger(attackType);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage + upgradeDamage);
        }
    }

    private void Flip()
    {
        if (_input.x > 0)
            SetDirection(false, new Vector2(0.85f, 0.08f));
        else if (_input.x < 0)
            SetDirection(true, new Vector2(-0.85f, 0.08f));
    }

    private void SetDirection(bool flip, Vector2 pointPosition)
    {
        sr.flipX = flip;
        point.transform.localPosition = pointPosition;
    }

    public void ForceAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        attackDamage = 50;
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage + upgradeDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void FixedUpdate()
    {
        ApplyMovementX();
        ApplyMovementY();
    }

    private void ApplyMovementX()
    {
        var a = assel;
        var _xVelosity = _input.x == 0 ? 0 : _rb.velocity.x;
        _rb.AddForce(new Vector2((_input.x * speed - _rb.velocity.x) * a, 0));
        _rb.velocity = new Vector2(_xVelosity, _rb.velocity.y);
    }
    private void ApplyMovementY() 
    { 
        var a = assel;
        var _yVelosity = _input.y == 0 ? 0 : _rb.velocity.y;
        _rb.AddForce(new Vector2(0, (_input.y * speed - _rb.velocity.y) * a));
        _rb.velocity = new Vector2(_rb.velocity.x, _yVelosity);
    }
}
