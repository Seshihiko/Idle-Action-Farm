using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] private GameObject tool;
    [SerializeField] private GameObject particleTool;

    [SerializeField] private GameObject _joystick;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private GameObject backpackPrefab;

    private Joystick joystick;
    private CharacterController controller = null;
    private bool coolDownAttack;


    private void Awake()
    {
        instance = this;

        tool.SetActive(false);

        UIButtonScript.attack += Damage;
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        if (_joystick != null) joystick = _joystick.GetComponent<Joystick>();
    }

    private void Update()
    {
        Vector3 direction = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);
        direction.Normalize();

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            controller.SimpleMove(direction * speed);
            transform.forward = direction;

            animator.SetTrigger("Walking");
        }
        else animator.SetTrigger("Peace");
    }

    private void Damage()
    {
        if(!coolDownAttack) animator.SetTrigger("Attack");
    }

    public void EnabledTool()
    {
        coolDownAttack = true;
        tool.SetActive(true);
    }

    public void DisabledTool()
    {
        coolDownAttack = false;
        tool.SetActive(false);
    }

    public void EnabledColliderTool()
    {
        particleTool.SetActive(true);
        tool.GetComponent<BoxCollider>().enabled = true;
    }

    public void DisabledColliderTool()
    {
        particleTool.SetActive(false);
        tool.GetComponent<BoxCollider>().enabled = false;
    }
}