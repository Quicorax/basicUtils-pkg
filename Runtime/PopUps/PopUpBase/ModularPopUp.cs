using DG.Tweening;
using System.Collections;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Quicorax
{
    public class ModularPopUp : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;
        private RectTransform _parent;
        private VerticalLayoutGroup _layout;
        private Image _image;

        private float _moduleSize;
        private float _baseWidht;

        private AddressablesService _addressables;

        private void Awake()
        {
            _addressables = ServiceLocator.GetService<AddressablesService>();
            _canvasGroup = GetComponent<CanvasGroup>();

            Transform body = transform.GetChild(1);
            _parent = body.GetComponent<RectTransform>();
            _layout = body.GetComponent<VerticalLayoutGroup>();
            _image = body.GetComponent<Image>();
        }
        public void GeneratePopUp(float baseWidht, IPopUpComponentData[] componentsToAdd)
        {
            _addressables.LoadAdrsAssetOfType<Sprite>("BasePopUpImage", x => _image.sprite = x);

            _canvasGroup.alpha = 0;
            int currentModules = 0;

            _baseWidht = baseWidht;
            _moduleSize = 30;

            foreach (var moduleData in componentsToAdd)
            {
                _moduleSize += moduleData.ModuleHeight;

                string adressableKey = "Module_" + moduleData.ModuleConcept;
                _addressables.InstanceAdrsOfComponent<IPopUpComponentObject>(adressableKey, _parent, 
                    component =>
                    {
                        component.SetData(moduleData, CloseSelf);
                        currentModules++;

                        if (currentModules == componentsToAdd.Length)
                            GenerationComplete();
                    });
            }
        }
        public void CloseSelf()
        {
            _canvasGroup.interactable = false;
            _canvasGroup.DOFade(0, 0.2f).OnComplete(() => Destroy(gameObject));
        }

        void GenerationComplete()
        {
            _parent.sizeDelta += new Vector2(_baseWidht, _moduleSize);

            _parent.DOPunchScale(Vector3.one * 0.1f, .5f);
            _canvasGroup.DOFade(1, 0.3f);

            StartCoroutine(SetElementsOnDisposition());
        }
        IEnumerator SetElementsOnDisposition()
        {
            _layout.enabled = true;
            yield return new WaitForEndOfFrame();
            _layout.enabled = false;
        }
    }
}