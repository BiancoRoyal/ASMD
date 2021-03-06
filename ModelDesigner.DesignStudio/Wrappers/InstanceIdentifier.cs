﻿//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using System.Xml;
using UAOOI.Windows.Forms;

namespace CAS.UA.Model.Designer.Wrappers
{
  /// <summary>
  /// Instance Identifier base class
  /// </summary>
  internal class InstanceIdentifier
  {

    #region private
    protected void UpdateName( XmlQualifiedName name )
    {
      m_Name = AddSuffix( m_Name, XmlQualifiedNameEditor.GetNameOrGenerateIfInstanceIsNull( name ) );
    }
    protected string m_Namespace = String.Empty;
    protected string m_Name = String.Empty;
    private const char separator = '_';
    #endregion

    #region internal
    internal static string AddSuffix( string name, string suffix )
    {
      if ( !String.IsNullOrEmpty( name ) )
        name += separator;
      return name + suffix;
    }
    /// <summary>
    /// Adds the suffix at the end of the <see cref="XmlQualifiedName.Name"/> separated by dash character.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="suffix">The suffix to be added.</param>
    /// <returns>New instance of <see cref="XmlQualifiedName"/></returns>
    internal static XmlQualifiedName AddSuffix( XmlQualifiedName name, string suffix )
    {
      return new XmlQualifiedName( AddSuffix( name.Name, suffix ), name.Namespace );
    }
    /// <summary>
    /// Removes the <paramref name="prefix"/> from the <paramref name="name"/> if it starts with, otherwise returns empty string.
    /// </summary>
    /// <param name="name">The name that starts with.</param>
    /// <param name="prefix">The prefix to be removed.</param>
    /// <returns><see cref="System.String"/>.</returns>
    internal static string RemovePrefix( string name, string prefix )
    {
      if ( String.IsNullOrEmpty( name ) )
        return String.Empty;
      if (!name.StartsWith(prefix))
        return String.Empty;
      return name.Replace( prefix + separator, "" );
    }
    internal static string NodeId(XmlQualifiedName qualifiedNodeId)
    {
      return qualifiedNodeId.ToString();
    }
    internal XmlQualifiedName InstanceQualifiedName { get { return new XmlQualifiedName( m_Name, m_Namespace ); } }
    internal protected bool InstanceDeclaration { get; protected set; }
    #endregion
  
  }
}
