/*==== ComponentViewFactory.cs ====================================================
 * ComponentViewFactory is an utility to instantiate ComponentViews
 * 
 * Author: Victor Le aka "Coac"
 * Repository : https://github.com/Coac/debug-scene-ui
 * =========================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

public class ComponentViewFactory
{
    public static AbstractComponent getComponentView(Component co)
    {
        switch (co.GetType().Name)
        {
            case "Transform":
                return new TransformComponent((Transform)co);

            default:
                return new DefaultComponent(co);
        }
    }
}