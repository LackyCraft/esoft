﻿#pragma checksum "..\..\..\..\Nmobles\Store\AddSupplies.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "505608783D129F1B6FFF7D73FBF3EDC94C924F00"
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
using esoft.Nmobles.Store;


namespace esoft.Nmobles.Store {
    
    
    /// <summary>
    /// AddSupplies
    /// </summary>
    public partial class AddSupplies : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\Nmobles\Store\AddSupplies.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxTitle;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Nmobles\Store\AddSupplies.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxTypeNmobles;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Nmobles\Store\AddSupplies.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxPrice;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Nmobles\Store\AddSupplies.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxRealtor;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Nmobles\Store\AddSupplies.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxClient;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\Nmobles\Store\AddSupplies.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame FrameTypeInfo;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\Nmobles\Store\AddSupplies.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockWarning;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\Nmobles\Store\AddSupplies.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonAddSupline;
        
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
            System.Uri resourceLocater = new System.Uri("/esoft;component/nmobles/store/addsupplies.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Nmobles\Store\AddSupplies.xaml"
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
            this.TextBoxTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.ComboBoxTypeNmobles = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.TextBoxPrice = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\..\..\Nmobles\Store\AddSupplies.xaml"
            this.TextBoxPrice.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.changedCheck);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ComboBoxRealtor = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.ComboBoxClient = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.FrameTypeInfo = ((System.Windows.Controls.Frame)(target));
            return;
            case 7:
            this.TextBlockWarning = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.ButtonAddSupline = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\..\Nmobles\Store\AddSupplies.xaml"
            this.ButtonAddSupline.Click += new System.Windows.RoutedEventHandler(this.сheckWarning);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

