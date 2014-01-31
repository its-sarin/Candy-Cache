// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;
using System;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Math)]
	[Tooltip("Find the modulo between two ints dividend % diviser.")]
	public class IntModulo : FsmStateAction
	{
		
		public FsmInt dividend;
		
		public FsmInt diviser;

		[UIHint(UIHint.Variable)]
		public FsmFloat result;
		
		public bool everyFrame;

		public override void Reset()
		{
			dividend = null;
			diviser = null;
			result = null;
			
			everyFrame = false;
		}

		public override void OnEnter()
		{
			DoModulo();
			
			if (!everyFrame)
				Finish();
		}

		public override void OnUpdate()
		{
			DoModulo();
		}
		
		void DoModulo()
		{
			try{
				result.Value = dividend.Value % diviser.Value;
			}catch(Exception e)
			{
				Debug.LogWarning("Int Modulo error: "+e);
			}
		}
	}
}