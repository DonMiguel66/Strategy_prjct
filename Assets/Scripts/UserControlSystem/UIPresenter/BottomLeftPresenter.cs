using UnityEngine.UI;
using UnityEngine;
using SimpleStrategy3D.Abstractions;
using SimpleStrategy3D.UIModels;

namespace SimpleStrategy3D.UIPresenters
{
    public class BottomLeftPresenter : MonoBehaviour
    {
        [SerializeField] private Image _selectedImage;
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private Text _textHealth;
        [SerializeField] private Image _sliderBackground;
        [SerializeField] private Image _sliderFillImage;

        [SerializeField] private SelectableValue _selectedValue;

        private void Start()
        {
            _selectedValue.OnSelected += OnPointed;
            OnPointed(_selectedValue.CurrentValue);
        }

        private void OnPointed(ISelectable selected)
        {
            _selectedImage.enabled = selected != null;
            _healthSlider.gameObject.SetActive(selected != null);
            _textHealth.enabled = selected != null;

            if (selected != null)
            {
                
                _selectedImage.sprite = Sprite.Create(toTexture2D(selected.Icon), new Rect(0,0, selected.Icon.width, selected.Icon.height),_selectedImage.transform.position);
                
                _textHealth.text = $"{selected.Health}/{selected.MaxHealth}";
                _healthSlider.minValue = 0;
                _healthSlider.maxValue = selected.MaxHealth;
                _healthSlider.value = selected.Health;
                var color = Color.Lerp(Color.red, Color.green, selected.Health / (float) selected.MaxHealth);
                _sliderBackground.color = color * 0.5f;
                _sliderFillImage.color = color;
            }
        }
        Texture2D toTexture2D(RenderTexture rTex)
        {
            Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
            RenderTexture.active = rTex;
            tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
            tex.Apply();
            return tex;
        }
    }
}

