﻿//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using CAS.UA.Model.Designer.Properties;
using OPCFModelDesign = Opc.Ua.ModelCompiler.ModelDesign;

namespace CAS.UA.Model.Designer.IO
{
  /// <summary>
  /// Class OpcUaModelCompilerModelDesigner - helper class providing common functionality against
  /// </summary>
  internal static class OpcUaModelCompilerModelDesigner
  {
    internal static OPCFModelDesign GetDefault()
    { 
      return new OPCFModelDesign()
      {
        TargetNamespace = Settings.Default.TargetNamespace,
        Namespaces = new Opc.Ua.ModelCompiler.Namespace[]
        {
          new  Opc.Ua.ModelCompiler.Namespace()
               {
                 Value = Settings.Default.TargetNamespace,
                 XmlPrefix = Settings.Default.TargetNamespaceXmlPrefix,
                 Name = Settings.Default.TargetNamespaceXmlPrefix
               },
          new Opc.Ua.ModelCompiler.Namespace()
               {
                 XmlPrefix = Settings.Default.XmlUATypesPrefix,
                 Name = Settings.Default.XmlUATypesPrefix
               }
        }
      };
    }
  }
}
