using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace bNesis.Examples.UkrPoshtaApp.SimpleUI
{
    /// <summary>
    /// This class help convert C# class to ui element and invert back to class.
    /// </summary>
    public static class ClassToEdit
    {
        /// <summary>
        /// Rendered ui element to class.
        /// </summary>
        /// <param name="panel">StackPanal wich needed convert to class.</param>
        /// <returns>Return converted class.</returns>
        public static object RenderUItoClass(StackPanel panel)
        {
            object _class = panel.Tag as object;
            PropertyInfo[] propertyInfos = _class.GetType().GetProperties();
            int childCount = 0;
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                StackPanel stackPanel = panel.Children[childCount] as StackPanel;
                foreach (var uiElement in stackPanel.Children)
                {
                    if (uiElement.GetType() == typeof(TextBox))
                    {
                        TextBox textBox = uiElement as TextBox;
                        try
                        {
                            if (propertyInfo.PropertyType.Name.Contains("Int"))
                            {
                                propertyInfo.SetValue(_class, int.Parse(textBox.Text));
                            }
                            else if (propertyInfo.PropertyType.Name.Contains("Bool"))
                            {
                                propertyInfo.SetValue(_class, bool.Parse(textBox.Text));
                            }
                            else if (propertyInfo.PropertyType.Name.Contains("Long"))
                            {
                                propertyInfo.SetValue(_class, long.Parse(textBox.Text));
                            }
                            else if (propertyInfo.PropertyType.Name.Contains("Float"))
                            {
                                propertyInfo.SetValue(_class, float.Parse(textBox.Text));
                            }
                            else
                                propertyInfo.SetValue(_class, textBox.Text);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        break;
                    }
                    else if (uiElement.GetType() == typeof(StackPanel))
                    {
                        StackPanel stackPanelAdditional = (uiElement as StackPanel);
                        if (propertyInfo.PropertyType.IsArray)
                        {
                            var arr = Array.CreateInstance(propertyInfo.PropertyType.GetElementType(), 1);
                            var variable = RenderUItoClass(stackPanelAdditional);
                            arr.SetValue(variable, 0);

                            propertyInfo.SetValue(_class, arr);
                        }
                        else
                        {
                            var variable = RenderUItoClass(stackPanelAdditional);
                            propertyInfo.SetValue(_class, variable);
                        }
                    }
                }
                childCount++;
            }
            return _class;
        }

        /// <summary>
        /// Render class to ui.
        /// </summary>
        /// <param name="_class">Class wich needed convert to ui.</param>
        /// <param name="panel">StackPanel where whill added elements.</param>
        /// <param name="readOnly">Set 'IsReadOnly' for 'TextBox'.</param>
        /// <returns>If added return true.</returns>
        public static bool RenderClassToUI(object _class, StackPanel panel, Boolean readOnly)
        {
            panel.Tag = _class;
            PropertyInfo[] propertyInfos = _class.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.Margin = new Thickness(5, 2, 5, 2);
                stackPanel.Orientation = Orientation.Horizontal;
                stackPanel.Tag = propertyInfo;

                TextBlock textBlock = new TextBlock();
                textBlock.Margin = new Thickness(5, 0, 5, 0);
                textBlock.Text = propertyInfo.Name;
                textBlock.Width = 170;
                stackPanel.Children.Add(textBlock);

                Console.WriteLine(propertyInfo.Name);
                if (propertyInfo.PropertyType.IsClass && !propertyInfo.PropertyType.Name.Contains("String"))
                {
                    textBlock.Text = string.Empty;
                    var bold = new Bold(new Run(propertyInfo.Name));
                    textBlock.Inlines.Add(bold);


                    StackPanel stackPanelAdditional = new StackPanel();
                    stackPanelAdditional.Margin = new Thickness(0, 25, 0, 0);
                    stackPanel.Children.Add(stackPanelAdditional);

                    object classInner;
                    if (!propertyInfo.PropertyType.IsArray)
                    {
                        classInner = Activator.CreateInstance(propertyInfo.PropertyType);
                        SetPropertiesForClass(classInner, _class);
                        RenderClassToUI(classInner, stackPanelAdditional, readOnly);
                    }
                    else
                    {
                        var property = _class.GetType().GetProperty(propertyInfo.Name);
                        var arrInstance = property.GetValue(_class);
                        var array = arrInstance as Array;
                        classInner = Array.CreateInstance(propertyInfo.PropertyType.GetElementType(),
                            array?.Length ?? 1);
                        var classArray = (Array)classInner;
                        for (int index = 0; index < classArray.Length; index++)
                        {
                            classArray.SetValue(Activator.CreateInstance(classArray.GetType().GetElementType()), index);
                            var element = classArray.GetValue(index);
                            SetPropertiesForClass(element, _class);
                            RenderClassToUI(element, stackPanelAdditional, readOnly);
                        }
                    }


                }
                else
                {
                    object value = propertyInfo.GetValue(_class, null);

                    TextBox textBox = new TextBox();
                    textBox.Width = 206;
                    textBox.Text = value?.ToString();
                    if (readOnly) textBox.IsReadOnly = true;
                    stackPanel.Children.Add(textBox);

                }

                panel.Children.Add(stackPanel);
            }

            return true;
        }

        private static void SetPropertiesForClass(object classInner, object objClass)
        {
            var properties = objClass.GetType().GetProperties();
            foreach (var propertyInfo in properties)
            {
                if (!propertyInfo.PropertyType.Name.Contains(classInner.GetType().Name)) continue;
                var instancePropertyInfo = objClass.GetType().GetProperty(propertyInfo.Name);
                var instanceProperty = instancePropertyInfo.GetValue(objClass);
                if (instanceProperty == null) break;

                PropertyInfo[] nastedProperties;
                if (!instancePropertyInfo.PropertyType.IsArray)
                {
                    nastedProperties = propertyInfo.PropertyType.GetProperties();
                    foreach (var nastedProperty in nastedProperties)
                    {
                        var value = nastedProperty.GetValue(instanceProperty);
                        var mainPropertyInfo = classInner.GetType().GetProperty(nastedProperty.Name);
                        mainPropertyInfo.SetValue(classInner, value);
                    }
                }
                else
                {
                    var arrElements = instanceProperty as Array;
                    for (int index = 0; index < arrElements.Length; index++)
                    {
                        instanceProperty = arrElements.GetValue(index);
                        nastedProperties = instanceProperty.GetType().GetProperties();
                        foreach (var nastedProperty in nastedProperties)
                        {
                            var value = nastedProperty.GetValue(instanceProperty);
                            var mainPropertyInfo = classInner.GetType().GetProperty(nastedProperty.Name);
                            mainPropertyInfo.SetValue(classInner, value);
                        }
                    }
                }

                break;
            }
        }

    }
}
