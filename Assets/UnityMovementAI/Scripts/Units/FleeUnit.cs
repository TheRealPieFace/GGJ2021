﻿using UnityEngine;

namespace UnityMovementAI
{

    public class FleeUnit : MonoBehaviour
    {
        public Transform target;
        public Transform destination;


        AudioManager audioManager;
        SteeringBasics steeringBasics;
        Flee flee;
        Wander1 wander;
        Animator anim;
        public bool isWandering = true;
        public bool isFleeing = false;
        public bool goingToHole = false;
        public float waitTime = 1;
        public float timer = 0;
        bool soundPlaying = false;

        void Start()
        {
            audioManager = FindObjectOfType<AudioManager>();
            steeringBasics = GetComponent<SteeringBasics>();
            flee = GetComponent<Flee>();
            wander = GetComponent<Wander1>();
            anim = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            if(timer >= waitTime)
            {
                isWandering = !isWandering;
                waitTime = Random.Range(.5f, 2f);
                timer = 0;
            }

            timer += Time.deltaTime;
        }

        void FixedUpdate()
        {
            Vector3 acceleration = transform.position - target.position;
            Vector3 accel;
            isFleeing = acceleration.magnitude <= flee.panicDist;

            if (goingToHole)
            {
                accel = steeringBasics.Arrive(destination.position);
            }
            else if (isFleeing)
            {
                accel = flee.GetSteering(target.position);
                ClearAnim();
                if (!soundPlaying)
                {
                    audioManager.Play("BunnyFootsteps");
                    GameObject.FindGameObjectWithTag("RabbitSound").GetComponent<AudioSource>().Play();
                    soundPlaying = true;
                }
                anim.SetBool("isRunning", true);
            }
            else
            {
                if (isWandering)
                {
                    StopSound();
                    accel = wander.GetSteering();
                    ClearAnim();
                    anim.SetBool("isJumping", true);
                }
                else
                {
                    StopSound();
                    ClearAnim();
                    //anim.SetBool("isLookingOut", true);
                    accel = steeringBasics.Arrive(transform.position);
                }
            }

            steeringBasics.Steer(accel);
            steeringBasics.LookWhereYoureGoing();

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "RabbitHole" && isFleeing)
            {
                destination = other.gameObject.GetComponentInChildren<Teleport>().gameObject.transform;
                goingToHole = true;
            }
        }

        private void ClearAnim()
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isLookingOut", false);
            anim.SetBool("isRunning", false);
        }

        private void StopSound()
        {
            if (soundPlaying)
            {
                audioManager.Stop("BunnyFootsteps");
                GameObject.FindGameObjectWithTag("RabbitSound").GetComponent<AudioSource>().Stop();
                soundPlaying = false;
            }
        }
    }
}