using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    private Animator animator;
 
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void SetTrigger(string name)
    {
        animator.SetTrigger(name);
    }

    public void SetBool(string name, bool _switch)
    {
        animator.SetBool(name, _switch);
    }
}
