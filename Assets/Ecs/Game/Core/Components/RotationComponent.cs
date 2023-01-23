using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Game.Core.Components
{
	[Game]
	[Event(EventTarget.Self)]
	public class RotationComponent : IComponent
	{
		public Quaternion Value;
	}
}