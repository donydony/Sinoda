using UnityEngine;

namespace InnerDriveStudios.DiceCreator
{
    /**
     * An example of how we could trigger the rolling of a die by using a mouse.
     * It depends on the Die having an actual collider to raycast against.
     * 
     * @author J.C. Wichman
     * @copyright Inner Drive Studios
     */
    [RequireComponent(typeof(Die))]
    [RequireComponent(typeof(Collider))]
    [DisallowMultipleComponent]
    public class MouseClickDieRoller : MonoBehaviour
    {

        Die _die;

        [SerializeField]
        [Tooltip("Force the Die to roll even if it is currently already rolling.")]
        private bool _force = true;
        [SerializeField] int face = 1;
        private KeyCode _forward = KeyCode.W;
        private KeyCode _back = KeyCode.S;
        private KeyCode _left = KeyCode.A;
        private KeyCode _right = KeyCode.D;
        private void Awake()
        {
            _die = GetComponent<Die>();
        }

        private void OnMouseUp()
        {
            // 1
            if ( face == 1)
            {
                _die.transform.eulerAngles = new Vector3(
                0f,
                0f,
                0f
                );
            }
            // 2
            if ( face == 2)
            {

                _die.transform.eulerAngles = new Vector3(
                0f,
                60f,
                -110f
                );
            }
            // 3
            if ( face == 3)
            {

                _die.transform.eulerAngles = new Vector3(
                235f,
                31f,
                -55f
                );
            }

            // 4 
            if ( face == 4)
            {
                _die.transform.eulerAngles = new Vector3(
                125f,
                -30f,
                -55f
                );
            }
            face++;
            if (face > 4)
            {
                face = face % 5;
            }
            // _die.Roll();
        }
        void Update()
        {
            if (Input.GetKey(_forward))
            {
                _die.transform.position = new Vector3(
                _die.transform.position.x + 0.003f,
                _die.transform.position.y,
                _die.transform.position.z
                );
            }
            if (Input.GetKey(_back))
            {
                _die.transform.position = new Vector3(
                _die.transform.position.x - 0.003f,
                _die.transform.position.y,
                _die.transform.position.z
                );
            }
            if (Input.GetKey(_left))
            {
                _die.transform.position = new Vector3(
                _die.transform.position.x,
                _die.transform.position.y,
                _die.transform.position.z - 0.003f
                );
            }
            if (Input.GetKey(_right))
            {
                _die.transform.position = new Vector3(
                _die.transform.position.x,
                _die.transform.position.y,
                _die.transform.position.z + 0.003f
                );
            }
        }
        // if we are messing with delta time
        // update need to be changed to fixed update 
        void SetPosition(float x, float y, float z)
        {
            _die.transform.position = new Vector3(x, y, z);
        }

    }
}