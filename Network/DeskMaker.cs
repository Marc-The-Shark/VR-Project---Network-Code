/*
Copyright (c) 2014 Tobias Wehrum <Tobias.Wehrum@dragonlab.de>
Distributed under the MIT License. (See accompanying file LICENSE or copy at http://opensource.org/licenses/MIT)
This notice shall be included in all copies or substantial portions of the Software.
*/

using Assets.Scripts.HelperBehaviours;
using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.General
{
	// A menu marker.
	public class DeskMarker : MonoBehaviourBase
	{
		[SerializeField] private GameObject[] visibleObjectsWhenLyingStill;

		private GeneralConstants constants;

		private MarkerObject markerObject;

		private void Awake()
		{
			constants = GeneralConstants.Instance;

			markerObject = GetComponent<MarkerObject>();
			SetVisibility(false);
		}

		private void Update()
		{
			SetVisibility(markerObject.LyingStillTime > constants.MenuMarkerLyingStillTimeNeeded);
		}

		private void SetVisibility(bool visibility)
		{
			foreach (var o in visibleObjectsWhenLyingStill)
			{
				o.SetActive(visibility);
			}
		}
	}
}
