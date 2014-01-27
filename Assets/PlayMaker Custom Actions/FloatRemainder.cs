// (c) Copyright HutongGames, LLC 2010-2011. All rights reserved.

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Math)]
	[Tooltip("Gets the remainder of two integer values.")]
	public class FloatRemainder : FsmStateAction
	{
		[RequiredField]
		public FsmFloat float1;
		[RequiredField]
		public FsmFloat float2;
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmFloat storeResult;
		public bool everyFrame;
		

		public override void Reset()
		{
			float1 = 0;
			float2 = 0;
			storeResult = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			DoModulusOperation();
			
			if (!everyFrame)
				Finish();
		}
		
		public override void OnUpdate()
		{
			DoModulusOperation();
		}
		
		void DoModulusOperation ()	{
			float v1 = float1.Value;
			float v2 = float2.Value;
			
			storeResult.Value = v1 % v2;	
		}
	}
}