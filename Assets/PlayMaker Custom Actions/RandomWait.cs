// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Time)]
    [Tooltip("Delays a State from finishing by a random time. NOTE: Other actions continue, but FINISHED can't happen before Time.")]
    public class RandomWait : FsmStateAction
    {
        
	    [RequiredField]
		public FsmFloat min;
		[RequiredField]
		public FsmFloat max;
		[RequiredField]
//		[UIHint(UIHint.Variable)]
//		public FsmFloat time;
        public FsmEvent finishEvent;
        public bool realTime;
		

        private float startTime;
        private float timer;
		private float time;

        public override void Reset()
        {
            min = 0f;
			max = 1f;
            finishEvent = null;
            realTime = false;
        }

        public override void OnEnter()
        {
			time = Random.Range(min.Value, max.Value);
			
            if (time <= 0)
            {
                Fsm.Event(finishEvent);
                Finish();
                return;
            }

            startTime = FsmTime.RealtimeSinceStartup;
            timer = 0f;
        }

        public override void OnUpdate()
        {
            // update time

            if (realTime)
            {
                timer = FsmTime.RealtimeSinceStartup - startTime;
            }
            else
            {
                timer += Time.deltaTime;
            }

            if (timer >= time)
            {
                Finish();
                if (finishEvent != null)
                {
                    Fsm.Event(finishEvent);
                }
            }
        }

    }
}
