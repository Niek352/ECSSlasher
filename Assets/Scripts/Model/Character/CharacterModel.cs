using UnityEngine;

namespace Model.Character
{
	public abstract class CharacterModel : IHealthModel, IDefenceModel
	{
		[field:SerializeField] public string Id { get; set; }
		[field:SerializeField] public float Health { get; set; }
		[field:SerializeField] public float Defence { get; set; }
	}
}