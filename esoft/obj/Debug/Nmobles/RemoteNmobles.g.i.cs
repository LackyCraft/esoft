﻿#pragma checksum "..\..\..\Nmobles\RemoteNmobles.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EFC149FFE02F625C83A67F67A4E78AF60DBC82AC4B38670A7D6910A3402618A1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using esoft.Nmobles;


namespace esoft.Nmobles {
    
    
    /// <summary>
    /// RemoteNmobles
    /// </summary>
    public partial class RemoteNmobles : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\Nmobles\RemoteNmobles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonGoApartaments;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Nmobles\RemoteNmobles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonGoHouse;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Nmobles\RemoteNmobles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonGoLand;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Nmobles\RemoteNmobles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame FrameNmobles;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/esoft;component/nmobles/remotenmobles.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Nmobles\RemoteNmobles.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ButtonGoApartaments = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Nmobles\RemoteNmobles.xaml"
            this.ButtonGoApartaments.Click += new System.Windows.RoutedEventHandler(this.ScrolPage);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ButtonGoHouse = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Nmobles\RemoteNmobles.xaml"
            this.ButtonGoHouse.Click += new System.Windows.RoutedEventHandler(this.ScrolPage);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ButtonGoLand = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Nmobles\RemoteNmobles.xaml"
            this.ButtonGoLand.Click += new System.Windows.RoutedEventHandler(this.ScrolPage);
            
            #line default
            #line hidden
            return;
            case 4:
            this.FrameNmobles = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

