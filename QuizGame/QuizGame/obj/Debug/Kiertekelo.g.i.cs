﻿#pragma checksum "..\..\Kiertekelo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1677B52E08D1CCE289817CC51A70D8E972AB4B3E1DB556585F043CC6C8567138"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using QuizGame;
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


namespace QuizGame {
    
    
    /// <summary>
    /// Kiertekelo
    /// </summary>
    public partial class Kiertekelo : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\Kiertekelo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button vissza_gomb;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Kiertekelo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label felh_nev;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Kiertekelo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label elert_pontszam;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Kiertekelo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label legjobb_pontszam;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\Kiertekelo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label elert_ponszamok;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Kiertekelo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label legjobb_ponszamok;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Kiertekelo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label aaa;
        
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
            System.Uri resourceLocater = new System.Uri("/QuizGame;component/kiertekelo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Kiertekelo.xaml"
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
            this.vissza_gomb = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\Kiertekelo.xaml"
            this.vissza_gomb.Click += new System.Windows.RoutedEventHandler(this.Vissza);
            
            #line default
            #line hidden
            return;
            case 2:
            this.felh_nev = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.elert_pontszam = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.legjobb_pontszam = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.elert_ponszamok = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.legjobb_ponszamok = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.aaa = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

