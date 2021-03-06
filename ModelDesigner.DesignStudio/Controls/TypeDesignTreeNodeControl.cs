﻿//___________________________________________________________________________________
//
//  Copyright (C) 2019, Mariusz Postol LODZ POLAND.
//
//___________________________________________________________________________________

using CAS.UA.Model.Designer.Properties;
using CAS.UA.Model.Designer.Wrappers;
using System;
using System.Collections.Generic;
using System.Xml;

namespace CAS.UA.Model.Designer.Controls
{
  internal abstract class TypeDesignTreeNodeControl<T, type, MT> : NodeDesignTreeNodeControl<T, type, MT>
    where type : Wrappers4ProperyGrid.TypeDesign<MT>
    where MT : Opc.Ua.ModelCompiler.TypeDesign, new()
    where T : TypeDesign<type, MT>
  {
    public TypeDesignTreeNodeControl(T parent)
      : base(parent)
    { }
    protected override void BeforeMenuStripOpening()
    {
      AddMenuItemGoTo(Resources.WrapperTreeNodeAddMenuItemGoto
        + Resources.WrapperTreeNodeAddMenuItemGoto_BaseType,
        Resources.WrapperTreeNodeAddMenuItemGoto_BaseType_tooltip,
        new EventHandler(AddMenuItemGoTo_Click));
      base.BeforeMenuStripOpening();
    }
    private void AddMenuItemGoTo_Click(object sender, System.EventArgs e)
    {
      TreeView.GoToNode(ModelEntity.Wrapper.BaseType.XmlQualifiedName);
    }
    internal override Dictionary<string, XmlQualifiedName> GetCoupledNodesXmlQualifiedNames()
    {
      var list = base.GetCoupledNodesXmlQualifiedNames();
      if (ModelEntity.Wrapper.BaseType.XmlQualifiedName != null && !ModelEntity.Wrapper.BaseType.XmlQualifiedName.IsEmpty)
        list.Add(Resources.WrapperTreeNodeAddMenuItemGoto_BaseType, ModelEntity.Wrapper.BaseType.XmlQualifiedName);
      return list;
    }
    /// <summary>
    /// Gets the unique identifier.
    /// </summary>
    /// <param name="ui">The instance of <see cref="UniqueIdentifier"/> that represents an unique identifier.</param>
    /// <returns>
    /// 	<c>true</c> if it is not top level element; <c>false</c> otherwise if it is top level element
    /// </returns>
    internal override bool GetUniqueIdentifier(UniqueIdentifier ui)
    {
      if (!base.GetUniqueIdentifier(ui))
        ui.Update(false, ModelEntity.Wrapper.SymbolicName.XmlQualifiedName, true);
      return true;
    }
  }

}
