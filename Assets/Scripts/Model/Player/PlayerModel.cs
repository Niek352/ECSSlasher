using System;
using Model.Character;
using UnityEngine;

namespace Model.Player
{
	[Serializable]
	public class PlayerModel : CharacterModel, IMoveModel, IAttackModel
	{
		[field:SerializeField] public float MoveSpeed { get; set; }
		[field:SerializeField] public float Damage { get; set; }
		[field:SerializeField] public float AttackCooldown { get; set; }
		public LayerMask BulletLayerMask;
	}
}