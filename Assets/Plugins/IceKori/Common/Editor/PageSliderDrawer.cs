using UnityEngine;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using System;
using System.Linq;
using Sirenix.Utilities;

namespace Assets.Plugins.IceKori.Common.Editor
{
    [DrawerPriority(0, 200, 0)]
    public class PageSliderAttributeDrawer : OdinAttributeDrawer<PageSliderAttribute>
    {
        private static GUIStyle _titleStyle;
        private static SlidePageNavigationHelper<InspectorProperty> _currentSlider;
        private static InspectorProperty _currentDrawingPageProperty;
        private SlidePageNavigationHelper<InspectorProperty> _slider;
        private SlidePageNavigationHelper<InspectorProperty>.Page _page;
        private GUIContent _pageLabel;

        protected override bool CanDrawAttributeProperty(InspectorProperty property)
        {
            return !(property.ChildResolver is ICollectionResolver);
        }

        protected override void Initialize()
        {
            _titleStyle = _titleStyle ?? new GUIStyle("ShurikenModuleTitle");
        }

        protected override void DrawPropertyLayout(GUIContent label)
        {
            if (Property.ValueEntry.WeakSmartValue == null)
            {
                CallNextDrawer(label);
                return;
            }

            UpdateBreadcrumbLabel(label);

            if (_currentSlider == null)
            {
                DrawPageSlider(label);
            }
            else if (_currentDrawingPageProperty == Property)
            {
                CallNextDrawer(null);
            }
            else
            {
                if (GUILayout.Button(new GUIContent(GetLabelText(label)), _titleStyle))
                {
                    _currentSlider.PushPage(Property, Guid.NewGuid().ToString());
                    _page = _currentSlider.EnumeratePages.Last();
                    _page.Name = GetLabelText(label);
                    _pageLabel = label;
                }
            }
        }

        private void UpdateBreadcrumbLabel(GUIContent label)
        {
            if (Event.current.type != EventType.Layout) return;
            if (_page == null) return;
            if (_pageLabel != null && _pageLabel != Property.Label) return;

            var newLabel = GetLabelText(label ?? _pageLabel);

            if (newLabel != _page.Name)
            {
                _page.Name = newLabel;
                _page.GetType().GetField("TitleWidth", Flags.AllMembers)?.SetValue(_page, null);
            }
        }

        private void DrawPageSlider(GUIContent label)
        {
            try
            {
                if (_slider == null)
                {
                    _slider = new SlidePageNavigationHelper<InspectorProperty>();
                    _slider.PushPage(Property, Guid.NewGuid().ToString());
                    _page = _slider.EnumeratePages.Last();
                    _page.Name = GetLabelText(label);
                }

                _currentSlider = _slider;

                SirenixEditorGUI.BeginBox();
                SirenixEditorGUI.BeginToolbarBoxHeader();
                {
                    var rect = GUILayoutUtility.GetRect(0, 20);
                    rect.x -= 5;
                    _slider.DrawPageNavigation(rect);
                }
                SirenixEditorGUI.EndToolbarBoxHeader();
                {
                    _slider.BeginGroup();
                    foreach (var p in _slider.EnumeratePages)
                    {
                        if (p.BeginPage())
                        {
                            if (p.Value == Property)
                            {
                                CallNextDrawer(null);
                            }
                            else
                            {
                                _currentDrawingPageProperty = p.Value;
                                if (p.Value.Tree != Property.Tree)
                                {
                                    InspectorUtilities.BeginDrawPropertyTree(p.Value.Tree, true);
                                }

                                p.Value.Draw(null);

                                if (p.Value.Tree != Property.Tree)
                                {
                                    InspectorUtilities.EndDrawPropertyTree(p.Value.Tree);
                                }

                                _currentDrawingPageProperty = null;
                            }
                        }

                        p.EndPage();
                    }

                    _slider.EndGroup();
                }
                SirenixEditorGUI.EndBox();
            }
            finally
            {
                _currentSlider = null;
            }
        }

        private string GetLabelText(GUIContent label)
        {
            if (label != null)
            {
                return label.text;
            }

            var val = Property.ValueEntry.WeakSmartValue;
            if (val == null)
            {
                return "Null";
            }

            var uObj = val as UnityEngine.Object;
            if (uObj)
            {
                if (string.IsNullOrEmpty(uObj.name))
                {
                    return uObj.ToString();
                }
                return uObj.name;
            }

            return val.ToString();
        }
    }
}