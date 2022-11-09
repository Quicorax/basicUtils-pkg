using System;
using UnityEngine;

namespace Quicorax
{
    public class PopUpService : IService
    {
        private AddressablesService _addressables;
        public void Initialize(AddressablesService addressables)
        {
            _addressables = addressables;

            PreloadModules();
        }

        public void SpawnPopUp(Transform parent, float baseWidht, IPopUpComponentData[] components)
        {
            _addressables.InstanceAdrsOfComponent<ModularPopUp>("Modular_PopUp", parent, popUp =>
                popUp.GeneratePopUp(baseWidht, components));
        }

        #region Components
        public HeaderPopUpComponentData AddHeader(string text, bool cond)
        {
            HeaderPopUpComponentData component = new();
            component.HeaderTextContent = text;
            component.IsHeaderHighlighted = cond;

            return component;
        }
        public TextPopUpComponentData AddText(string text)
        {
            TextPopUpComponentData component = new();
            component.TextContent = text;

            return component;
        }
        public ImagePopUpComponentData AddImage(string text, string text1)
        {
            ImagePopUpComponentData component = new();
            component.SpriteName = text;
            component.ImageText = text1;
            component.WithText = !string.IsNullOrEmpty(text1);

            return component;
        }
        public ButtonPopUpComponentData AddButton(string text, Action action, bool cond)
        {
            ButtonPopUpComponentData component = new();
            component.ButtonText = text;
            component.OnButtonAction = action;
            component.CloseOnAction = cond;

            return component;
        }
        public CloseButtonPopUpComponentData AddCloseButton()
        {
            CloseButtonPopUpComponentData component = new();

            return component;
        }
        #endregion

        private void PreloadModules()
        {
            SpawnPopUp(null, 0, new IPopUpComponentData[]
            {
                AddHeader(string.Empty, false),
                AddText(string.Empty),
                AddImage("Reputation", string.Empty),
                AddButton(string.Empty, null, false),
                AddCloseButton()
            });
        }
    }
}