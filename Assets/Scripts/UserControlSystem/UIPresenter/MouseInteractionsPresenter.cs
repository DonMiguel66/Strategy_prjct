using System.Linq;
using UnityEngine;
using Assets.Scripts.Abstractions;

namespace Assets.Scripts.SimpleStrategy3D
{
    public class MouseInteractionsPresenter : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;

        [SerializeField] private SelectableValue _selectedObject;

        private void Update()
        {
            if (!Input.GetMouseButtonUp(0))
                return;
            var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
            if (hits.Length == 0)
                return;
            var selectable = hits
                .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
                .Where(c => c != null)
                .FirstOrDefault();
            if (selectable == default)
                return;
            _selectedObject.SetValue(selectable);
        }
    }
}