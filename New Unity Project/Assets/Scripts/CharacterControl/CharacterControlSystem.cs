using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlSystem : IGameSystem
{
    public Animator animator;
    public GameObject m_game;
     public CharacterControlSystem(PBaseDefenseGame PBDGame) : base(PBDGame)
    {
        Initialize();
    }

    public void SetGameObject(GameObject ga)
    {
        animator = ga.GetComponent<Animator>();
        m_game = ga;

    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Release()
    {
        base.Release();
    }

    public override void Update()
    {
        if (m_game != null)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if (h != 0 || v != 0)
            {
                m_game.transform.LookAt(m_game.transform.position + new Vector3(h, 0, v));

                m_game.transform.Translate(Vector3.forward * 10 * Time.deltaTime);

                //animator.SetFloat("run", h + v);
                animator.SetFloat("run",1);
            }
            else
            {
                animator.SetFloat("run", 0);

            }

        }
    }
}
