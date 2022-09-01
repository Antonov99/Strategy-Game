using System.Collections.Generic;
using UnityEngine;

namespace SkeletonEditor
{

    public class PlayerController : MonoBehaviour
    {
        private Animator animator;
        private Quaternion initRotation;


        private int currentAnimation;
        private List<string> animations;

        public static PlayerController Instance { get; private set; }

        void Awake() {
            if (Instance != null) {
                Destroy(this.gameObject);
            }
            Instance = this;
        }

        void Start() {
            animator = GetComponent<Animator>();
            

          
            animations = new List<string>()
            {
                "Hit1",
                "Fall1",
                "Attack1h1",    
            };
        }

        void Update() {

            if (Input.GetKeyDown(KeyCode.E)) {
                animator.SetTrigger("Attack1h1");
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                animator.SetTrigger("Hit1");
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                animator.SetTrigger("Fall1");
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                animator.SetTrigger("Up");
            }

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (Mathf.Abs(h) > 0.001f)
                v = 0;

            var speed = Mathf.Max(Mathf.Abs(h), Mathf.Abs(v));
            animator.SetFloat("speedv", speed);
        }
    }
}