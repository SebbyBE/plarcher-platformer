using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

namespace My.Events {
	[System.Serializable]
	public class ObjectEvent: UnityEvent<GameObject>{}

	[System.Serializable]
	public class IntEvent: UnityEvent<int>{}

	[System.Serializable]
	public class MyEvent: UnityEvent{}



}