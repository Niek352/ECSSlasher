using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Game.Components
{
	[Game]
	public class LayerMaskComponent : IComponent
	{
		public LayerMask Value;
	}
}