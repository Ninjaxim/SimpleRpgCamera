using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace PhatRobit
{
	public class SrpgcJoystick : MonoBehaviour
	{
		public Canvas canvas;
		public float bounds = 50;
		public Image joystickThumb;
		public SrpgcKeyboardMovementController movementController;

		private bool _active = false;
		private SimpleRpgCamera _camera;

		void Start()
		{
			_camera = Camera.main.GetComponent<SimpleRpgCamera>();
		}

		void Update()
		{
			if(_camera)
			{
				_camera.Controllable = !_active;
			}

			if(_active)
			{
				joystickThumb.rectTransform.position = Input.mousePosition;
				Vector3 position = joystickThumb.rectTransform.localPosition;
				position = Vector2.ClampMagnitude(position, bounds);// (position.x, -bounds, bounds);
				//position.y = Mathf.Clamp(position.y, -bounds, bounds);
				joystickThumb.rectTransform.localPosition = position;
			}
			else
			{
				joystickThumb.rectTransform.localPosition = Vector2.zero;
			}

			if(movementController)
			{
				movementController.KeyboardInput = joystickThumb.rectTransform.localPosition.normalized;
			}
			else
			{
				gameObject.SetActive(false);
			}
		}

		public void JoystickActive()
		{
			_active = true;
		}

		public void JoystickInactive()
		{
			_active = false;
		}
	}
}