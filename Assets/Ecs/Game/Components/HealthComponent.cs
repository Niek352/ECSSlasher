﻿using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
	[Game]
	[Event(EventTarget.Self)]
	public class HealthComponent : IComponent
	{
		public float Value;
	}
}