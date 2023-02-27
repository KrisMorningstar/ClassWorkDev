using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FiniteStateMachine;

public class TrafficLight : MonoBehaviour
{
    [Range(0, 10)]
    public int waitingCars = 0;

    public MeshRenderer Renderer { get; private set; }
    public StateMachine StateMachine { get; private set; }

    private void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();
        StateMachine = new StateMachine();
    }

    // Start is called before the first frame update
    void Start()
    {
        StateMachine.SetState(new RedLight(this));
    }

    // Update is called once per frame
    void Update()
    {
        if(waitingCars == 0)
        {
            if(StateMachine.GetCurrentStateAsType<TrafficLightState>().ID == TrafficLightID.green)
            {
                StateMachine.SetState(new YellowLight(this));
            }
        }
        else if(waitingCars >= 5)
        {
            if(StateMachine.GetCurrentStateAsType<TrafficLightState>().ID != TrafficLightID.green)
            {
                StateMachine.SetState(new GreenLight(this));
            }
        }
        StateMachine.OnUpdate();
    }

    public enum TrafficLightID { green = 0, yellow = 1, red = 2}

    public abstract class TrafficLightState : IState
    {
        public TrafficLightID ID { get; protected set; }

        protected TrafficLight instance;

        public TrafficLightState(TrafficLight _instance)
        {
            instance = _instance;
        }

        public virtual void OnEnter()
        {
            
        }

        public virtual void OnUpdate()
        {
            
        }

        public virtual void OnExit()
        {
            
        }
    }

    public class GreenLight : TrafficLightState
    {
        public GreenLight(TrafficLight _instance) : base(_instance)
        {
            ID = TrafficLightID.green;
        }

        public override void OnEnter()
        {
            instance.Renderer.material.color = Color.green;
            Debug.Log("The light has turned green.");
        }

        public override void OnUpdate()
        {
            Debug.Log("The light is currently green.");
        }

        public override void OnExit()
        {
            Debug.Log("The light is no longer green");
        }
    }
    public class YellowLight : TrafficLightState
    {
        public float time = 3;

        private float timer = 0;

        public YellowLight(TrafficLight _instance) : base(_instance)
        {
            ID = TrafficLightID.yellow;
        }

        public override void OnEnter()
        {
            instance.Renderer.material.color = Color.yellow;
            Debug.Log("The light has turned yellow.");
        }

        public override void OnUpdate()
        {
            timer += Time.deltaTime;
            if(timer > time)
            {
                instance.StateMachine.SetState(new RedLight(instance));
            }
            Debug.Log("The light is currently yellow.");
        }

        public override void OnExit()
        {
            Debug.Log("The light is no longer yellow");
        }
    }
    public class RedLight : TrafficLightState
    {
        public RedLight(TrafficLight _instance) : base(_instance)
        {
            ID = TrafficLightID.red;
        }

        public override void OnEnter()
        {
            instance.Renderer.material.color = Color.red;
            Debug.Log("The light has turned red.");
        }

        public override void OnUpdate()
        {
            Debug.Log("The light is currently red.");
        }

        public override void OnExit()
        {
            Debug.Log("The light is no longer red");
        }
    }
}
