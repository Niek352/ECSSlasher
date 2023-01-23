using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Game.Core.Components
{
	[Game]
	[Event(EventTarget.Self)]
	public class PositionComponent : IComponent
	{
		public Vector3 Value;
	}
}