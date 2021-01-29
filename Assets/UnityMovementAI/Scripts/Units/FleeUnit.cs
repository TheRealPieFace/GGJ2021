using UnityEngine;

namespace UnityMovementAI
{

    public class FleeUnit : MonoBehaviour
    {
        public Transform target;

        SteeringBasics steeringBasics;
        Flee flee;
        Wander1 wander;
        public bool isWandering = true;
        public float waitTime = 1;
        public float timer = 0;

        void Start()
        {
            steeringBasics = GetComponent<SteeringBasics>();
            flee = GetComponent<Flee>();
            wander = GetComponent<Wander1>();
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

            if (acceleration.magnitude <= flee.panicDist)
            {
                accel = flee.GetSteering(target.position);
                steeringBasics.Steer(accel);
                steeringBasics.LookWhereYoureGoing();
            }
            else
            {
                accel = wander.GetSteering();
                if (isWandering)
                {
                    steeringBasics.Steer(accel);
                    steeringBasics.LookWhereYoureGoing();
                }
                else
                {
                    steeringBasics.Arrive(transform.position);
                }
            }

            
        }
    }
}