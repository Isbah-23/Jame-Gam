using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerLeftArmScript : MonoBehaviour
{
    public Sprite bloody_left_arm;
    EnemyScript enemyScript;
    private void Start()
    {
        enemyScript = transform.parent.GetComponent<EnemyScript>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow") && enemyScript.last_collided_with_arrow != collision.gameObject)
        {
            enemyScript.last_collided_with_arrow = collision.gameObject;
            ArrowScript arrow_script = collision.gameObject.GetComponent<ArrowScript>();
            if (arrow_script.is_active)
            {
                if (!enemyScript.is_dead)
                {
                    enemyScript.Mark_Dead();
                    enemyScript.PlaySound(0);
                    enemyScript.MakeJointsWeak();
                }
                HingeJoint2D joint = GetComponent<HingeJoint2D>();
                if (joint.enabled)
                {
                    joint.enabled = false;
                    Debug.Log("Joint enabled" + joint.enabled);
                    Bleed();
                    enemyScript.splatter(6);
                }
            }
        }
        else if (collision.gameObject.CompareTag("Boulder"))
        {
            enemyScript.Crush();
        }
    }
    public void Bleed() { 
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = bloody_left_arm;
    }
}
