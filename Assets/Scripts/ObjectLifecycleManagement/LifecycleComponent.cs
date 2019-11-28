using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;


namespace BaseProject
{
	public enum InitializationPhase
	{
		None = 0, 
		First, 
		Last
	}


	public class LifecycleComponent : MonoBehaviour
	{
		protected Dictionary<InitializationPhase, System.Action> initializationActions;


		public InitializationPhase CompletedInitializationPhase { get; set; } = InitializationPhase.None;


		private void Start()
		{
			Assert.IsTrue(CompletedInitializationPhase == InitializationPhase.Last, "Object not initialized before Start; GameObject: " + gameObject.name);
		}

		public void PerformNextInitializationPhase()
		{
			Assert.IsTrue(CompletedInitializationPhase < InitializationPhase.Last, "Calling initialization on already initialized component; GameObject: " + gameObject.name);
			if (initializationActions.ContainsKey(CompletedInitializationPhase))
			{
				initializationActions[CompletedInitializationPhase].Invoke();
			}
			++CompletedInitializationPhase;
		}
	}
}