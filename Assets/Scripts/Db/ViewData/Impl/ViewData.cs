using System;
using System.Collections.Generic;
using System.Linq;
using Ecs.Views.Linkable.Impl;
using UnityEngine;

namespace Db.ViewData.Impl
{
	[CreateAssetMenu(menuName = "Settings/" + nameof(ViewData), fileName = nameof(ViewData))]
	public class ViewData : ScriptableObject, IViewData
	{
		[SerializeField] private List<ViewPrefab> _views;

		public LinkableView Get(string prefabName)
		{
			return _views.First(view => view.name == prefabName).view;
		}
		
		[Serializable]
		public class ViewPrefab
		{
			public string name;
			public LinkableView view;
		}
	}
}